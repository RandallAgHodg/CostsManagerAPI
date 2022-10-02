using CostsCManagerAPI.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace CostsCManagerAPI.Middleware;

public class CreateCostRequestValidator : Validator<CreateCostRequest>
{
    public CreateCostRequestValidator()
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