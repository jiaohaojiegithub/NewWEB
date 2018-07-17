using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWEBAPI.Middleware
{
    public class ApiAuthorizedOptions
    {
        public string Name { get; set; }
        /// <summary>
        /// EncryptKey ，用于对我们的请求参数进行签名
        /// </summary>
        public string EncryptKey { get; set; }
        /// <summary>
        /// ExpiredSecond ，用于检验我们的请求是否超时
        /// </summary>
        public int ExpiredSecond { get; set; }
    }
}
