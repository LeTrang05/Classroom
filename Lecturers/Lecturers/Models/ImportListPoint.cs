using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecturers.Models
{
    public class ImportListPoint
    {
        public int Id { get; set; }
        public int IdClass { get; set; }
        public int IdStudent { get; set; }
        public string StudentName { get; set; }
        public double MyPoints { get; set; }
    }
}