using Hooktail.Business.Interfaces;
using Hooktail.Business.Utility.Jwt;
using Hooktail.Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hooktail.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserService userService;
        IJwtService jwtService;
        public AuthController(IUserService userService, IJwtService jwtService)
        {
            this.userService = userService;
            this.jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult>  SignIn(UserLoginDto userLoginDto)
        {
            var user = await userService.ValidateUserCredentials(userLoginDto);

            if(user != null)
            {
                var token = jwtService.GenerateJwt(user);
                return Created("", token);
            }
            return BadRequest("Wrong signin credentials");
        }
    }
}
