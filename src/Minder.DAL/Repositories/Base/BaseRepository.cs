using Microsoft.EntityFrameworkCore;
using Minder.DomainModels.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minder.DAL.Repositories.Base
{
    /// <summary>
    /// Базовый класс для управления сущностями базы данных.
    /// </summary>
    /// <typeparam name="T"> Тип сущности, которая управляется </typeparam>
    public class BaseRepository<T> where T : class
    {
        private readonly MinderDbContextFactory _contextFactory;

        public BaseRepository(MinderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        /// <summary>
        /// Добавление сущности
        /// </summary>
        public virtual async Task<T> Create(T entity)
        {
            using var context = _contextFactory.CreateDbContext();

            var newEntity = await context.AddAsync(entity);
            
            await context.SaveChangesAsync();
            return newEntity.Entity;
        }

        /// <summary>
        /// Получение сущности
        /// </summary>
        public virtual async Task<T> Find(long id)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Set<T>().FindAsync(id);
        }


        /// <summary>
        /// Получить все сущности по условию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> FindAll(Func<T, bool> predicate)
        {
            using var context = _contextFactory.CreateDbContext();

            return await Task.FromResult(context.Set<T>().Where(predicate));
        }

        /// <summary>
        /// Получение списка сущностей
        /// </summary>        
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>        
        public virtual async Task Update(T entity)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление сущности
        /// </summary>
        public virtual async Task<bool> Remove(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);

            return await context.SaveChangesAsync() != 0;
        }
    }
}
