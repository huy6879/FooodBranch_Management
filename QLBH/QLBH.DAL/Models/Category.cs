﻿using System;
using System.Collections.Generic;

namespace QLBH.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CateId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
