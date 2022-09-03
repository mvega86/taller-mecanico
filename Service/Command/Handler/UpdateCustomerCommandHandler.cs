using AutoMapper;
using taller_mecanico.Data.Entities;
//using taller_mecanico.Messaging.Services.Send.Interfaces;
using taller_mecanico.Repositories.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace taller_mecanico.Service.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly IServiceBusTopicSender _serviceBusSender;

        public UpdateCustomerCommandHandler(IRepository<Customer> customerRepository, IMapper mapper, IServiceBusTopicSender serviceBusSender)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _serviceBusSender = serviceBusSender;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _mapper.Map<Customer>(request.Customer);
                var customerResult = await _customerRepository.UpdateAsync(customer, request.Id);
                var message = new Messaging.Data.MessageObj { TestInfo = request.Customer.FullName };
                await _serviceBusSender.SendMessageAsync(message);
                return await Task.FromResult(Unit.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
