using MediatR;
using System;

namespace BaseAPI.Service.Command
{
    public class DeleteCustomerCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
