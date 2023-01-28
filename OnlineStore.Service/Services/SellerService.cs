using AutoMapper;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;
using OnlineStore.Service.DTOs.Seller;
using OnlineStore.Service.Interfaces;

namespace OnlineStore.Service.Services
{
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SellerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<SellerForSelectDTo> AddSellerAsync(SellerForCreationDto sellerDto)
        {
            Seller seller = mapper.Map<Seller>(sellerDto);
            seller = await unitOfWork.Sellers.CreateAsync(seller);
            await unitOfWork.SaveChangesAsync();
            var sellerForSelect = mapper.Map<SellerForSelectDTo>(seller);

            return sellerForSelect;
        }
    }
}
