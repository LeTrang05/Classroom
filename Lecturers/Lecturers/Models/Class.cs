using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecturers.Models
{
    public class Class
    {

        public int ClassId { get; set; }
        
        public string ClassName { get; set; }

        public string ClassMaLop { get; set; }
    }
}