using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.AboutDto
{
	public class UpdateAboutDto
	{
		public int AboutID { get; set; }
		public string ImageUrl { get; set; }
		public string ImageUrl2 { get; set; }
		public string Title { get; set; }
		public string Title2 { get; set; }
		public string Description1 { get; set; }
		public string Description2 { get; set; }
		public string Description3 { get; set; }
		public string Description_1 { get; set; }
		public string Description_2 { get; set; }
		public string Description_3 { get; set; }
		public bool Status { get; set; }
	}
}
