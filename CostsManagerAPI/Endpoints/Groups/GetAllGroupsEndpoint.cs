using CostsManagerAPI.Contracts.Responses.Groups;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Services;
using FastEndpoints;

namespace CostsManagerAPI.Endpoints.Groups;

public class GetAllGroupsEndpoint : EndpointWithoutRequest<GetAllGroupsResponse>
{
    private readonly IGroupService _groupService;

    public GetAllGroupsEndpoint(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public override void Configure()
    {
        Get("groups");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var groups = await _groupService.GetAllAsync();
        var groupsResponse = groups.ToGroupsResponse();
        await SendOkAsync(groupsResponse, ct);
    }

}