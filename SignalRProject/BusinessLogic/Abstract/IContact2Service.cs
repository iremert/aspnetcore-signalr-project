using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
	public interface IContact2Service:IGenericService<Contact2>
	{
		public List<Contact2> GetActiveContact2();

        public void TChangeStatusToTrue(int id);
        public void TChangeStatusToFalse(int id);
    }
}
