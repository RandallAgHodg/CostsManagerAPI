using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Contracts.Responses.Groups;
using CostsManagerAPI.Endpoints.Groups;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

public class GetGroupSummary : Summary<GetGroupEndpoint>
{
    public GetGroupSummary()
    {
        Description = "Get a an specific group by its id";
        Summary = "Get an specific group by its id";
        Response<GroupResponse>(200, "The group was successfully retrieved");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
        Response(404, "The group was not found");
    }
}