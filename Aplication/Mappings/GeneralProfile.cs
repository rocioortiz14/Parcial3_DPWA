using Application.Feautres.Clientes.Commands.CreateClienteCommand;
using Application.Feautres.Cuentas.Commands.CreateCuentaCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
   public class GeneralProfile : Profile 
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreateClienteCommand, Cliente>();
            #endregion

            #region Commands
            CreateMap<CreateCuentaCommand, Cuenta>();
            #endregion
        }
    }
}
