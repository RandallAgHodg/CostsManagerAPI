using CostsManagerAPI.Contracts.Requests.Costs;
using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Costs;

public class GetAllCostsEndpoint : Endpoint<GetAllCostsByGroupRequest, GetAllCostsResponse>
{
    private readonly ICostService _costService;

    public GetAllCostsEndpoint(ICostService costService)
    {
        _costService = costService;
    }

    public override void Configure()
    {
        Get("groups/{groupid:guid}/costs");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllCostsByGroupRequest req,CancellationToken ct)
    {
        var costs= await _costService.GetAllAsync(req.GroupId);
        var response = costs.ToCostsResponse();
        await SendOkAsync(response, ct);
    }
}