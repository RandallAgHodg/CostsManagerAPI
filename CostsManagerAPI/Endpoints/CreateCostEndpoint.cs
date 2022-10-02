using CostsCManagerAPI.Contracts.Requests;
using CostsCManagerAPI.Contracts.Responses;
using CostsCManagerAPI.Mapping;
using CostsCManagerAPI.Services;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Repositories;
using FastEndpoints;
using Namotion.Reflection;

namespace CostsManagerAPI.Endpoints;

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