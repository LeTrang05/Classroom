using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecturers.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int Idclass { get; set; }
        public int idContentClass { get; set; }
        public string userName { get; set; }
        public string comment { get; set; }
    }
}