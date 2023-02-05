using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entities;
using OnlineStore.Service.SqlScripts;

namespace OnlineStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersGetController : ControllerBase
    {
        private readonly SqlScriptsService _sqlScriptsService;

        public OrdersGetController(OnlinestoreContext onlinestoreContext)
        {
            _sqlScriptsService = new SqlScriptsService(onlinestoreContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails1()
        {
            var result = await _sqlScriptsService.GetOrderDetails();
            return Ok(result);
        }
    }
}
