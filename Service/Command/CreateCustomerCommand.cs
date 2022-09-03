using taller_mecanico.Domain.DTOs;
using MediatR;

namespace taller_mecanico.Service.Command
{
    public class CreateCustomerCommand : IRequest<CustomerDTO>
    {
        public CustomerDTO CustomerDTO { get; set; }
    }
}
