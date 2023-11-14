﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MinPrice { get; set; }
        public float MaxPrice { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Image> Images { get; set; }

    }
}
