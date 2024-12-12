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
	public class ServiceManager:IServiceService
	{
		private readonly IServiceDal _serviceDal;

		public ServiceManager(IServiceDal serviceDal)
		{
			_serviceDal = serviceDal;
		}

        public List<Service> GetActiveService()
        {
            return _serviceDal.GetActiveService();	
        }

        public void TChangeStatusToFalse(int id)
        {
			_serviceDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
			_serviceDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Service t)
		{
			_serviceDal.Delete(t);	
		}

		public List<Service> TGetAll()
		{
			var listem=_serviceDal.GetAll();	
			return listem;
		}

		public List<Service> TGetAllWithFilter(Expression<Func<Service, bool>> filter)
		{
			var listem=_serviceDal.GetAllWithFilter(filter);	
			return listem;	
		}

		public Service TGetById(int id)
		{
			var liste=_serviceDal.GetById(id);
			return liste;
		}

		public void TInsert(Service t)
		{
			_serviceDal.Insert(t);
		}

		public void TUpdate(Service t)
		{
			_serviceDal.Update(t);
		}
	}
}
