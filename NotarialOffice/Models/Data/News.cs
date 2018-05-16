using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotarialOffice.Models.Data
{
	public class News
	{
		public int ID { get; set; }
		[Display(Name = "ФИО"), Required] public string Name { get; set; }
		[Display(Name = "Описние"), Required] public string Description { get; set; }
		public DateTime Date { get; set; }
	}
}