using AutoMapper;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Constants;
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

        public async Task<Seller> AddSellerAsync(SellerForCreationDto sellerDto)
        {
            try
            {
                if (sellerDto.FirstName == null || sellerDto.Phone == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_INVALID_DATA);
                }

                var seller = mapper.Map<Seller>(sellerDto);
                var result = await unitOfWork.Sellers.CreateAsync(seller);
                await unitOfWork.SaveChangesAsync();

                if (result != null)
                {
                    return result;
                }

                throw new ErrorCodeException(ResponseMessages.ERROR_ADD_DATA);
            }
            catch (Exception exception)
            {

                throw;
            }

        }

        public async Task<IQueryable<Seller>> RetrieveAllSellers()
        {
            try
            {
                var result = await unitOfWork.Sellers.GetAllAsync();
                return result;
            }
            catch (Exception exception)
            {

                throw;
            }
        }
    }
}
