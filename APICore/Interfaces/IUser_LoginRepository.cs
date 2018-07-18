using APICore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Interfaces
{
    [Category("用户表接口规范")]
    public interface IUser_LoginRepository
    {
        [Description("根据id参数获取指定数据")]
        Task<User_Login> GetByIdAsync(int id);
        [Description("获取所有表数据")]
        Task<List<User_Login>> ListAsync();
        [Description("添加数据")]
        Task AddAsync(User_Login user_Login);
        [Description("更新数据")]
        Task UpdateAsync(User_Login user_Login);
    }
}
