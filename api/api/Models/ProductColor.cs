﻿namespace api.Models
{
    public class ProductColor
    {
        public int ProductColorId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }

        public Color Color { get; set; }
    }
}
