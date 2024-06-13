using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Entities;
using OnlineShop.Services;
using OnlineShop.Dtos;

namespace OnlineShop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
		{
			var products = await _productService.GetAllDto();
			//products = (IEnumerable<Product>)_productService.productToDto();
			return Ok(products);
		}

		[HttpGet("GetFiltered")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetFiltered(bool? isVegetarian, bool? hasNuts, int? spiciness, int? categoryId)
		{
			var products = await _productService.GetFilteredDto(isVegetarian, hasNuts, spiciness, categoryId);
			if (spiciness > 4 || spiciness < 0)
			{
				return BadRequest();
			}
			
			return Ok(products);
		}

		[HttpPost("AddProduct")]
		public async Task<ActionResult<Product>> AddProduct(ProductAddDto product)
		{
			var _product = new Product {
				//ProductId = product.ProductId,
				ProductName = product.ProductName,
				ProductPrice = product.ProductPrice,
				HasNuts = product.HasNuts,
				ProductImage = product.ProductImage,
				IsVegetarian = product.IsVegetarian,
				Spiciness = product.Spiciness,
				CategoryId = product.CategoryId,
			};

			_product.Category = await _productService.GetCategoryById((int)_product.CategoryId);

			return Ok(await _productService.AddProduct(_product));
		}

		[HttpDelete("DeleteProduct")]
		public async Task<ActionResult<Product>> DeleteProduct(int id)
		{
			var delete = await _productService.DeleteProduct(id);
			if (delete == null)
			{
				return BadRequest();
			}
			return Ok(delete);
		}

	}
}
