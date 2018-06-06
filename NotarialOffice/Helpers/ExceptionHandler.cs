using System;
using System.Net;
using System.Text;
using System.Web.Mvc;
using NLog;

namespace NotarialOffice.Helpers
{

	public class ExceptionHandler : Controller
	{
		private static Logger _logger = LogManager.GetCurrentClassLogger();

		protected override void OnException(ExceptionContext context)
		{
			var sb = new StringBuilder();

			if (context.Exception is AggregateException exception)
			{
				sb.Append("Inner exceptions:\r\n");

				foreach (var exc in exception.Flatten().InnerExceptions)
				{
					sb.Append(exc + "\r\n");
				}
			}
			else
			{
				sb.Append($"Exception message: {context.Exception}");
			}

			_logger.Error(sb.ToString());

			if (context.HttpContext.Request.IsAjaxRequest() && context.Exception != null)
			{
				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				context.Result = new JsonResult
				{
					JsonRequestBehavior = JsonRequestBehavior.AllowGet,
					Data = new
					{
						Message = context.Exception.GetAllMessages(),
					}
				};
			}
			else
			{
				context.Result = new ViewResult
				{
					ViewName = "~/Views/Shared/Error.cshtml"
				};
			}

			context.ExceptionHandled = true;
		}
	}

}