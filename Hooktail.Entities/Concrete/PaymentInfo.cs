using Hooktail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Entities.Concrete
{
    public class PaymentInfo : ITable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PaymentType { get; set; }
        public string CardNumber { get; set; }

        public virtual User User { get; set; }

    }
}
