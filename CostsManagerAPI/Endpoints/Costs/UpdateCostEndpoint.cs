using CostsManagerAPI.Contracts.Requests.Costs;
using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Costs;

public class UpdateCostEndpoint : Endpoint<UpdateCostRequest, CostResponse>
{
    private readonly ICostService _costService;

    public UpdateCostEndpoint(ICostService costService)
    {
        _costService = costService;
    }

    public override void Configure()
    {
        Put("costs/{id:guid}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(UpdateCostRequest req, CancellationToken ct)
    {
        var existingCost = await _costService.GetAsync(req.Id);
        
        if (existingCost is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var cost = req.ToCost();
        await _costService.UpdateAsync(cost);
        var costResponse = cost.ToCostResponse();
        await SendOkAsync(costResponse, ct);
    }

}