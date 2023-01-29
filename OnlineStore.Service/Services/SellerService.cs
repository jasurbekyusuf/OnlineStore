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

        public async Task<Seller> RetrieveSellerByIdAsync(int sellerId)
        {
            try
            {
                Seller seller = await unitOfWork.Sellers.GetAsync(seller => seller.Id == sellerId);
                return seller;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<Seller> ModifySellerAsync(int sellerId, SellerForUpdateDTo sellerDto)
        {
            try
            {
                if (string.IsNullOrEmpty(sellerDto.FirstName))
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_INVALID_DATA);
                }

                var seller = await unitOfWork.Sellers.GetAsync(seller => seller.Id == sellerId);
                if (seller == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_NOT_FOUND_DATA);
                }

                if (seller.Email != sellerDto.Email)
                {
                    var existSellerEmail = (await unitOfWork.Sellers.GetAllAsync()).Any(seller => seller.Email == sellerDto.Email);
                    if (existSellerEmail)
                    {
                        throw new ErrorCodeException(ResponseMessages.ERROR_EXISTING_DATA);
                    }
                }

                seller.FirstName = sellerDto.FirstName;
                seller.LastName = sellerDto.LastName;
                seller.Email = sellerDto.Email;
                seller.Phone = sellerDto.Phone;

                var result = await unitOfWork.Sellers.UpdateAsync(seller);
                await unitOfWork.SaveChangesAsync();

                if (result == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_EDIT_DATA);
                }

                return result;
            }
            catch (Exception excepion)
            {
                throw;
            }
        }

        public async Task<bool> RemoveSellerByIdAsync(int sellerId)
        {
            try
            {
                var seller = await unitOfWork.Sellers.GetAsync(seller => seller.Id == sellerId);
                if (seller == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_NOT_FOUND_DATA);
                }

                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
