namespace CostsManagerAPI.Domain;

public class Cost
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public float Amount { get; init; } = default!;
    public Guid GroupId { get; init; } = default!;
}