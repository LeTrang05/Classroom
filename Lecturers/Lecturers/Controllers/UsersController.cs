using System.Data;
using System.Linq;
using System.Web.Mvc;
using Lecturers.Models;
using Lecturers.classModel;

namespace Lecturers.Controllers
{
    public class UsersController : Controller
    {
        private DBContext db = new DBContext();

        [HttpGet]
        public ActionResult home()
        {
            return View();
        }


        [HttpGet]
        public ActionResult homemaster()
        {
            ViewBag.users = TempData["data"];
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Login loginUser)
        {
            if (ModelState.IsValid)
            {
                var data = db.Users.AsEnumerable().FirstOrDefault(a => a.UserEmail.Equals(loginUser.UserEmail) && a.UserPassword.Equals(loginUser.UserPassword));
                if (data != null)
                {
                    TempData["data"] = data.UserPosition;
                    TempData["id"] = data.UserID;
                    Session["id"] = data.UserID;
                    Session["user"] = data.UserName;
                    return RedirectPermanent("~/Users/homemaster");
                    
                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "UserName hoặc Password chưa chính xác.");
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
             return View();
        }

      
        [HttpGet]
        public ActionResult Registers()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registermater()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registers(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                using (DBContext db = new DBContext())
                {
                    
                    var obj = db.Users.AsEnumerable().FirstOrDefault(a => a.UserEmail.Equals(user.UserEmail));
                    if (obj == null)
                    {
                        User newUser = new User()
                        {
                            UserName = user.UserName,
                            UserEmail = user.UserEmail,
                            UserPassword = user.UserPassword,
                            UserPosition = user.UserPosition
                        };

                        db.Users.Add(newUser);
                        db.SaveChanges();
                        
                        return RedirectPermanent("~/Users/Registermater");
                           
                    }
                    else { 

                        ModelState.AddModelError(string.Empty, "Tài khoản đã tồn tại.");
                        return View(user);
                    }
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult FogotPassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult FogotPassword(ForgotPassword email)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Users.AsEnumerable().FirstOrDefault(a => a.UserEmail.Equals(email.UserEmail));
                if (obj == null)
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản này chưa tồn tại.");
                    return RedirectPermanent("~/Users/ForgotPassword");
                }
                else
                {
                    return RedirectPermanent("~/Users/Login");
                }
            }
            return View();
        }


        
        

        

    }
}
