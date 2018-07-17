using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewWEBAPI.Interfaces;

namespace NewWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUser_LoginRepository _LoginRepository;
        //创建日志
        private readonly ILogger _logger;
        public ValuesController(IUser_LoginRepository loginRepository, ILogger<ValuesController> logger)
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
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
