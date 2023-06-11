using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lecturers.Models;

namespace Lecturers.classModel.Class
{
    public class CreateClass
    {
        public int ClassId { get; set; }

        public int TeacherMyClass { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập trường này")]
        public string ClassName { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập trường này")]
        public string ClassMaLop { get; set; }
        
    }
}