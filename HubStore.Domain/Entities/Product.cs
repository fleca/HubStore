using HubStore.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubStore.Domain.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }

		[Column(TypeName = "decimal(9,2)")]
		public decimal Price { get; set; }
		public List<ProductOrder> ProductOrders { get; set; }

		public void AddQuantity(int quantiy)
		{
			Quantity += quantiy;
		}

		public void SubtractQuantity(int quantity)
		{
			Quantity -= quantity;
		}
	}
}
