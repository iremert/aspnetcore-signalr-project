using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.BrandDto
{
	public class GetBrandDto
	{
		public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Url { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
	}
}
