using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Constants;
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
        public async Task<JsonResponse> PostGuestAsync(SellerForCreationDto useDto)
        {
            try
            {
                var result = await sellerService.AddSellerAsync(useDto);
                return JsonResponse.DataResponse(result, ResponseMessages.SUCCESS_ADD_DATA);
            }
            catch (Exception exception)
            {
                return JsonResponse.ErrorResponse(exception.Message);
            }
        }

        [HttpGet]
        public async Task<JsonResponse> GetAllSellers()
        {
            try
            {
                var result = await sellerService.RetrieveAllSellers();
                return JsonResponse.DataResponse(result);
            }
            catch (Exception exception)
            {
                return JsonResponse.ErrorResponse(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<JsonResponse> GetSellerByIdAsync(int sellerId)
        {
            try
            {
                var result = await sellerService.RetrieveSellerByIdAsync(sellerId);
                return JsonResponse.DataResponse(result);
            }
            catch (Exception exception)
            {
                return JsonResponse.ErrorResponse(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<JsonResponse> PutSellerAsync(int sellerId, SellerForUpdateDTo sellerDto)
        {
            try
            {
                var result = await sellerService.ModifySellerAsync(sellerId, sellerDto);
                return JsonResponse.DataResponse(result, ResponseMessages.SUCCESS_UPDATE_DATA);
            }
            catch (Exception exception)
            {
                return JsonResponse.ErrorResponse(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<JsonResponse> DeleteSellerByIdAsync(int id)
        {
            try
            {
                var result = await sellerService.RemoveSellerByIdAsync(id);
                return JsonResponse.DataResponse(result, ResponseMessages.SUCCESS_DELETE_DATA);
            }
            catch (Exception ex)
            {
                return JsonResponse.ErrorResponse(ex.Message);
            }
        }
    }
}
