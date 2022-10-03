using API.DbModels.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Products
{
    [Table("inventory_products_prices")]
    public class ProductPrice : TenantModel
    {
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal MarginBenefit { get; set; }
        //public string? BuyUnity { get; set; } = null!;
        //public decimal? DetailQuantity { get; set; }
        //public string? SellUnity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Producto { get; set; } = null!;

    }
}
