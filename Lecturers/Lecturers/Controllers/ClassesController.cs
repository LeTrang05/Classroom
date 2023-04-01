using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Lecturers.classModel.Class;
using Lecturers.Models;


namespace Lecturers.Controllers
{
    public class ClassesController : Controller
    {
        private DBContext db = new DBContext();


        public ActionResult loginClass(LoginClass classed)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Classed.AsEnumerable().FirstOrDefault(a => a.ClassMaLop.Equals(classed.maLop));
                if (obj != null)
                {
                    return RedirectPermanent("~/Users/Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lớp học không tồn tại");
                    return View();
                }
            }
            return View();
            
        }

        public ActionResult CreateClass(CreateClass classed)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Classed.AsEnumerable().FirstOrDefault(a => a.ClassMaLop.Equals(classed.ClassMaLop));
                if (obj == null)
                {
                    Class newClass = new Class()
                    {
                        ClassId = ViewBag.UserId,
                        ClassMaLop = classed.ClassMaLop,
                        ClassName = classed.ClassName
                    };
                    db.Classed.Add(newClass);
                    db.SaveChanges();
                    return RedirectPermanent("~/Users/Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lớp học này đã tồn tại");
                    return View();
                }
            }
            return View();
        }

        public ActionResult MyClass() {
            return View(db.Classed.ToList());

        }

    }
        
}
