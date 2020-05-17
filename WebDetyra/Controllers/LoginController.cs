using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDetyra.Models;

namespace WebDetyra.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(WebDetyra.Models.Useri userModel)
        {
            using (Entities db = new Entities())
            {
                var userTeDhenat = db.Useris.Where(x => x.EmailUserit == userModel.EmailUserit && x.PasswordUserit == userModel.PasswordUserit).FirstOrDefault();
                if (userTeDhenat == null)
                {
                    userModel.LoginErrorMessage = "Email ose Password gabim.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userTeDhenat.UserID;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}