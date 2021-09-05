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
        public string Description { get; set; }
        public SubCategory SubCategory { get; set; }
#nullable enable
        public Stock? Stock { get; set; }
        public Campaign? Campaign { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        
#nullable disable
    }
}
