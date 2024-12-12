using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
	public interface IGenericService<T> where T : class
	{
		public T TGetById(int id);
		public List<T> TGetAll();
		public void TInsert(T t);
		public void TUpdate(T t);
		public void TDelete(T t);
		public List<T> TGetAllWithFilter(Expression<Func<T, bool>> filter);
	}
}
