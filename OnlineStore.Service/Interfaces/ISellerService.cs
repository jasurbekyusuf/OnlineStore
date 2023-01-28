using OnlineStore.Service.DTOs.Seller;

namespace OnlineStore.Service.Interfaces
{
    public interface ISellerService
    {
        Task<SellerForSelectDTo> AddSellerAsync(SellerForCreationDto sellerDto);
    }
}
