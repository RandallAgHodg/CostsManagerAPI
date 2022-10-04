using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Contracts.Responses.Groups;
using CostsManagerAPI.Endpoints.Groups;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

public class GetAllGroupsSummary : Summary<GetAllGroupsEndpoint>
{
    public GetAllGroupsSummary()
    {
        Description = "Get all the groups in the database";
        Summary = "Get all the groups in the database";
        Response<GetAllGroupsResponse>(200, "The groups were successfully retrieved");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}