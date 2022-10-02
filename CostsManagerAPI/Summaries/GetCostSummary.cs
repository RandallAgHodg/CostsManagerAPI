using CostsCManagerAPI.Contracts.Responses;
using CostsManagerAPI.Endpoints;
using FastEndpoints;

namespace CostsCManagerAPI.Summaries;

public class GetCostSummary : Summary<GetCostEndpoint>
{
    public GetCostSummary()
    {
        Description = "Get a singular cost by its id";
        Summary = "Get a singular cost by its id";
        Response<CostResponse>(200, "Cost was successfully found and returned");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}