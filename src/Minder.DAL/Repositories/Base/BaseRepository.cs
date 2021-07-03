using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minder.DAL.Repositories.Base
{
    public abstract class BaseRepository
    {
        /// <summary>
        /// Базовый класс для управления сущностями базы данных.
        /// </summary>
        /// <typeparam name="T"> Тип сущности, которая управляется </typeparam>
        public abstract class BaseService<T> where T : class
        {
            private readonly DbContext _context;

            public BaseService(DbContext dbContext)
            {
                _context = dbContext;
            }

            /// <summary>
            /// Добавление сущности
            /// </summary>
            public virtual bool Add(T entity)
            {
                _context.Add(entity);
                return _context.SaveChanges() != 0;
            }

            /// <summary>
            /// Получение сущности
            /// </summary>
            public virtual async Task<T> Find(long id)
            {
                return await _context.Set<T>().FindAsync(id);
            }

            public virtual async Task<IEnumerable<T>> FindAll(Func<T, bool> predicate)
            {
                return await Task.FromResult(_context.Set<T>().Where(predicate));
            }

            /// <summary>
            /// Получение списка сущностей
            /// </summary>        
            public virtual async Task<IEnumerable<T>> GetAll()
            {
                return await _context.Set<T>().ToListAsync();
            }

            /// <summary>
            /// Обновление сущности
            /// </summary>        
            public virtual void Update(T entity)
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }

            /// <summary>
            /// Удаление сущности
            /// </summary>
            public virtual bool Remove(T entity)
            {
                _context.Set<T>().Remove(entity);

                return _context.SaveChanges() != 0;
            }
        }
    }
}
