using System.Web;
using System.Web.Mvc;
using NotarialOffice.Helpers;

namespace NotarialOffice
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new ExceptionHandler());
		}
	}
}
