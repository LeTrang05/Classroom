using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lecturers.classModel
{
    
    public class Login
    {
        [Required]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Email.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Địa chỉ email chưa chính xác.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Mật khẩu có cả chữ số và ít nhất 1 chữ hoa hoặc ký tự đặc biệt.")]
        public string UserPassword { get; set; }

        

    }

}