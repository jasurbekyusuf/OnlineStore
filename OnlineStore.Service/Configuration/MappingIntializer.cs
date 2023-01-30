using AutoMapper;
using OnlineStore.Domain.Entities;
using OnlineStore.Service.DTOs.Customer;
using OnlineStore.Service.DTOs.Seller;

namespace OnlineStore.Service.Configuration
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {
            CreateMap<Seller, SellerForCreationDto>().ReverseMap();
            CreateMap<Seller, SellerForUpdateDTo>().ReverseMap();
            CreateMap<Customer, CustomerForCreationDto>().ReverseMap();
            CreateMap<Customer, CustomerForUpdateDTo>().ReverseMap();  
        }
    }
}
