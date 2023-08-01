using DatingApp.Dal.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Dal.Repos.Base
{
    public abstract class BaseRepo<T> : IRepo<T> where T : BaseModel, new()
    {
        private readonly bool _disposeContext;
        public DatabaseContext AppDatabaseContext { get; }
        public DbSet<T> Table { get; }

        public BaseRepo(DatabaseContext databaseContext)
        {
            _disposeContext = false;
            AppDatabaseContext = databaseContext;
            Table = databaseContext.Set<T>();
        }

        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChages();
        }

        public int AddRange(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return SaveChages();
        }

        public int Delete(T entity)
        {
            Table.Remove(entity);
            return SaveChages();
        }

        public int Delete(int id, byte[] timestamp)
        {
            var entity = new { Id = id, TimeStamp = timestamp };
            AppDatabaseContext.Entry(entity).State = EntityState.Deleted;
            return SaveChages();
        }

        public int DeleteRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
            return SaveChages();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (_disposeContext)
                {
                    AppDatabaseContext.Dispose();
                }
            }

            _isDisposed = true;
        }

        public int ExecuteQuery(string sqlQuery, object[] sqlParameters)
        {
            Table.FromSqlRaw(sqlQuery, sqlParameters);
            return SaveChages();
        }

        public T Find(int id)
        {
            var entity = Table.Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return Table;
        }

        public int SaveChages()
        {
            try
            {
                return AppDatabaseContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public int Update(T entity)
        {
            Table.Update(entity);
            return SaveChages();
        }

        public int UpdateRange(IEnumerable<T> entities)
        {
            Table.UpdateRange(entities);
            return SaveChages();
        }
    }
}
