using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewWEBAPI.Models
{
    [Category("用户表")]
    public class User_Login
    {
        [Description("User_Login_ID 主键 ID标识 数值递增")]
        public int User_Login_ID { get; set; }
        [Description("User_Login_Name 用户名")]
        public string User_Login_Name { get; set; }
        [Description("User_Login_EmailAddress 邮箱地址 扩展登录用户")]
        [DataType(DataType.EmailAddress)]
        public string User_Login_EmailAddress { get; set; }
        [Description("User_Login_PassWord 用户密码")]
        public string User_Login_PassWord { get; set; }
        [Description("User_Login_Sex 性别(男，女)")]
        public string User_Login_Sex { get; set; }
        [Description("User_Login_Right 权限(管理员OR普通用户)")]
        public int User_Login_Right { get; set; }
        [Description("User_Login_State 用户状态(0为假 离线，1为真 在线)")]
        public bool User_Login_State { get; set; }
        [Description("User_Login_Guid 唯一标识 数值随机")]
        public Guid User_Login_Guid { get; set; }
        [Description("User_Login_CreatDT 创建时间")]
        public DateTime User_Login_CreatDT { get; set; }

    }
}
