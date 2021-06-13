using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Feautres.Cuentas.Commands.UpdateCuentaCommand
{
    public class UpdateCuentaCommand : IRequest<Response<int>>

    {
        public int Id { get; set; }
        public string NombreBanco { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaApertura { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public float Retiros { get; set; }
        public float Depositos { get; set; }
        public float Saldo { get; set; }
    }
    public class UpdateCuentaCommandHandler : IRequestHandler<UpdateCuentaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cuenta> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCuentaCommandHandler(IRepositoryAsync<Cuenta> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await _repositoryAsync.GetByIdAsync(request.Id);

            if (cuenta == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                cuenta.NombreBanco = request.NombreBanco;
                cuenta.NombreCliente = request.NombreCliente;
                cuenta.NumeroCuenta = request.NumeroCuenta;
                cuenta.TipoCuenta = request.TipoCuenta;
                cuenta.Depositos = request.Depositos;
                cuenta.Retiros = request.Retiros;
                cuenta.Saldo = request.Saldo;

                await _repositoryAsync.UpdateAsync(cuenta);

                return new Response<int>(cuenta.Id);
            }
        }
    }
}


