using CostsCManagerAPI.Contracts.Requests;
using CostsCManagerAPI.Contracts.Responses;
using CostsManagerAPI.Endpoints;
using FastEndpoints;

namespace CostsCManagerAPI.Summaries;

public class DeleteCostSummary : Summary<DeleteCostEndpoint>
{
    public DeleteCostSummary()
    {
        Description = "Delete an specific cost from the database";
        Summary = "Delete an specific cost from the database";
        Response<DeleteCostRequest>(204, "The cost was successfully deleted");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}