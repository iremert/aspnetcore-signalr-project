using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
	public interface IAboutService:IGenericService<About>
	{
        public List<About> TGetActiveAbout();


        public void TChangeStatusToTrue(int id);
        public void TChangeStatusToFalse(int id);
    }
}
