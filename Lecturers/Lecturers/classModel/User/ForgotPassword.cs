using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecturers.classModel
{
    public class ForgotPassword
    {

        [Required(ErrorMessage = "Bạn chưa nhập Email.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Địa chỉ email chưa chính xác.")]
        public string UserEmail { get; set; }
    }
}