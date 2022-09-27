using FastEndpoints;

namespace CostsCManagerAPI.Enpoints;

public class CreateCostEnpoint : EndpointWithoutRequest
{
    public override Task HandleAsync(CancellationToken ct)
    {
        return base.HandleAsync(ct);
    }
}