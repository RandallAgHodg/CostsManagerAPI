namespace CostsManagerAPI.Contracts.Data;

public class GroupDto
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public DateTime CreatedAt { get; init; } = default!;
}