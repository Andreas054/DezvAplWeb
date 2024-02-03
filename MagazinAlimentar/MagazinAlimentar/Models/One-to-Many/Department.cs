﻿using MagazinAlimentar.Models.Base;

namespace MagazinAlimentar.Models.One_to_Many
{
    public class Department : BaseEntity
    {
        public bool AgeRestriction { get; set; }

        // relation
        public ICollection<Product>? Products { get; set; }
    }
}
