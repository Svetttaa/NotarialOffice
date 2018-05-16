using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotarialOffice.Models.Data
{
	public class Item
	{
		public int ID { get; set; }

		[Display(Name = "Название"), Required] public string Title { get; set; }
		[Display(Name = "Описание")] public string Description { get; set; }
		[Display(Name = "Цена"), Required] public double Price { get; set; }
		public bool Hidden { get; set; }
		[Display(Name = "Категория")] public int CategoryID { get; set; }
		[ForeignKey("CategoryID")] public Category Category { get; set; }
	}
}