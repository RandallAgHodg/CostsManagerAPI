namespace CostsManagerAPI.Domain;

public class Group
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public DateTime CreatedAt { get; init; } = default!;
}