namespace CostsManagerAPI.Contracts.Requests.Groups;

public class UpdateGroupRequest
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
}