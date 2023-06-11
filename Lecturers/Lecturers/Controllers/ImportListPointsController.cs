using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using Lecturers.Models;
using OfficeOpenXml;
using Lecturers.classModel.bieudo;

namespace Lecturers.Controllers
{
    public class ImportListPointsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ImportListPoints
        public ActionResult Index()
        {
            ViewBag.Data = db.ImportListPoint.ToList();
            return View();
        }

        // GET: ImportListPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportListPoint importListPoint = db.ImportListPoint.Find(id);
            if (importListPoint == null)
            {
                return HttpNotFound();
            }
            return View(importListPoint);
        }

        // GET: ImportListPoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImportListPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImportListPoint importListPoint)
        {
            if (ModelState.IsValid)
            {
                db.ImportListPoint.Add(importListPoint);
                db.SaveChanges();
                return RedirectToAction("Indexs");
            }

            return View(importListPoint);
        }

        // GET: ImportListPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportListPoint importListPoint = db.ImportListPoint.Find(id);
            if (importListPoint == null)
            {
                return HttpNotFound();
            }
            return View(importListPoint);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImportListPoint importListPoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(importListPoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Indexs");
            }
            return View(importListPoint);
        }

        // GET: ImportListPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportListPoint importListPoint = db.ImportListPoint.Find(id);
            if (importListPoint == null)
            {
                return HttpNotFound();
            }
            return View(importListPoint);
        }

        // POST: ImportListPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImportListPoint importListPoint = db.ImportListPoint.Find(id);
            db.ImportListPoint.Remove(importListPoint);
            db.SaveChanges();
            return RedirectToAction("Indexs");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Indexs(int? id)
        {
            //User entities = new User();
            ViewBag.Data = db.ImportListPoint.ToList().Where(s => s.IdClass.Equals(id));
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase UploadedFile)
        {
            var usersList = new List<ImportListPoint>();

            if ((UploadedFile != null) && (UploadedFile.ContentLength > 0) && !string.IsNullOrEmpty(UploadedFile.FileName))
            {

                using (ExcelPackage package = new ExcelPackage(UploadedFile.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        var user = new ImportListPoint();
                        user.Id = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                        user.IdClass = (int)Session["idclass"];
                        user.IdStudent = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value);
                        user.StudentName = workSheet.Cells[rowIterator, 4].Value.ToString();
                        user.MyPoints = Convert.ToDouble(workSheet.Cells[rowIterator, 5].Value);
                        usersList.Add(user);
                    }
                }
            }


            // lưu vào database

            foreach (var item in usersList)
            {
                db.ImportListPoint.Add(item);
            }
            int result = db.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("Indexs");
            }

            return View("Indexs");
        }

        [HttpPost]
        public FileResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Id"),
                                            new DataColumn("IdClass"),
                                            new DataColumn("IdStudent"),
                                            new DataColumn("StudentName"),
                                            new DataColumn("MyPoints")});

            var customers = from user in db.ImportListPoint.ToList()
                            select user;

            foreach (var customer in customers)
            {
                if (customer.IdClass == (int)Session["idclass"])
                {
                    dt.Rows.Add(customer.Id, customer.IdClass, customer.IdStudent, customer.StudentName, customer.MyPoints);
                }
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }

       
        public ActionResult bieudodiem()
        {
            List<object> data = new List<object>();
            List<string> labels = db.ImportListPoint.Select(p => p.StudentName).ToList();
            data.Add(labels);
            List<double> diemnumber = db.ImportListPoint.Select(p => p.MyPoints).ToList();
            data.Add(diemnumber);
            double[] myPointed = diemnumber.ToArray();
            ViewBag.mydata = myPointed;

            return View() ;
        }

        
        public ActionResult bieudodiems(int? id)
        {

            List<double> diemnumber = db.ImportListPoint.Select(p => p.MyPoints).ToList();
            double[] myPointed = diemnumber.ToArray();
            ViewBag.mydata = myPointed;

            bieudo query = new bieudo();

            query.gioi = db.ImportListPoint.Where(s => (s.MyPoints >= 9 && s.IdClass==id)).Count();
            query.kha = db.ImportListPoint.Where(s => (s.MyPoints >= 7 && s.MyPoints < 9 && s.IdClass == id)).Count();
            query.trungbinh = db.ImportListPoint.Where(s => (s.MyPoints >= 5 && s.MyPoints < 7 && s.IdClass == id)).Count();
            query.yeu = db.ImportListPoint.Where(s => (s.MyPoints < 5 && s.IdClass == id)).Count();
            ViewBag.databieudo = query;

            return View();




        }
    }
}
