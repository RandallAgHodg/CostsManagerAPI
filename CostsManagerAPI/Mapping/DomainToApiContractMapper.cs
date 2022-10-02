using CostsManagerAPI.Contracts.Responses.Costs;
using CostsManagerAPI.Contracts.Responses.Groups;
using CostsManagerAPI.Domain;

namespace CostsManagerAPI.Mapping;

public static class DomainToApiContractMapper
{
    public static CostResponse ToCostResponse(this Cost cost)
    {
        return new CostResponse
        {
            Id = cost.Id,
            Name = cost.Name,
            Description = cost.Description,
            Amount = cost.Amount
        };
    }

    public static GetAllCostsResponse ToCostsResponse(this IEnumerable<Cost> cost)
    {
        return new GetAllCostsResponse
        {
            Costs = cost.Select(c =>
                new CostResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Amount = c.Amount
                }
            )
        };
    }

    public static GroupResponse ToGroupResponse(this Group group)
    {
        return new GroupResponse
        {
            Id = group.Id,
            Name = group.Name,
            CreatedAt = group.CreatedAt
        };
    }

    public static GetAllGroupsResponse ToGroupsResponse(this IEnumerable<Group> group)
    {
        return new GetAllGroupsResponse
        {
            Groups = group.Select(g =>
                new GroupResponse
                {
                    Id = g.Id,
                    Name = g.Name,
                    CreatedAt = g.CreatedAt
                }
            )
        };
    }
}