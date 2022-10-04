using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Endpoints.Costs;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

public class UpdateCostSummary : Summary<UpdateCostEndpoint>
{
    public UpdateCostSummary()
    {
        Description = "Update an specific cost";
        Summary = "Update an specific cost";
        Response<CostResponse>(200, "The cost was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
        Response(404, "The cost was not found");
    }
}