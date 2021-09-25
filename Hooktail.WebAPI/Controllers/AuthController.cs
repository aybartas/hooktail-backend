using AutoMapper;
using Hooktail.Business.Interfaces;
using Hooktail.Business.Utility.Jwt;
using Hooktail.Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
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
        readonly IUserService userService;
        readonly IJwtService jwtService;
        readonly IMapper mapper;

        public AuthController(IUserService userService, IJwtService jwtService, IMapper mapper)
        {
            this.userService = userService;
            this.jwtService = jwtService;
            this.mapper = mapper;
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

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await userService.GetUserByUsername(User.Identity.Name);
            if(user != null)
            {
                return Ok(mapper.Map<ActiveUserDto>(user));
            }
            return BadRequest(User.Identity.Name);
        }
    }
}
