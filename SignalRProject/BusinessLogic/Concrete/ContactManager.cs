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
	public class ContactManager:IContactService
	{
		private readonly IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

        public Contact GetActiveContact()
        {
           return _contactDal.GetActiveContact();
        }

        public void TChangeStatus2ToFalse(int id)
        {
            _contactDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatus2ToTrue(int id)
        {
            _contactDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Contact t)
		{
			_contactDal.Delete(t);
		}

		public List<Contact> TGetAll()
		{
			var liste=_contactDal.GetAll();
			return liste;
		}

		public List<Contact> TGetAllWithFilter(Expression<Func<Contact, bool>> filter)
		{
			var liste=_contactDal.GetAllWithFilter(filter);
			return liste;
		}

		public Contact TGetById(int id)
		{
			var deger=_contactDal.GetById(id);
			return deger;
		}

		public void TInsert(Contact t)
		{
			_contactDal.Insert(t);
		}

		public void TUpdate(Contact t)
		{
			_contactDal.Update(t);
		}
	}
}
