using Hooktail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Entities.Concrete
{
    public class ProductCampaign:ITable
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int ProductId { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual Product Product { get; set; }

    }
}
