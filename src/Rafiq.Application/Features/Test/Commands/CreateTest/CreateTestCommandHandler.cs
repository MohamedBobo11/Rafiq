using MediatR;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using Rafiq.Application.Common.Interfaces;
using Rafiq.Application.Features.Test.Dtos;
using Rafiq.Application.Features.Test.Mappers;
using Rafiq.Domain.Common.Results;

namespace Rafiq.Application.Features.Test.Commands.CreateTest;

public sealed class CreateTestCommandHandler (IAppDbContext context,
                                              ILogger<CreateTestCommandHandler> logger,
                                              HybridCache cache)
 : IRequestHandler<CreateTestCommand, Result<TestDto>>
{
    private readonly IAppDbContext _context = context;
    private readonly ILogger<CreateTestCommandHandler> _logger = logger;
    private readonly HybridCache _cache = cache;

    public async Task<Result<TestDto>> Handle(CreateTestCommand command, CancellationToken ct)
    {
        var result = Domain.Test.Test.Create(Guid.NewGuid(),
                                             command.Title,
                                             command.Description,
                                             command.State);

        if (result.IsError)
        {
            return result.Errors ?? [];
        }

        _context.Tests.Add(result.Value);
        await _context.SaveChangesAsync(ct);

        var test = result.Value;

        _logger.LogInformation("Test with ID {TestId} created successfully.", test.Id);

        await _cache.RemoveByTagAsync("test", ct);
        return test.ToDto();


    }
}