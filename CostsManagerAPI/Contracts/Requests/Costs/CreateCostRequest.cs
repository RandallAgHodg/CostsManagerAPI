namespace CostsManagerAPI.Contracts.Requests.Costs;

public class CreateCostRequest
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public float Amount { get; init; } = default!;
}