namespace CostsManagerAPI.Contracts.Responses.Costs;

public class GetAllCostsResponse
{
    public IEnumerable<CostResponse> Costs { get; init; } = Enumerable.Empty<CostResponse>();
}