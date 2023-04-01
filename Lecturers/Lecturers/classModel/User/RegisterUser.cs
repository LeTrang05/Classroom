using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Lecturers.classModel
{
    public class RegisterUser
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập trường này.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Địa chỉ email chưa chính xác.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Mật khẩu có cả chữ số và ít nhất 1 chữ hoa hoặc ký tự đặc biệt.")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn trường này.")]
        public string UserPosition { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trường này")]
        [Compare("UserPassword", ErrorMessage = "Mật khẩu xác thực chưa chính xác.")]
        public string ComfirmPassword { get; set; }
    }
}