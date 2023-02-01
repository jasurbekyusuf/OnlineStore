using AutoMapper;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Constants;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;
using OnlineStore.Service.DTOs.Product;
using OnlineStore.Service.Interfaces;

namespace OnlineStore.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Product> AddProductAsync(ProductForCreationDto productDto)
        {
            try
            {
                if (productDto.Title == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_INVALID_DATA);
                }

                var product = mapper.Map<Product>(productDto);
                var result = await unitOfWork.Products.CreateAsync(product);
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

        public async Task<IQueryable<Product>> RetrieveAllProducts()
        {
            try
            {
                var result = await unitOfWork.Products.GetAllAsync();
                return result;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<Product> RetrieveProductByIdAsync(int productId)
        {
            try
            {
                Product product = await unitOfWork.Products.GetAsync(product => product.Id == productId);
                return product;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<Product> ModifyProductAsync(int productId, ProductForUpdateDTo productDto)
        {
            try
            {
                if (string.IsNullOrEmpty(productDto.Title))
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_INVALID_DATA);
                }

                var product = await unitOfWork.Products.GetAsync(product => product.Id == productId);
                if (product == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_NOT_FOUND_DATA);
                }

                product.Title = productDto.Title;
                //product.Description = productDto.Description;
                product.Price = productDto.Price;
                var result = await unitOfWork.Products.UpdateAsync(product);
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

        public async Task<bool> RemoveProductByIdAsync(int productId)
        {
            try
            {
                var product = await unitOfWork.Products.GetAsync(product => product.Id == productId);
                if (product == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_NOT_FOUND_DATA);
                }

                await unitOfWork.Products.DeleteAsync(product => product.Id == productId);
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

