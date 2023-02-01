using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;

namespace OnlineStore.Infrastructure.Respositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly OnlinestoreContext onlinestoreContext;

        public ProductRepository (OnlinestoreContext onlinestoreContext) : base (onlinestoreContext)
        {
            this.onlinestoreContext = onlinestoreContext;
        }

        public override async Task<Product> GetAsync (Expression<Func<Product, bool>> expression) 
        {
            var product = await onlinestoreContext.Products.Include(product => product.CreatedSeller).FirstOrDefaultAsync (expression);
            return product;
        }
    }
}
