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
	public class Contact2Manager:IContact2Service
	{
		private readonly IContact2Dal _contact2Dal;

		public Contact2Manager(IContact2Dal contact2Dal)
		{
			_contact2Dal = contact2Dal;
		}

        public List<Contact2> GetActiveContact2()
        {
			return _contact2Dal.GetActiveContact2();
        }

        public void TChangeStatusToFalse(int id)
        {
			_contact2Dal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
			_contact2Dal.ChangeStatusToTrue(id);
        }

        public void TDelete(Contact2 t)
		{
			_contact2Dal.Delete(t);	
		}

		public List<Contact2> TGetAll()
		{
			var liste=_contact2Dal.GetAll();
			return liste;
		}

		public List<Contact2> TGetAllWithFilter(Expression<Func<Contact2, bool>> filter)
		{
			var liste = _contact2Dal.GetAllWithFilter(filter);
			return liste;
		}

		public Contact2 TGetById(int id)
		{
			var deger=_contact2Dal.GetById(id);
			return deger;
		}

		public void TInsert(Contact2 t)
		{
			_contact2Dal.Insert(t);
		}

		public void TUpdate(Contact2 t)
		{
			_contact2Dal.Update(t);
		}
	}
}
