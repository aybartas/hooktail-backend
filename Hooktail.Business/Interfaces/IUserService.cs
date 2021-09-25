using Hooktail.Entities.Concrete;
using Hooktail.Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.Interfaces
{
    public interface IUserService: IGenericService<User>
    {
        Task<User> ValidateUserCredentials(UserLoginDto userLoginDto);
        Task<User> GetUserByUsername(string username);

    }
}
