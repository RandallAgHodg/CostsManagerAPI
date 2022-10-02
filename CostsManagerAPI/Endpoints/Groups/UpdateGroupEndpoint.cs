using CostsManagerAPI.Contracts.Requests.Groups;
using CostsManagerAPI.Contracts.Responses.Groups;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Groups;

public class UpdateGroupEndpoint : Endpoint<UpdateGroupRequest, GroupResponse>
{
    private readonly IGroupService _groupService;

    public UpdateGroupEndpoint(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public override void Configure()
    {
        Put("groups/{id:guid}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(UpdateGroupRequest req, CancellationToken ct)
    {
        var existingGroup = await _groupService.GetAsync(req.Id);

        if (existingGroup is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        var group = req.ToGroup();
        await _groupService.UpdateAsync(group);
        var groupResponse = group.ToGroupResponse();
        await SendOkAsync(groupResponse, ct);
    }

}