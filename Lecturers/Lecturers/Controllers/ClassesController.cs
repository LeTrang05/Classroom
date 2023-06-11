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
using Lecturers.Controllers;
using Microsoft.AspNet.Identity;


namespace Lecturers.Controllers
{
    public class ClassesController : Controller
    {
        private DBContext db = new DBContext();
        

        [HttpGet]
        public ActionResult loginClass()
        {

            return View();
        }

        [HttpPost]
        public ActionResult loginClass(LoginClass classed)
        {
            if (ModelState.IsValid)
            {
                var student = db.Students.Find(1);

                var obj = db.Classed.AsEnumerable().FirstOrDefault(a => a.ClassMaLop.Equals(classed.maLop));



                if (obj != null)
                {
                    ViewBag.id = TempData["id"];
                   
                    ClassANDStudent newClass = new ClassANDStudent()
                    {
                        IdClass = obj.ClassId,
                        IdStudent = ViewBag.id,
                        

                    };
                    var obj_item = db.ClassANDStudents.Where(s => s.IdClass == newClass.IdClass && s.IdStudent == newClass.IdStudent);
                    if(obj_item == null)
                    {
                        db.ClassANDStudents.Add(newClass);
                        db.SaveChanges();
                    }
                    
                    Session["idclass"] = newClass.IdClass;
                    Session["ma_lop"] = classed.maLop;
                    return RedirectPermanent("~/Classes/MyClass/" + newClass.IdClass);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lớp học không tồn tại");
                    return View();
                }
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult CreateClass()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateClass(CreateClass classed)
        {

            if (ModelState.IsValid)
            {
                
                var obj = db.Classed.AsEnumerable().FirstOrDefault(a => a.ClassMaLop.Equals(classed.ClassMaLop));
                if (obj == null)
                {
                    var userId = Session["id"];
                    ViewBag.id = userId;
                    
                    Class newClass = new Class
                    {
                        ClassMaLop = classed.ClassMaLop,
                        ClassName = classed.ClassName,
                        TeacherMyClass = ViewBag.id
                    };
                    db.Classed.Add(newClass);
                    db.SaveChanges();
                    var objs = db.Classed.AsEnumerable().FirstOrDefault(a => a.ClassMaLop.Equals(classed.ClassMaLop));
                    var ids = objs.ClassId;
                    Session["idclass"] = ids;

                    return RedirectPermanent("~/Classes/MyClass/" + ids);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lớp học này đã tồn tại");
                    return View(classed);
                }
            }
            return View();
        }
        

        
        public ActionResult IndexClassStudent()
        {
            
           ViewBag.classs =  from s in db.Classed
                        join m in db.ClassANDStudents on s.ClassId equals m.IdClass
                        where s.ClassId.Equals(m.IdClass)
                        select s;
            
            return View();
        }


        public ActionResult MyClass(int? id) {
            ViewBag.IdClass = id;
            Session["id_class"] = id;


            Session["class_layout"] = db.Classed.ToList().Where(s => s.ClassId.Equals(id));
            ViewBag.content = db.ContentClasses.ToList().Where(s => s.IdClass.Equals(id));

            ViewBag.comment = db.Comment.ToList().Where(s => s.Idclass.Equals(id));
            return View(db.Classed.ToList().Where(s => s.ClassId.Equals(id)));
            
        }
       
        public ActionResult IndexClassTeacher()
        {
            return View(db.Classed.ToList().Where(s => s.TeacherMyClass.Equals(TempData["id"])));
            //

        }

        [HttpGet]
        public ActionResult Tinmoi()
        {

            return View();
        }

        public ActionResult getNameClass(int id)
        {
            Session["Name_class"] = db.Classed.ToList().Where(s => s.ClassId.Equals(id));
            return View(Session["Name_class"]);
        }


    }
        
}
