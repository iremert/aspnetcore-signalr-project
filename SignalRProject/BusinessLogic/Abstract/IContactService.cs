using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
	public interface IContactService:IGenericService<Contact>
	{
		public Contact GetActiveContact();

        public void TChangeStatus2ToTrue(int id);
        public void TChangeStatus2ToFalse(int id);
    }
}
