using CostsCManagerAPI.Contracts.Responses;
using CostsManagerAPI.Endpoints;
using FastEndpoints;

namespace CostsCManagerAPI.Summaries;

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