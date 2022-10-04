using CostsManagerAPI.Contracts.Data;
using CostsManagerAPI.Domain;

namespace CostsManagerAPI.Mapping;

public static class DomainMapperToDto
{
    public static CostDto ToCostDto(this Cost cost)
    {
        return new CostDto
        {
            Id = cost.Id,
            Name = cost.Name,
            Description = cost.Description,
            Amount = cost.Amount,
            GroupId = cost.GroupId
        };
    }

    public static GroupDto ToGroupDto(this Group group)
    {
        return new GroupDto
        {
            Id = group.Id,
            Name = group.Name,
            CreatedAt = group.CreatedAt,
            Costs = group.Costs 
        };
    }
}