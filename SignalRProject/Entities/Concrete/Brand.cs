﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Brand
	{
		public int BrandId { get; set; }
		public string Url { get; set; }
		public string BrandName { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
		public ICollection<Car> Cars { get; set; }
	}
}
