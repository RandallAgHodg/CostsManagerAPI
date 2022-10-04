namespace CostsManagerAPI.Contracts.Data;

public class CostDto
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public float Amount { get; init; } = default!;
    public Guid GroupId { get; init; } = default!;
}