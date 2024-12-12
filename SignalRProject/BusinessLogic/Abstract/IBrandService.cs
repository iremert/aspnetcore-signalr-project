using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
	public interface IBrandService:IGenericService<Brand>
	{
        public int TBrandCount();
        public int TActiveBrandCount();
        public int TPassiveBrandCount();

        public List<Brand> TActiveBrandList();
        public void TChangeStatusToTrue(int id);
        public void TChangeStatusToFalse(int id);
    }
}
