namespace Rafiq.Application.Features.Test.Mappers;

using Rafiq.Application.Features.Test.Commands.CreateTest;
using Rafiq.Application.Features.Test.Dtos;

public static class TestMappers
{
    public static TestDto ToDto(this Domain.Test.Test entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new TestDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            State = entity.State.ToString()
        };
    }

    public static List<TestDto> ToDtos(this IEnumerable<Domain.Test.Test> entities)
    {
        return [..entities.Select(e => e.ToDto()).ToList()];
    }
}
