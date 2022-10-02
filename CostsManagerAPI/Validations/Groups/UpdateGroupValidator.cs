using CostsManagerAPI.Contracts.Requests.Groups;
using FastEndpoints;
using FluentValidation;

namespace CostsManagerAPI.Validations.Groups;

public class UpdateGroupValidator : Validator<UpdateGroupRequest>
{
    public UpdateGroupValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("The group`s name is required");
    }
}