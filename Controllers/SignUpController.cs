using SocialNetwork.DatabaseContent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class SignUpController : Controller
    {
        socialNetworkEntities db = new socialNetworkEntities();
        // GET: SignUp
        public ActionResult Index()
        {
            List<User> all_data = db.Users.ToList();
            return View(all_data);
        }

        public ActionResult AddUser(string userFirstName, string userLastName, string userUserName, string userPassword, string userDOB, int userPhone, string userEmail, string userGender, string userCity, string userState, string userCountry, HttpPostedFileBase selectedImg, User userImg1)
        {
            //string file_name = System.IO.Path.GetFileName(selectedImg.FileName);
            //string new_path = Server.MapPath("~/Uploads/" + file_name);
            string path = Server.MapPath("~/Uploads");
            string file_name = selectedImg.FileName;
            string new_path = path + "/" + file_name;
            //if (Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            selectedImg.SaveAs(new_path);

            userImg1.userPhoto = "~/Uploads/" + file_name;
            User value = new User();
            value.userPhoto = userImg1.userPhoto;
            value.userFirstName = userFirstName;
            value.userLastName = userLastName;
            value.userUserName = userUserName;
            value.userPassword = userPassword;
            value.userEmail = userEmail;
            value.userDOB = userDOB;
            value.userGender = userGender;
            value.userPhone = userPhone;
            value.userCity = userCity;
            value.userState = userState;
            value.userCountry = userCountry;
            Session["currentUserName"] = userUserName;
            db.Users.Add(value);
            //db.Users.Add(userImg);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}