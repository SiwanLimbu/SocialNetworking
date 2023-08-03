using SocialNetwork.DatabaseContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class LoginController : Controller
    {
        socialNetworkEntities db = new socialNetworkEntities();
        // GET: Login
        public ActionResult Index()
        {
            //Session["currentUserID"] = 1;
            return View();
        }

        public ActionResult checkID(int userID, string userUserName, string userPassword)
        {
            var cuID = userID;
            var cuUserName = userUserName;
            var countId = db.Users.Where(x => x.userID == userID);
            var countPassword = db.Users.Where(x => x.userPassword == userPassword);
            if (countId.Count()==0 || countPassword.Count()==0)
            {
                Session["error1"] = "false";
                return RedirectToAction("Index", "Login");
            }
            Session["currentUserID"] = cuID;
            Session["currentUserName"] = cuUserName;
            return RedirectToAction("Index", "Home");
        }
    }
}