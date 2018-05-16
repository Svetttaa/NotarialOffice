using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotarialOffice.Models.Data
{
	public class Request
	{
		public int ID { get; set; }
		[Display(Name = "ФИО"), Required] public string Name { get; set; }
		[Display(Name = "Телефон"), Required] public string Phone { get; set; }

	}
}