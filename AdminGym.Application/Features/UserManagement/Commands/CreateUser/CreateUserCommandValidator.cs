using FluentValidation;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateUser;
public class CreateUserCommandValidator
    : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserCommand.FirstName)
            .NotEmpty().WithMessage("El nombre de usuario no debe estar vacío.")
            .NotNull().WithMessage("El nombre de usuario es requerido.");

        RuleFor(x => x.UserCommand.PaternalSurname)
            .NotEmpty().WithMessage("El apellido paterno del usuario no debe estar vacío.")
            .NotNull().WithMessage("El apellido paterno del usuario es requerido.");

        RuleFor(x => x.UserCommand.Email)
            .NotEmpty().NotNull().EmailAddress().WithMessage("Se requiere un email válido.");


        RuleFor(x => x.UserCommand.Password)
            .NotEmpty().WithMessage("La contraseña es requerida.")
            .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
            .Matches(@"[A-Z]").WithMessage("La contraseña debe tener al menos una letra mayúscula.")
            .Matches(@"[a-z]").WithMessage("La contraseña debe tener al menos una letra minúscula.")
            .Matches(@"[0-9]").WithMessage("La contraseña debe tener al menos un número.")
            .Matches(@"[\!\?\*\.]").WithMessage("La contraseña debe tener al menos un carácter especial (!? *.).");
    }
}
