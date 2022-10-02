using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Endpoints.Costs;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

public class CreateCostSummary : Summary<CreateCostEndpoint>
{
    public CreateCostSummary()
    {
        Description = "Creates a new cost register";
        Summary = "Creates a new cost register";
        Response<CostResponse>(201, "Cost was successfully registered");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}