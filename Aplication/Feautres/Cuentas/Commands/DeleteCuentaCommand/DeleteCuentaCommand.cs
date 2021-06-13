using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Feautres.Cuentas.Commands.DeleteCuentaCommand
{
    public class DeleteCuentaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCuentaCommandHandler : IRequestHandler<DeleteCuentaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cuenta> _repositoryAsync;

        public DeleteCuentaCommandHandler(IRepositoryAsync<Cuenta> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await _repositoryAsync.GetByIdAsync(request.Id);

            if (cuenta == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(cuenta);

                return new Response<int>(cuenta.Id);
            }
        }
    }
}