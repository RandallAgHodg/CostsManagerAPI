namespace CostsCManagerAPI.Contracts.Responses;

public class GetAllCostsResponse
{
    public IEnumerable<CostResponse> Costs { get; init; } = Enumerable.Empty<CostResponse>();
}