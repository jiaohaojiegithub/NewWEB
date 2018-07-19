using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace APICore.Controllers
{
    /// <summary>
    /// 初始API参考
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("any")]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <remarks>备注：返回[ "value1", "value2" ]</remarks>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 获取指定ID的数据
        /// </summary>
        /// <param name="id">测试ID</param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //添加对控制器方法的说明1
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
