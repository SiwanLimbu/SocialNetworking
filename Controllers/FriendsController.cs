using SocialNetwork.DatabaseContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class FriendsController : Controller
    {
        socialNetworkEntities db = new socialNetworkEntities();
        // GET: Friends
        public ActionResult Index()
        {
            List<User> all_data = db.Users.ToList();
            return View(all_data);
        }
    }
}