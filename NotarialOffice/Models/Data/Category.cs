using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotarialOffice.Models.Data
{
	public class Category
	{
		public int ID { get; set; }
		[Display(Name = "Название"), Required] public string Name { get; set; }
		public bool Hidden { get; set; }
		public ICollection<Item> Items { get; set; }
	}
}