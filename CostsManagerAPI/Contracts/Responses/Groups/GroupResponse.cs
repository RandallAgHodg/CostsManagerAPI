using CostsManagerAPI.Domain;

namespace CostsManagerAPI.Contracts.Responses.Groups;

public class GroupResponse
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public DateTime CreatedAt { get; init; } = default!;
    public List<Cost> Costs { get; init; } = default!;
}