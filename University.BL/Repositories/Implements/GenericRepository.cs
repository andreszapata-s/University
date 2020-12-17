using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data;

namespace University.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly UniversityContext universityContext;

        public GenericRepository(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task Delete(int id)
        {
            // Obtener la entidad por un id
            var entity = await GetById(id);

            // Se valida si existe
            if (entity == null)
                throw new Exception("La entidad es nula.");

            // Elimina la entidad no el task con el código Linkq
            universityContext.Set<TEntity>().Remove(entity);

            await universityContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await universityContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            // universityContext.Courses.FindAsync(id);
            return await universityContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            // Otra forma de Insert
            // universityContext.Entry(entity).State = EntityState.Added;

            universityContext.Set<TEntity>().Add(entity);
            await universityContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            // Otra forma de update
            // universityContext.Entry(entity).State = EntityState.Modified;

            universityContext.Set<TEntity>().AddOrUpdate(entity);
            await universityContext.SaveChangesAsync();
            return entity;
        }

    }
}