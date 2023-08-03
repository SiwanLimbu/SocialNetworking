using SocialNetwork.DatabaseContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        socialNetworkEntities db = new socialNetworkEntities();
        public ActionResult Index()
        {
            List<Post> all_data = db.Posts.ToList();
            return View(all_data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult addPost(string postCaption, int posterID, string posterName, HttpPostedFileBase selectedImg, Post postImg1)
        //public ActionResult addPost(string postCaption, HttpPostedFileBase selectedImg)
        {
            string path = Server.MapPath("~/Uploads");
            string file_name = selectedImg.FileName;
            string new_path = path + "/" + file_name;
            //if (Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            //string file_name = Path.GetFileName(selectedImg.FileName);
            //string new_path = Server.MapPath("~/Uploads/" + file_name);
            selectedImg.SaveAs(new_path);

            postImg1.postImg = "~/Uploads/" + file_name;
            Post value = new Post();
            value.postImg = postImg1.postImg;
            value.postCaption = postCaption;
            value.posterID = posterID;
            value.posterName = posterName;
            db.Posts.Add(value);
            //db.Posts.Add(postImg1);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
            
        }
    }
}