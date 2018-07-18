using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBModels
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class DBUser_Login
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名")]
        //[RegularExpression(@"^[A-Za-z0-9\u4e00-\u9fa5]+$", ErrorMessage = "用户名只能由数字,汉字,字母组成")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "用户名必须为{2}到{1}个字符")]
        public string User_Login_Name { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        [DataType(DataType.EmailAddress, ErrorMessage = "请输入正确的电子邮件地址")]
        public string User_Login_EmailAddress { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "为了您的账户安全，请设置密码")]
        [Display(Name = "密码")]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "密码必须为{2}到18个字符")]
        [DataType(DataType.Password)]
        public string User_Login_PassWord { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [RegularExpression(@"^([男|女]){1}$",ErrorMessage ="性别只能输入男|女")]
        public string User_Login_Sex { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        [Required]
        public int User_Login_Right { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        [Display(Name = "状态")]
        public bool User_Login_State { get; set; }
    }
}
