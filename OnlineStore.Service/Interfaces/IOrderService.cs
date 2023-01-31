using OnlineStore.Domain.Entities;
using OnlineStore.Service.DTOs.Order;

namespace OnlineStore.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(OrderForCreationDto orderDto);
        Task<IQueryable<Order>> RetrieveAllOrders();
        Task<Order> RetrieveOrderByIdAsync(int orderId);
        Task<Order> ModifyOrderAsync(int orderId, OrderForUpdateDto orderDto);
        Task<bool> RemoveOrderByIdAsync(int orderId);
    }
}
