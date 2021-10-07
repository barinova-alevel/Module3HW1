﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Implementation
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CompareTo(Product p)
        {
            return Price.CompareTo(p.Price);
        }
    }
}
