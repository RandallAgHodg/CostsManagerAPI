using CostsManagerAPI.Contracts;
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
            Amount = cost.Amount
        };
    }
}