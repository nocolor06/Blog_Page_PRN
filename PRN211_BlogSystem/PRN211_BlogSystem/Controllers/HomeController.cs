﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN211_BlogSystem.Models;

namespace PRN211_BlogSystem.Controllers
{
	public class HomeController : Controller
	{
		// GET: HomeController
		public ActionResult HomePage()
		{
			using (PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
			{
				var blogs = context.Blogs.ToList();
				ViewBag.blogs = blogs;
				var blogsFive= context.Blogs
					.OrderBy(b => b.NoView)
					.Take(5)
					.Include(b => b.AuthorNameNavigation)
                    .Include(b => b.Category)
                    .ToList();
				ViewBag.blogsFive = blogsFive;
				var blogsThree = context.Blogs
					.OrderBy(b => b.NoView)
					.Take(3)
                    .Include(b => b.AuthorNameNavigation)
                    .Include(b => b.Category)
                    .ToList();
				ViewBag.blogsThree = blogsThree;

				var categories = context.Categories.ToList();
				ViewBag.categories = categories;
			}
			return View();
		}

        public ActionResult NotFound()
        {
            return View();
        }



    }
}
