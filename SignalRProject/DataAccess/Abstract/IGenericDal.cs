using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		public T GetById(int id);
		public List<T> GetAll();
		public void Insert(T t);
		public void Update(T t);
		public void Delete(T t);
		public List<T> GetAllWithFilter(Expression<Func<T, bool>> filter);
		

    }
}
