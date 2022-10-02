using CostsCManagerAPI.Contracts.Responses;
using CostsManagerAPI.Endpoints;
using FastEndpoints;

namespace CostsCManagerAPI.Summaries;

public class GetAllCostsSummary : Summary<GetAllCostsEndpoint>
{
    public GetAllCostsSummary()
    {
        Description = "Get all costs in the database";
        Summary = "Get all costs in the database";
        Response<GetAllCostsResponse>(200,  "All the costs have been retrieved successfully");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}