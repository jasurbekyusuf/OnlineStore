using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Service.SqlScripts
{

    public class SqlScriptsService
    {
        private readonly OnlinestoreContext _context;

        public SqlScriptsService(OnlinestoreContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetails>> GetOrderDetails()
        {
            return await _context.Set<OrderDetails>().FromSqlRaw("SELECT Top 20 * FROM [dbo].[GetOrderDetails]()").ToListAsync();
        }
    }
}
