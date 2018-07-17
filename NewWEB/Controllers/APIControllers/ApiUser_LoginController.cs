using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewWEB.Areas.Identity.Interfaces;

namespace NewWEB.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUser_LoginController : ControllerBase
    {
        private readonly IUser_LoginRepository _LoginRepository;
        //创建日志
        private readonly ILogger _logger;
        public ApiUser_LoginController(IUser_LoginRepository loginRepository,ILogger<ApiUser_LoginController> logger)
        {
            _LoginRepository = loginRepository;
            _logger = logger;
        }
        //Get api/ApiUser_Login
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userLogin = await _LoginRepository.ListAsync();
            return Ok(userLogin);
        }
    }
}