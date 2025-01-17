﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IAboutDal:IGenericDal<About>
	{
		public List<About> GetActiveAbout();

		public void ChangeStatusToTrue(int id);
		public void ChangeStatusToFalse(int id);
	}
}
