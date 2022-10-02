using CostsManagerAPI.Domain;
using CostsManagerAPI.Mapping;
using CostsManagerAPI.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace CostsCManagerAPI.Services;

public class CostService : ICostService
{
    private readonly ICostRepository _costRepository;

    public CostService(ICostRepository costRepository)
    {
        _costRepository = costRepository;
    }

    public async Task<bool> CreateAsync(Cost cost)
    {
        var existsCostWithThatName = await _costRepository.FindByNameAsync(cost.Name);

        if (existsCostWithThatName)
        {
            var message = $"A product with name ${cost.Name} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Cost), message)
            });
        }

        var existsCostWithThatId = await _costRepository.GetAsync(cost.Id);
        
        if (existsCostWithThatName)
        {
            var message = $"A product with id ${cost.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Cost), message)
            });
        }

        var costDto = cost.ToCostDto();
        return await _costRepository.CreateAsync(costDto);
    }

    public async Task<Cost?> GetAsync(Guid id)
    {
        var costDto = await _costRepository.GetAsync(id);
        return costDto?.ToCost();
    }

    public async Task<IEnumerable<Cost>> GetAllAsync()
    {
        var costsDto = await _costRepository.GetAllAsync();
        return costsDto.Select(x => x.ToCost());
    }

    public async Task<bool> UpdateAsync(Cost cost)
    {
        var costDto = cost.ToCostDto();
        return await _costRepository.UpdateAsync(costDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _costRepository.DeleteAsync(id);
    }
}