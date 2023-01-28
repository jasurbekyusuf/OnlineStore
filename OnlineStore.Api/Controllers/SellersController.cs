using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Service.DTOs.Seller;
using OnlineStore.Service.Interfaces;

namespace OnlineStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellersController : ControllerBase
    {
        private readonly ISellerService sellerService;

        public SellersController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostGuestAsync(SellerForCreationDto sellerDto)
        {
            if (sellerDto == null)
            {
                return BadRequest("Seller must not");
            }
            var seller = await sellerService.AddSellerAsync(sellerDto);
            return Ok(seller);
        }
    }
}
