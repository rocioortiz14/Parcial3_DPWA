using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Feautres.Cuentas.Commands.CreateCuentaCommand
{
    public class CreateCuentaCommand : IRequest<Response<int>>
    {
        public string NombreBanco { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaApertura { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public float Retiros { get; set; }
        public float Depositos { get; set; }
        public float Saldo { get; set; }
    }
    public class CreateCuentaCommandHandler : IRequestHandler<CreateCuentaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cuenta> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCuentaCommandHandler(IRepositoryAsync<Cuenta> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public IMapper Mapper => _mapper;

        public IRepositoryAsync<Cuenta> RepositoryAsync => _repositoryAsync;

        public async Task<Response<int>> Handle(CreateCuentaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Cuenta>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);

            return new Response<int>(data.Id);
        }
    }
}
