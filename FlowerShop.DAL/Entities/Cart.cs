﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DAL.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public double? TotalMoney { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
