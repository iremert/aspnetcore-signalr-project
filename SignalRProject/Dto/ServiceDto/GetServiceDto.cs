﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ServiceDto
{
	public class GetServiceDto
	{
		public int ServiceID { get; set; }
		public string Title { get; set; }
		public string Icon { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
	}
}
