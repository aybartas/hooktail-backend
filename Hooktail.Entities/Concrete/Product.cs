using Hooktail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Entities.Concrete
{
    public class Product: ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? StockId { get; set; }
        public int SubCategoryId { get; set; }
        public string ImagePath { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual ICollection<ProductCampaign> ProductCampaigns { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
