using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System;
using taller_mecanico.Data.Entities;
using taller_mecanico.Repositories.Interface;
using taller_mecanico.Domain.DTOs;

namespace taller_mecanico.Service.Query
{
    public class GetCustomerByIdHandle : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByIdHandle(IRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(request.Id);
                return _mapper.Map<CustomerDTO>(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
