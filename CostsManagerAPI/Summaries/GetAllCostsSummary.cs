using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Endpoints.Costs;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

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