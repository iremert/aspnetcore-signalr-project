using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IServiceDal:IGenericDal<Service>
	{
		public List<Service> GetActiveService();

        public void ChangeStatusToTrue(int id);
        public void ChangeStatusToFalse(int id);
    }
}
