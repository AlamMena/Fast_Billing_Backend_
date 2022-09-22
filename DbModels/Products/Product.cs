using API.DbModels.Brands;
using API.DbModels.Core;
using API.DbModels.Inventory.Categories;

namespace API.DbModels.Products
{
    public class Product : TenantModel
    {
        public string Name { get; set; } = null!;
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
        public int? DocNum { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int? CategoryId { get; set; }
        public Category? Categoria { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
        public int? ContactId { get; set; }
        public ICollection<Contacts>? Contacts { get; set; }
        //public ICollection<FacturaDetalle> FacturasDetalles { get; set; }
        public ICollection<ProductoPrecio> Precios { get; set; }
        public ICollection<ProductoImagen> Imagenes { get; set; }
        public ICollection<ProductoCantidad> Cantidades { get; set; }

        public Producto()
        {
            FacturasDetalles = new HashSet<FacturaDetalle>();
            Imagenes = new HashSet<ProductoImagen>();
            Precios = new HashSet<ProductoPrecio>();
            Cantidades = new HashSet<ProductoCantidad>();

        }

    }
}
