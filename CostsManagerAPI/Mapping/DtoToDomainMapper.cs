using CostsManagerAPI.Domain;
using CostsManagerAPI.Contracts;

namespace CostsManagerAPI.Mapping;

public static class DtoToDomainMapper
{
    public static Cost ToCost(this CostDto costDto)
    {
        return new Cost
        {
            Id = costDto.Id,
            Name = costDto.Name,
            Description = costDto.Description,
            Amount = costDto.Amount
        };
    }
}