using CostsManagerAPI.Contracts.Requests.Costs;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Costs;

public class CreateCostEndpoint : Endpoint<CreateCostRequest>
{
    private readonly ICostService _costService;

    public CreateCostEndpoint(ICostService costService)
    {
        _costService = costService;
    }

    public override void Configure()
    {
        Post("costs");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCostRequest req, CancellationToken ct)
    {

        var cost = req.ToCost();
        await _costService.CreateAsync(cost);
        var costResponse = cost.ToCostResponse();
        await SendCreatedAtAsync<GetCostEndpoint>(new
        {
            Id = cost.Id
        }, 
            costResponse,
            generateAbsoluteUrl: true
        , cancellation: ct);
    }
}