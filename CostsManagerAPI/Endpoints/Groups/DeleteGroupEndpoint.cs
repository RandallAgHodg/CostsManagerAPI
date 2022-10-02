using CostsManagerAPI.Contracts.Requests.Groups;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Groups;

public class DeleteGroupEndpoint : Endpoint<DeleteGroupRequest>
{
    private readonly IGroupService _groupService;

    public DeleteGroupEndpoint(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public override void Configure()
    {
        Delete("groups/{id:guid}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteGroupRequest req, CancellationToken ct)
    {
        var deleted = await _groupService.DeleteAsync(req.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}