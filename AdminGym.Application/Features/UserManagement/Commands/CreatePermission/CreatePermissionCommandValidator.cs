using FluentValidation;

namespace AdminGym.Application.Features.UserManagement.Commands.CreatePermission;
public class CreatePermissionCommandValidator
    : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionCommandValidator()
    {
        RuleFor(x => x.CreatePermissionDto.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.CreatePermissionDto.Description)
            .NotEmpty()
            .NotNull();
    }
}
