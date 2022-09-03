using taller_mecanico.Domain.DTOs;
using MediatR;
using System;

namespace taller_mecanico.Service.Query
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public Guid Id { get; set; }
    }
}