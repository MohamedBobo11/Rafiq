using MediatR;
using Rafiq.Application.Features.Test.Dtos;
using Rafiq.Domain.Common.Results;
using Rafiq.Domain.Test.Enum;

namespace Rafiq.Application.Features.Test.Commands.CreateTest;

public sealed record CreateTestCommand(string Title, string Description, TestState State) : IRequest<Result<TestDto>>;