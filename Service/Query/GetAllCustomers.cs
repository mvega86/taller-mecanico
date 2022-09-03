using taller_mecanico.Domain.DTOs;
using MediatR;
using System.Collections.Generic;

namespace taller_mecanico.Service.Query
{
    public class GetAllCustomer : IRequest<IEnumerable<CustomerDTO>>
    {
        public string SortBy{ get; set; }
        public int CurrentPage{ get; set; }
        public int ItemByPage{ get; set; }
    }
}