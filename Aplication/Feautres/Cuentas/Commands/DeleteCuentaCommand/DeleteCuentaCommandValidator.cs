using FluentValidation;

namespace Application.Feautres.Cuentas.Commands.DeleteCuentaCommand
{
    public class DeleteCuentaCommandValidator : AbstractValidator<DeleteCuentaCommand>
    {
        public DeleteCuentaCommandValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}