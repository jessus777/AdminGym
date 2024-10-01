using FluentValidation;

namespace AdminGym.Application.Features.UserManagement.Queries.GetById;
public class GetByIdQueryValidator
    : AbstractValidator<GetByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("El Id es requerido.")
            .Must(BeAValidGuid).WithMessage("El Id debe ser un GUID válido.");

    }

    private bool BeAValidGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}
