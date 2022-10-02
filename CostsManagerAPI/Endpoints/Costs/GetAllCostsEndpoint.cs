using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Costs;

public class GetAllCostsEndpoint : EndpointWithoutRequest<GetAllCostsResponse>
{
    private readonly ICostService _costService;

    public GetAllCostsEndpoint(ICostService costService)
    {
        _costService = costService;
    }

    public override void Configure()
    {
        Get("costs");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var costs= await _costService.GetAllAsync();
        var response = costs.ToCostsResponse();
        await SendOkAsync(response, ct);
    }
}