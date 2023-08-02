using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Dal.Repos.Base
{
    public interface IRepo<T>: IDisposable
    {
        public int Add(T entity);
        public int AddRange(IEnumerable<T> entities);
        public int Update(T entity);
        public int UpdateRange(IEnumerable<T> entities);
        public int Delete(T entity);
        public int DeleteRange(IEnumerable<T> entities);
        public int Delete(int id, byte[] timestamp);
        public IEnumerable<T> GetAll();
        public T Find(int id);
        public int ExecuteQuery(string aqlQuery, object[] sqlParameters);
        public int SaveChages();
    }
}
