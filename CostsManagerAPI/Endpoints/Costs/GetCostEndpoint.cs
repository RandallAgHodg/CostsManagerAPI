using CostsManagerAPI.Contracts.Requests.Costs;
using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Costs;

public class GetCostEndpoint : Endpoint<GetCostRequest, CostResponse>
{
    private readonly ICostService _costService;

    public GetCostEndpoint(ICostService costService)
    {
        _costService = costService;
    }
    
    
    public override void Configure()
    {
        Get("costs/{id:guid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCostRequest req, CancellationToken ct)
    {
        var cost = await _costService.GetAsync(req.Id);

        if (cost is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var costResponse = cost.ToCostResponse();
        await SendOkAsync(costResponse, ct);
    }
}