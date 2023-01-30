using API.DbModels.Core;
using API.DbModels.Inventory.Brands;
using API.DbModels.Inventory.Categories;
using API.DbModels.Inventory.Products;
using API.DbModels.Inventory.SubCategories;
using API.DbModels.Sales.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Products
{
    [Table("inventory_products")]
    public class Product : TenantModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string AbName { get; set; } = null!;
        public decimal Capacity { get; set; }
        public string? Location { get; set; }
        public string? Origin { get; set; }
        public decimal? Price { get; set; }
        public string? UnityPrice { get; set; }
        public decimal? Large { get; set; }
        public decimal? Anchor { get; set; }
        public string? Size { get; set; }
        public string BarCode { get; set; } = null!;
        public string? BuyUnity { get; set; }
        public string? SellUnity { get; set; }
        public bool HasTax { get; set; }
        public decimal Tax { get; set; }
        public bool OnStock { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int? CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
        public ICollection<Client>? Clients { get; set; }
        //public ICollection<FacturaDetalle> FacturasDetalles { get; set; }
        public ICollection<ProductPrice> Prices { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductStock> Stocks { get; set; }
        public ICollection<ProductTransaction> Transactions { get; set; }


        public Product()
        {
            //FacturasDetalles = new HashSet<FacturaDetalle>();
            Images = new HashSet<ProductImage>();
            Prices = new HashSet<ProductPrice>();
            Stocks = new HashSet<ProductStock>();
            Transactions = new HashSet<ProductTransaction>();

        }

    }
}
