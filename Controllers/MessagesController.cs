using SocialNetwork.DatabaseContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class MessagesController : Controller
    {
        socialNetworkEntities db = new socialNetworkEntities();
        // GET: Messages
        public ActionResult Index()
        {
            if (Session["currentUserID"] == null || Convert.ToInt32(Session["currentUserID"]) == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            int current_user = Convert.ToInt32(Session["currentUserID"]);
            //var all_friends = db.Friends.Where(x => x.friendOfID == current_user || x.userID == current_user).ToList();   SIR
            //var all_friends = db.Users.ToList();  myyself after sir
            List<User> all_friends = db.Users.Where(x => x.userID != current_user).ToList(); //        MYSELF
            //List<Message> all_friends = db.Messages.ToList(); 
            return View(all_friends);
        }

        public JsonResult SendMessage(Message Message)
        {
            try
            {
                Message.fromUserID = Convert.ToInt32(Session["currentUserID"]);
                //Message.toUserID = Convert.ToInt32(Session["id"]);        MYSELF
                db.Messages.Add(Message);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, msg = ex.Message });
            }
            //save to message table
            return Json(new { Status = true, msg = "Message Sent Successfully" });
        }
        public ActionResult toGEtId(int name)
        {
            Session["id"] = name;
            //return RedirectToAction("Index");
            return View("Index");
        }
        public PartialViewResult ChatHistory(int? userID)
        {
            ViewBag.userID = userID;
            int currentUserID = Convert.ToInt32(Session["currentUserID"]);
            var old_data = db.Messages.Where(x => (x.fromUserID == currentUserID && x.toUserID == userID) || (x.fromUserID == userID && x.toUserID == currentUserID));
            return PartialView(old_data.ToList());
        }

        public ActionResult readID(int id)
        {
            //var data = db.Friends.Where(x => x.friendID == id).ToList();  SIR
            var dataID = db.Users.Where(x => x.userID == id).ToList();
            return View("Index", dataID);
        }
    }
}