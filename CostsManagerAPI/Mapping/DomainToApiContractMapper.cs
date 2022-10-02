using CostsCManagerAPI.Contracts.Responses;
using CostsManagerAPI.Domain;

namespace CostsCManagerAPI.Mapping;

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
}