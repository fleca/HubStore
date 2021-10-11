using System.ComponentModel.DataAnnotations.Schema;

namespace HubStore.Domain.Entities
{
	public class ProductOrder
	{
		protected ProductOrder()
		{

		}

		public ProductOrder(Order order, Product product, int quantity)
		{
			Order = order;
			OrderId = order.Id;
			Product = product;
			ProductId = product.Id;
			Quantity = quantity;
			UnityPrice = product.Price;
		}

		public Order Order { get; set; }
		public int OrderId { get; set; }
		public Product Product { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }

		[Column(TypeName = "decimal(9,2)")]
		public decimal UnityPrice { get; set; }
	}
}
