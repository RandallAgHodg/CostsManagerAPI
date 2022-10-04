using CostsManagerAPI.Contracts.Requests.Costs;
using CostsManagerAPI.Contracts.Requests.Groups;
using CostsManagerAPI.Domain;

namespace CostsManagerAPI.Mapping;

public static class ApiContractToDomainMapper
{
    public static Cost ToCost(this CreateCostRequest createCostRequest)
    {
        return new Cost
        {
            Id = Guid.NewGuid(),
            Name = createCostRequest.Name,
            Description = createCostRequest.Description,
            Amount = createCostRequest.Amount,
            GroupId = createCostRequest.GroupId
        };
    }

    public static Cost ToCost(this UpdateCostRequest updateCostRequest)
    {
        return new Cost
        {
            Id = updateCostRequest.Id,
            Name = updateCostRequest.Name,
            Description = updateCostRequest.Description,
            Amount = updateCostRequest.Amount,
            GroupId = updateCostRequest.GroupId
        };
    }

    public static Group ToGroup(this CreateGroupRequest createGroupRequest)
    {
        return new Group
        {
            Id = Guid.NewGuid(),
            Name = createGroupRequest.Name,
            CreatedAt = DateTime.Now
        };
    }

    public static Group ToGroup(this UpdateGroupRequest updateGroupRequest)
    {
        return new Group
        {
            Id = updateGroupRequest.Id,
            Name = updateGroupRequest.Name
        };
    }
}