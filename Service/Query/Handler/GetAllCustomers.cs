using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using taller_mecanico.Repositories.Interface;
using taller_mecanico.Data.Entities;
using taller_mecanico.Service.Query;
using taller_mecanico.Domain.DTOs;

namespace taller_mecanico.Service.Query
{
    public class GetAllCustomers : IRequestHandler<GetAllCustomer, IEnumerable<CustomerDTO>>
    {
        private IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public GetAllCustomers(IRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

        }

        public Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomer request, CancellationToken cancellationToken)
        {
            var skipItemsCount = request.ItemByPage * (request.CurrentPage-1);
            var customer = _customerRepository.GetAll().Skip(skipItemsCount).Take(request.ItemByPage);
            return Task.FromResult(_mapper.Map<IEnumerable<CustomerDTO>>(customer));
        }
    }
}
