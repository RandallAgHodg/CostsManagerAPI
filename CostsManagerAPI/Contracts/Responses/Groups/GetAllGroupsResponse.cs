namespace CostsManagerAPI.Contracts.Responses.Groups;

public class GetAllGroupsResponse
{
    public IEnumerable<GroupResponse> Groups { get; init; } = Enumerable.Empty<GroupResponse>();
}