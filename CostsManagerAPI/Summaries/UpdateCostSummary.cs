using CostsCManagerAPI.Contracts.Responses;
using CostsManagerAPI.Endpoints;
using FastEndpoints;

namespace CostsCManagerAPI.Summaries;

public class UpdateCostSummary : Summary<UpdateCostEndpoint>
{
    public UpdateCostSummary()
    {
        Description = "Update an specific cost";
        Summary = "Update an specific cost";
        Response<CostResponse>(200, "The cost was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}