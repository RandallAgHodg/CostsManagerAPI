using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Contracts.Responses.Groups;
using CostsManagerAPI.Endpoints.Groups;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

public class CreateGroupSummary : Summary<CreateGroupEndpoint>
{
    public CreateGroupSummary()
    {
        Description = "Create a new group";
        Summary = "Create a new group";
        Response<GroupResponse>(201, "The group was created successfully");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}