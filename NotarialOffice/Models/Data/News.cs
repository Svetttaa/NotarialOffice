using System;
using System.ComponentModel.DataAnnotations;

namespace NotarialOffice.Models.Data
{
	public class News
	{
		public int Id { get; set; }
		[Display(Name = "Заголовок"), Required] public string Title { get; set; }
		[Display(Name = "Описние"), Required] public string Description { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
	}
}