using AutoMapper;
using Hooktail.Business.Interfaces;
using Hooktail.Business.StaticInfo.Roles;
using Hooktail.Business.Utility.Jwt;
using Hooktail.Entities.Concrete;
using Hooktail.Entities.DTOs.UserDTOs;
using Hooktail.WebAPI.ActionFilters;
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
        readonly IUserRoleService userRoleService;
        readonly IJwtService jwtService;
        readonly IMapper mapper;

        public AuthController(IUserService userService, IJwtService jwtService, IUserRoleService userRoleService, IMapper mapper)
        {
            this.userService = userService;
            this.jwtService = jwtService;
            this.userRoleService = userRoleService;
            this.mapper = mapper;
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var user = await userService.ValidateUserCredentials(userLoginDto);
        
            if(user != null)
            {
                var userRoles =  await userRoleService.GetUserRolesByUsername(user.Username);
                var token = jwtService.GenerateJwt(user, userRoles);
                return Created("", token);
            }
            return BadRequest("Wrong signin credentials");
        }

        [HttpPost("[action]")]
        [ValidateModel]
        public async Task<IActionResult> SignUp(CreateUserDto createUserDto, [FromServices] IRoleService roleService)
        {
            var user =  await userService.GetUserByUsername(createUserDto.Username);
             
            if(user != null)
            {
                return BadRequest($"{createUserDto.Username} is taken please login.");
            }

            await userService.AddAsync(mapper.Map<User>(createUserDto));

            var recordedUser = await userService.GetUserByUsername(createUserDto.Username);
            var role = await roleService.GetRoleByName(RoleInfo.User);
            var userRole = new UserRole { UserId = recordedUser.Id, RoleId = role.Id };

            await userRoleService.AddAsync(userRole);

            return Created("", createUserDto);
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
