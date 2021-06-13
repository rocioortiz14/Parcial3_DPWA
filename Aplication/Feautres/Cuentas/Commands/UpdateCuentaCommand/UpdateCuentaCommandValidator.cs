using FluentValidation;

namespace Application.Feautres.Cuentas.Commands.UpdateCuentaCommand
{
    public class UpdateCuentaCommandValidator : AbstractValidator<UpdateCuentaCommand>
    {
        public UpdateCuentaCommandValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
                RuleFor(p => p.NombreBanco)
                   .NotEmpty().WithMessage("{PropertyName} No puesde estar vacio")
                   .MaximumLength(50).WithMessage("{PropertyName} No debe exceder de {Maxlength} caracteres");

                RuleFor(p => p.NombreCliente)
                    .NotEmpty().WithMessage("{PropertyName} No puede estar vacio")
                   .MaximumLength(50).WithMessage("{PropertyName} No debe exceder de {Maxlength} caracteres");

                RuleFor(p => p.NumeroCuenta)
                  .NotEmpty().WithMessage("Numero Cuenta no puede estar vacio")
                .Length(3, 15).WithMessage("El Numero de Cuenta debe tener 15 caracteres")
                .Matches(@"^\d{2}-\d{2}-\d{4}-\d{1}$").WithMessage("Numero Cuenta debe de tener formato correcto");

                RuleFor(p => p.TipoCuenta)
                   .NotEmpty().WithMessage("{PropertyName} No puede estar vacio")
                   .MaximumLength(10).WithMessage("{PropertyName} No debe exceder de {Maxlength} caracteres");

                RuleFor(p => p.Retiros)
                .NotEmpty().WithMessage("{PropertyName} No puede estar vacio");

                RuleFor(p => p.Depositos)
             .NotEmpty().WithMessage("{PropertyName} No puede estar vacio");

                RuleFor(p => p.Saldo)
             .NotEmpty().WithMessage("{PropertyName} No puede estar vacio");
            }
        }
    }
