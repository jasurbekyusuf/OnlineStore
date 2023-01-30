using AutoMapper;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Constants;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;
using OnlineStore.Service.DTOs.Customer;
using OnlineStore.Service.Interfaces;

namespace OnlineStore.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Customer> AddCustomerAsync(CustomerForCreationDto customerDto)
        {
            try
            {
                if (customerDto.FirstName == null || customerDto.Phone == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_INVALID_DATA);
                }

                var customer = mapper.Map<Customer>(customerDto);
                var result = await unitOfWork.Customers.CreateAsync(customer);
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

        public async Task<IQueryable<Customer>> RetrieveAllCustomers()
        {
            try
            {
                var result = await unitOfWork.Customers.GetAllAsync();
                return result;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<Customer> RetrieveCustomerByIdAsync(int customerId)
        {
            try
            {
                Customer customer = await unitOfWork.Customers.GetAsync(customer => customer.Id == customerId);
                return customer;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<Customer> ModifyCustomerAsync(int customerId, CustomerForUpdateDTo customerDto)
        {
            try
            {
                if (string.IsNullOrEmpty(customerDto.FirstName))
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_INVALID_DATA);
                }

                var customer = await unitOfWork.Customers.GetAsync(customer => customer.Id == customerId);
                if (customer == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_NOT_FOUND_DATA);
                }

                if (customer.Email != customerDto.Email)
                {
                    var existSellerEmail = (await unitOfWork.Sellers.GetAllAsync()).Any(customer => customer.Email == customerDto.Email);
                    if (existSellerEmail)
                    {
                        throw new ErrorCodeException(ResponseMessages.ERROR_EXISTING_DATA);
                    }
                }

                customer.FirstName = customerDto.FirstName;
                customer.LastName = customerDto.LastName;
                customer.Email = customerDto.Email;
                customer.Phone = customerDto.Phone;

                var result = await unitOfWork.Customers.UpdateAsync(customer);
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

        public async Task<bool> RemoveCustomerByIdAsync(int customerId)
        {
            try
            {
                var customer = await unitOfWork.Customers.GetAsync(customer => customer.Id == customerId);
                if (customer == null)
                {
                    throw new ErrorCodeException(ResponseMessages.ERROR_NOT_FOUND_DATA);
                }

                await unitOfWork.Customers.DeleteAsync(customer => customer.Id == customerId);
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
