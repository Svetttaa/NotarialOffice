﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NotarialOffice.Models;

namespace NotarialOffice.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _db = new ApplicationDbContext();

		public ActionResult Index()
		{
			ViewBag.LastNews = _db.News.Any() 
				                   ? _db.News.OrderByDescending(x => x.Date).First() 
				                   : null;

			return View();
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

		[HttpGet, Route("Catalog")]
		public ActionResult Catalog()
		{
			return View(_db.Items.ToArray());
		}

		[HttpGet, Route("News")]
		public ActionResult News()
		{
			return View(_db.News.OrderByDescending(x => x.Date).ToArray());
		}
	}
}