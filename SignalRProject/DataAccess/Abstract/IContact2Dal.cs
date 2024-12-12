using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IContact2Dal:IGenericDal<Contact2>
	{
		public List<Contact2> GetActiveContact2();


        public void ChangeStatusToTrue(int id);
        public void ChangeStatusToFalse(int id);
    }
}
