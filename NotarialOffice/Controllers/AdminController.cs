using System.Linq;
using System.Web.Mvc;
using NotarialOffice.Models;
using NotarialOffice.Models.Data;

namespace NotarialOffice.Controllers
{
	public class AdminController : Controller
	{
		private readonly ApplicationDbContext _db = new ApplicationDbContext();

		// GET: Admin
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult AddNews()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddNews(News news)
		{
			var id = _db.News.Add(news).Id;
			_db.SaveChanges();

			return RedirectToAction("", "News", new { id });
		}

		[HttpGet]
		public ActionResult EditNews()
		{
			return View();
		}

		[HttpPost]
		public ActionResult EditNews(News news)
		{
			var entity = _db.News.Find(news.Id);
			if (entity == null)
			{
				return null;
			}

			_db.Entry(entity).CurrentValues.SetValues(news);
			_db.SaveChanges();

			return RedirectToAction("", "News", new { news.Id });
		}

		[HttpGet]
		public ActionResult DeleteNews(int id)
		{
			_db.News.Remove(_db.News.First(x => x.Id == id));
			_db.SaveChanges();

			return RedirectToAction("", "News");
		}
	}
}