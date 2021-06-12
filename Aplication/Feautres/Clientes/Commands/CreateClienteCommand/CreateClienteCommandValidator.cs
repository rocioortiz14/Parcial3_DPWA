using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Application;
namespace Application.Feautres.Clientes.Commands.CreateClienteCommand
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
               .NotNull().WithMessage("{PropertyName} No puesde estar vacio")
               .MaximumLength(80).WithMessage("{PropertyName} No debe exceder de {Maxlength} caracteres");

            RuleFor(p => p.Apellido)
               .NotNull().WithMessage("{PropertyName} No puede estar vacio")
               .MaximumLength(80).WithMessage("{PropertyName} No debe exceder de {Maxlength} caracteres");

            RuleFor(p => p.DUI)
             .NotNull().WithMessage("DUI no puede estar vacio")
            .Length(3, 12).WithMessage("El Codigo debe tener 12 caracteres")
            .Matches(@"^\d{8}-\d{1}$").WithMessage("El número de DUI debe de tener formato correcto");

            RuleFor(p => p.NIT)
             .NotNull().WithMessage("NIT no puede estar vacio")
            .Length(3, 18).WithMessage("El Codigo debe tener 17 caracteres")
            .Matches(@"^\d{4}-\d{6}-\d{3}-\d{1}$").WithMessage("El número de DUI debe de tener formato correcto");

            RuleFor(p => p.FechaNacimiento)
              .NotNull().WithMessage("FechaNacimineto No puede estar vacio");

            RuleFor(p => p.Telefono).NotNull().WithMessage("{PropertyName} No puede estar vacio")
               .MaximumLength(9)
               .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} debe cumplir el formato 0000-0000")
               .WithMessage("{PropertyName} no debe exceder de {Maxlength} caracteres");

            RuleFor(p => p.Email)
               .NotNull().WithMessage("{PropertyName} No puede estar vacio")
               .EmailAddress().WithMessage("{PropertyName} debe de ser una direccion de email valida")
               .MaximumLength(100).WithMessage("{PropertyName} No debe exceder de {Maxlength} caracteres");

            RuleFor(p => p.Direccion)
               .NotNull().WithMessage("{PropertyName} No puede estar vacio")
               .MaximumLength(120).WithMessage("{PropertyName} No debe exceder de {Maxlength} caracteres");
        }
    }
}