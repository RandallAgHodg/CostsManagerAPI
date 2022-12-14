using CostsManagerAPI.Contracts.Requests.Costs;
using FastEndpoints;
using FluentValidation;

namespace CostsManagerAPI.Validations.Costs;

public class UpdateCostRequestValidator : Validator<UpdateCostRequest>
{
    public UpdateCostRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("The cost name is required");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("The cost description is required");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage("The cost amount is required")
            .GreaterThan(0)
            .WithMessage("The cost amount must be greater than 0");
    }
}