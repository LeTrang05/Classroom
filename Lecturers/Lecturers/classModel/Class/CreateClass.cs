using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecturers.classModel.Class
{
    public class CreateClass
    {
        public int TeacherId { get; set; }
        [Required(ErrorMessage ="Bạn chưa nhập trường này")]
        public string ClassName { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập trường này")]
        public string ClassMaLop { get; set; }
    }
}