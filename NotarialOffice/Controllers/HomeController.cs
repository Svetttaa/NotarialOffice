using System;
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
			ViewBag.Categories = _db.Categories.ToArray();

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

		[Route("Catalog")]
		public ActionResult Catalog(int selectedCategory = 0)
		{
			ViewBag.SelectedCategory = selectedCategory;
			return View(_db.Categories.OrderBy(x => x.Hidden));
		}

		public ActionResult CatalogPartial()
		{
			// return PartialView("CatalogPartial",_db.Categories.OrderBy(x => x.Hidden));
			return PartialView(_db.Categories.Any() ? _db.Categories.OrderBy(x => x.Hidden).ToArray() : new Models.Data.Category[0]);
		}

		public ActionResult ItemsInCategoryPartial(int id)
		{
			ViewBag.Name = _db.Categories.First(x => x.ID == id).Title;

			return PartialView(_db.Items.Where(i => i.CategoryID == id).OrderBy(x => x.Hidden));
		}

		public ActionResult Item(int id = 1, bool isPartial = false)
		{
			if (_db.Items.First(i => i.ID == id).Hidden && !User.IsInRole("Admin"))
				return View("Error");

			if (User.Identity.IsAuthenticated)
			{
				string user = User.Identity.GetUserId();
				//ViewBag.AlreadyInCart = _db.UserCarts.Any(x => x.UserID == user && x.ItemID == id);
			}

			var model = _db.Items.First(i => i.ID == id);

			if (isPartial)
				return PartialView(model);
			else
				return View(model);
		}
	}
}