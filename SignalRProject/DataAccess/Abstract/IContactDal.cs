using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IContactDal:IGenericDal<Contact>
	{
		public Contact GetActiveContact();

        public void ChangeStatusToTrue(int id);
        public void ChangeStatusToFalse(int id);
    }
}
