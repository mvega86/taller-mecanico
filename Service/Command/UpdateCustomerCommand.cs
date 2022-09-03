using taller_mecanico.Domain.DTOs;
using MediatR;
using System;

namespace taller_mecanico.Service.Command
{
    public class UpdateCustomerCommand : IRequest
    {
        public CustomerDTO Customer { get; set; }
        public Guid Id { get; set; }
    }
}
