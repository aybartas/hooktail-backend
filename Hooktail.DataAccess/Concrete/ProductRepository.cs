﻿using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

    }
}
