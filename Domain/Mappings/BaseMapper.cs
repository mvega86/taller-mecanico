using AutoMapper;
using taller_mecanico.Data.Entities;
using taller_mecanico.Domain.DTOs;

namespace taller_mecanico.Domain.Mappings
{
    public class BaseMapper: Profile
    {
        public BaseMapper()
        {
            CreateMap<Customer, CustomerDTO>().ForMember(customer => customer.FullName, opt => opt.Ignore());
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
