using System.Linq;
using System.Web.Mvc;
using NotarialOffice.Models;
using NotarialOffice.Models.Data;

namespace NotarialOffice.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly ApplicationDbContext _db = new ApplicationDbContext();

		#region News

		[HttpGet, Route("News/Add")]
		public ActionResult AddNews()
		{
			return View();
		}

		[HttpPost, Route("News/Add")]
		public ActionResult AddNews(News news)
		{
			var id = _db.News.Add(news).Id;
			_db.SaveChanges();

			return RedirectToAction("", "News");
		}

		[HttpGet, Route("News/{id}/Edit")]
		public ActionResult EditNews(int id)
		{
			return View(_db.News.First(x => x.Id == id));
		}

		[HttpPost, Route("News/{id}/Edit")]
		public ActionResult EditNews(News news)
		{
			var newsInDb = _db.News.First(x => x.Id == news.Id);
			newsInDb.Title = news.Title;
			newsInDb.Description = news.Description;
			_db.SaveChanges();

			return RedirectToAction("", "News");
		}

		[HttpGet]
		public void DeleteNews(int id)
		{
			_db.News.Remove(_db.News.First(x => x.Id == id));
			_db.SaveChanges();
		}

		#endregion

		#region Services

		[HttpGet, Route("Catalog/Add")]
		public ActionResult AddService()
		{
			return View();
		}

		[HttpPost, Route("Catalog/Add")]
		public ActionResult AddService(Item item)
		{
			_db.Items.Add(item);
			_db.SaveChanges();

			return RedirectToAction("", "Catalog");
		}

		[HttpGet, Route("Catalog/{id}/Edit")]
		public ActionResult EditService(int id)
		{
			return View(_db.Items.First(x => x.Id == id));
		}

		[HttpPost, Route("Catalog/{id}/Edit")]
		public ActionResult EditService(Item item)
		{
			var itemInDb = _db.Items.First(x => x.Id == item.Id);
			itemInDb.Title = item.Title;
			itemInDb.Price = item.Price;
			itemInDb.UpthPrice = item.UpthPrice;
			itemInDb.TotalPrice = item.TotalPrice;

			_db.SaveChanges();

			return RedirectToAction("", "Catalog");
		}

		[HttpGet]
		public void DeleteService(int id)
		{
			_db.Items.Remove(_db.Items.First(x => x.Id == id));
			_db.SaveChanges();
		}

		#endregion
	}
}