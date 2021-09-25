using Hooktail.Business.Interfaces;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;
using Hooktail.Entities.DTOs.UserDTOs;
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

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await genericRepository.GetAsync(I => I.Username == username);
            return user.FirstOrDefault();
        }

       
        public async Task<User> ValidateUserCredentials(UserLoginDto userLoginDto)
        {
            var user = await genericRepository.GetAsync(
                I => I.Username == userLoginDto.Username &&
                I.Password == userLoginDto.Password
                );

            return user.FirstOrDefault();
        }
    }
}
