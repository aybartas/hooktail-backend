using Hooktail.Business.Interfaces;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.Concrete
{
    public class UserService: GenericService<User>, IUserService
    {

        readonly IGenericRepository<User> genericRepository;

        public UserService(IGenericRepository<User> genericRepository) : base(genericRepository)
        {
            this.genericRepository = genericRepository;
        }
    }
}
