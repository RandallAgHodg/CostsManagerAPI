namespace CostsManagerAPI.Contracts.Requests.Costs;

public class GetAllCostsByGroupRequest
{
    public Guid GroupId { get; init; } = default!;
}