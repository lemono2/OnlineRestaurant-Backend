namespace OnlineShop.Dtos
{
	public class ProductAddDto
	{
		public string ProductName { get; set; } = null!;

		public decimal? ProductPrice { get; set; }

		public bool? HasNuts { get; set; }

		public string? ProductImage { get; set; }

		public bool? IsVegetarian { get; set; }

		public int? Spiciness { get; set; }

		public int? CategoryId { get; set; }
	}
}
