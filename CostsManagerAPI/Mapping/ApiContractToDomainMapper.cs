using CostsCManagerAPI.Contracts.Requests;

using CostsManagerAPI.Domain;

namespace CostsCManagerAPI.Mapping;

public static class ApiContractToDomainMapper
{
    public static Cost ToCost(this CreateCostRequest createCostRequest)
    {
        return new Cost
        {
            Id = Guid.NewGuid(),
            Name = createCostRequest.Name,
            Description = createCostRequest.Description,
            Amount = createCostRequest.Amount
        };
    }

    public static Cost ToCost(this UpdateCostRequest updateCostRequest)
    {
        return new Cost
        {
            Id = updateCostRequest.Id,
            Name = updateCostRequest.Name,
            Description = updateCostRequest.Description,
            Amount = updateCostRequest.Amount
        };
    }
}