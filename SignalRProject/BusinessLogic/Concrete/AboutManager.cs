using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
	public class AboutManager:IAboutService
	{
		private readonly IAboutDal _ıaboutdal;

		public AboutManager(IAboutDal ıaboutdal)
		{
			_ıaboutdal = ıaboutdal;
		}

        public void TChangeStatusToFalse(int id)
        {
			_ıaboutdal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
			_ıaboutdal.ChangeStatusToTrue(id);
        }

        public void TDelete(About t)
		{
			_ıaboutdal.Delete(t);
		}

        public List<About> TGetActiveAbout()
        {
            return _ıaboutdal.GetActiveAbout();
        }

        public List<About> TGetAll()
		{
			var listem=_ıaboutdal.GetAll();
			return listem;
		}

		public List<About> TGetAllWithFilter(Expression<Func<About, bool>> filter)
		{
			var listem=_ıaboutdal.GetAllWithFilter(filter);
			return listem;
		}

		public About TGetById(int id)
		{
			var deger=_ıaboutdal.GetById(id);
			return deger;
		}

		public void TInsert(About t)
		{
			_ıaboutdal.Insert(t);
		}

		public void TUpdate(About t)
		{
			_ıaboutdal.Update(t);
		}
	}
}
