using AutoMapper;
using taller_mecanico.Data.Entities;
using taller_mecanico.Domain.DTOs;
using taller_mecanico.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace taller_mecanico.Service.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDTO>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerRegistered = await _customerRepository.AddAsync(_mapper.Map<Customer>(request.CustomerDTO));
            return _mapper.Map<CustomerDTO>(customerRegistered);
        }
    }
}
