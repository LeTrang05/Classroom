using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecturers.classModel.Class
{
    public class LoginClass
    {
        [Required(ErrorMessage ="Bạn chưa nhập trường này.")]
        public string maLop { get; set; }

    }
}