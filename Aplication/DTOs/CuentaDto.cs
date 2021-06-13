using System;

namespace Application.DTOs
{
    public class CuentaDto
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
}

