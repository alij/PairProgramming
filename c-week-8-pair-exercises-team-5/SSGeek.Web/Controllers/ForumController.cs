using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class ForumController : Controller
    {
        private ForumPostSqlDAL forumPostSqlDAL;

        public ForumController(ForumPostSqlDAL forumPostSqlDAL)
        {
            this.forumPostSqlDAL = forumPostSqlDAL;
        }

        public IActionResult Index()
        {
            List<ForumPost> forumPosts = forumPostSqlDAL.GetAllPosts();

            return View(forumPosts);

        }

        [HttpGet]
        public IActionResult NewPost()
        {
            ForumPost forumPost = new ForumPost();

            return View(forumPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewPost(ForumPost forumPost)
        {
            if (!ModelState.IsValid)
            {
                return View("NewPost");
            }

            TempData["Message"] = "Your message has been saved.";

            forumPostSqlDAL.SaveNewPost(forumPost);

            return RedirectToAction("");
        }
    }
}