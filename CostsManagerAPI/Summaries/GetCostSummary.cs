using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Endpoints.Costs;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

public class GetCostSummary : Summary<GetCostEndpoint>
{
    public GetCostSummary()
    {
        Description = "Get a singular cost by its id";
        Summary = "Get a singular cost by its id";
        Response<CostResponse>(200, "Cost was successfully found and returned");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
        Response(404, "The cost was not found");
    }
}