using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Entities.DTOs.ProductDTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int StockId { get; set; }
        public int SubCategoryId { get; set; }
        public string ImagePath { get; set; }
    }
}
