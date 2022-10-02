using CostsManagerAPI.Domain;
using CostsManagerAPI.Contracts.Data;

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

    public static Group ToGroup(this GroupDto groupDto)
    {
        return new Group
        {
            Id = groupDto.Id,
            Name = groupDto.Name,
            CreatedAt = groupDto.CreatedAt
        };
    }
}