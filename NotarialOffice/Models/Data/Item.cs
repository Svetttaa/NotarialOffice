using System.ComponentModel.DataAnnotations;

namespace NotarialOffice.Models.Data
{
	public class Item
	{
		public int Id { get; set; }

		[Display(Name = "Название"), Required]
		public string Title { get; set; }

		[Display(Name = "Описание")]
		public string Description { get; set; }

		[Display(Name = "Тариф"), Required]
		public string Price { get; set; } = string.Empty;

		[Display(Name = "Плата УПТХ"), Required]
		public string UpthPrice { get; set; } = string.Empty;

		[Display(Name = "Плата итого"), Required]
		public string TotalPrice { get; set; } = string.Empty;

		public bool Hidden { get; set; }
	}
}