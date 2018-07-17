using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModels
{
    public class DBUser_Login
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名")]
        //[RegularExpression(@"^[A-Za-z0-9\u4e00-\u9fa5]+$", ErrorMessage = "用户名只能由数字,汉字,字母组成")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "用户名必须为{2}到{1}个字符")]
        public string User_Login_Name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "请输入正确的电子邮件地址")]
        public string User_Login_EmailAddress { get; set; }
        [Required(ErrorMessage = "为了您的账户安全，请设置密码")]
        [Display(Name = "密码")]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "密码必须为{2}到18个字符")]
        [DataType(DataType.Password)]
        public string User_Login_PassWord { get; set; }
        public string User_Login_Sex { get; set; }
        [Required]
        public int User_Login_Right { get; set; }
        [Required]
        [Display(Name = "状态")]
        public bool User_Login_State { get; set; }
    }
}
