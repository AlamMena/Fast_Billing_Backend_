﻿using API.Dtos.Core;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Products
{
    public class ProductDto : CoreDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string AbName { get; set; } = null!;
        public string BarCode { get; set; } = null!;
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public decimal Capacity { get; set; }
        public string? Location { get; set; }
        public string? Origin { get; set; }
        public decimal? Large { get; set; }
        public decimal? Anchor { get; set; }
        public string? Size { get; set; }

        // prices
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal MarginBenefit { get; set; }
        public string? UnityPrice { get; set; }
        public string? BuyUnity { get; set; }
        public string? SellUnity { get; set; }
        public bool HasTax { get; set; }
        public decimal Tax { get; set; }
        public bool OnStock { get; set; }
        public int WarehouseId { get; set; }
        public decimal Stock { get; set; }
        public List<ProductImageDto> Images { get; set; } = null!;
    }
}
