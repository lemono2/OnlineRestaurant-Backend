using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;

namespace OnlineShop.Repositories
{
	public class ProductRepository : IProductRepository
	{
		readonly OnlineRestaurantContext _context;
		public ProductRepository(OnlineRestaurantContext context) 
		{
			_context = context;	
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _context.Products.ToListAsync();
		}


		public async Task<Product> AddProduct(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task<Category> GetCategoryById(int id)
		{
			return await _context.Categories.FirstOrDefaultAsync(b => b.CategoryId == id);
		}

		public async Task<Product> GetProductById(int id)
		{
			return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
		}

		public async Task<Product> DeleteProduct(Product product)
		{
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return product;
		}

	}
}
