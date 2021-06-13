using Ardalis.Specification;
using Domain.Entities;
using System.Linq;

namespace Application.Specifications
{
    public class PagedCuentaSpecification : Specification<Cuenta>
    {
        public PagedCuentaSpecification(int pageSize, int pageNumber, string NombreBanco, string NombreCliente)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize);

            if (!string.IsNullOrEmpty(NombreBanco))
                Query.Search(x => x.NombreBanco, "%" + NombreBanco + "%");

            if (!string.IsNullOrEmpty(NombreCliente))
                Query.Search(x => x.NombreCliente, "%" + NombreCliente + "%");
        }
    }
}