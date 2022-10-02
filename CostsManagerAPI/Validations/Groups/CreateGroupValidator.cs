using CostsManagerAPI.Contracts.Requests.Groups;
using FastEndpoints;
using FluentValidation;

namespace CostsManagerAPI.Validations.Groups;

public class CreateGroupValidator : Validator<CreateGroupRequest>
{
    public CreateGroupValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("The group`s name is required");
    }
}