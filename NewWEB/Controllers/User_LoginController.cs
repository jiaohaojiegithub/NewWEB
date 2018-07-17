using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewWEB.Areas.Identity.Interfaces;
using DBModels;
using NewWEB.Areas.Identity.Data;
using Microsoft.Extensions.Logging;
using NewWEB.Log;

namespace NewWEB.Controllers
{
    public class User_LoginController : Controller
    {
        private readonly IUser_LoginRepository _LoginRepository;
        //创建日志
        private readonly ILogger _logger;
        public User_LoginController(IUser_LoginRepository loginRepository,ILogger<User_LoginController> logger)
        {
            _LoginRepository = loginRepository;
            _logger = logger;
        }
        /// <summary>
        /// 输出所有数据视图
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation(LoggingEvents.GetItem, $"获取{this}数据列表");
            var UserLogin = await _LoginRepository.ListAsync();
            return View(UserLogin);
        }
        [HttpPost("Add")]
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
            return RedirectToAction("Index");
        }
    }
}