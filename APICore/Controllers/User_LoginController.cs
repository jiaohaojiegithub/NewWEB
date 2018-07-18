using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Interfaces;
using APICore.Models;
using DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_LoginController : ControllerBase
    {
        private readonly IUser_LoginRepository _LoginRepository;
        public User_LoginController(IUser_LoginRepository loginRepository)
        {
            _LoginRepository = loginRepository;
        }
        //Get api/ApiUser_Login
        /// <summary>
        /// 获取所有User_Login数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userLogin = await _LoginRepository.ListAsync();
            return Ok(userLogin);
        }
        /// <summary>
        /// 获取指定Id的数据User_Login
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>1
        [HttpGet("{id}", Name = "GetUser_Login")]
        public async Task<IActionResult> GetById(int id)
        {
            var UserLogin = await _LoginRepository.GetByIdAsync(id);
            if (UserLogin == null)
            {
                return NotFound();
            }
            return Ok(UserLogin);
        }
        /// <summary>
        /// 添加数据User_Login
        /// </summary>
        /// <remarks>
        /// Samo Request:
        ///     Post /DBUser_Login
        ///     {
        ///         "User_Login_EmailAddress":"**********QQ.com",
        ///         "User_Login_Name":"用户名",
        ///         "User_Login_PassWord":"**密码**",
        ///         "User_Login_Right":0,
        ///         "User_Login_Sex":"男",
        ///         "User_Login_State":true
        ///     }
        /// </remarks>
        /// <param name="user_Login"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost("Add")]
        [ProducesResponseType(typeof(DBUser_Login),200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Add(DBUser_Login user_Login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _LoginRepository.AddAsync(new User_Login
            {
                User_Login_EmailAddress = user_Login.User_Login_EmailAddress,
                User_Login_Name = user_Login.User_Login_Name,
                User_Login_PassWord = user_Login.User_Login_PassWord,
                User_Login_Right = user_Login.User_Login_Right,
                User_Login_Sex = user_Login.User_Login_Sex,
                User_Login_State = user_Login.User_Login_State
            });
            return CreatedAtRoute("GetUser_Login", new { id = 2 }, user_Login);
        }
    }
}