using CostsManagerAPI.Contracts.Requests.Groups;
using CostsManagerAPI.Contracts.Responses.Groups;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Groups;

public class GetGroupEndpoint : Endpoint<GetGroupRequest, GroupResponse>
{
    private readonly IGroupService _groupService;

    public GetGroupEndpoint(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public override void Configure()
    {
        Get("groups/{id:guid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetGroupRequest req, CancellationToken ct)
    {
        var group = await _groupService.GetAsync(req.Id);

        if (group is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var groupResponse = group.ToGroupResponse();
        await SendOkAsync(groupResponse, ct);
    }
}