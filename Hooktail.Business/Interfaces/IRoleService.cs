﻿using Hooktail.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.Interfaces
{
    public interface IRoleService: IGenericService<Role>
    {
         string GetRoleById(int id);
    }
}
