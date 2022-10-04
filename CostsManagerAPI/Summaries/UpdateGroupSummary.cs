using CostsManagerAPI.Contracts.Responses;
using CostsManagerAPI.Contracts.Responses.Groups;
using CostsManagerAPI.Endpoints.Groups;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

public class UpdateGroupSummary : Summary<UpdateGroupEndpoint>
{
    public UpdateGroupSummary()
    {
        Description = "Update a group";
        Summary = "Update a group";
        Response<GroupResponse>(200, "The group was updated successfully");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
        Response(404, "The group was not found");
    }
}