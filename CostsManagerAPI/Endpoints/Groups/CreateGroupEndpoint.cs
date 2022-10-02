using CostsManagerAPI.Contracts.Requests.Groups;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Groups;

public class CreateGroupEndpoint : Endpoint<CreateGroupRequest>
{
    private readonly IGroupService _groupService;

    public CreateGroupEndpoint(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public override void Configure()
    {
        Post("groups");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateGroupRequest req, CancellationToken ct)
    {
        var group = req.ToGroup();
        await _groupService.CreateAsync(group);
        var groupResponse = group.ToGroupResponse();
        await SendCreatedAtAsync<GetGroupEndpoint>(
        new {Id = group.Id},
        groupResponse,
        generateAbsoluteUrl: true,
        cancellation: ct
        );
    }

}