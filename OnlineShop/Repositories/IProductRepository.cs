using OnlineShop.Entities;

namespace OnlineShop.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAll();

		Task<Product> AddProduct(Product product);

		Task<Category> GetCategoryById(int id);

		Task<Product> DeleteProduct(Product product);

		Task<Product> GetProductById(int id);
	}
}
