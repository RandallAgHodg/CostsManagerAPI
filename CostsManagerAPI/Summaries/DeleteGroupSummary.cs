using CostsManagerAPI.Endpoints.Groups;
using FastEndpoints;

namespace CostsManagerAPI.Summaries;

public class DeleteGroupSummary : Summary<DeleteGroupEndpoint>
{
    public DeleteGroupSummary()
    {
        Description = "Delete an specific group in the database";
        Summary = "Delete an specific group in the database";
        Response(204,  "The group was deleted successfully");
        Response(404, "The group was not found");
    }
}