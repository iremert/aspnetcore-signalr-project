using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private  readonly SignalRContext _context;

		public GenericRepository(SignalRContext context)
		{
			_context = context;
		}

		public void Delete(T t)
		{
			_context.Remove(t);
			_context.SaveChanges();	
		}

		public List<T> GetAll()
		{
			var liste=_context.Set<T>().ToList();
			return liste;
		}

		public List<T> GetAllWithFilter(Expression<Func<T, bool>> filter)
		{
			var liste=_context.Set<T>().Where(filter).ToList();
			return liste;
		}

		public T GetById(int id)
		{
			var deger=_context.Set<T>().Find(id);
			return deger;
		}

		public void Insert(T t)
		{
			_context.Add(t);
			_context.SaveChanges();
		}

		public void Update(T t)
		{
			_context.Update(t);
			_context.SaveChanges();
		}
	}
}
