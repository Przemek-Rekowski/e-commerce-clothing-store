﻿using Domain.Entities.Product;

namespace Application.Product.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Price { get; set; }
        public bool IsAvalible { get; set; }

        public List<SizeDto> SizeDtos { get; set; } = new();
    }
}
