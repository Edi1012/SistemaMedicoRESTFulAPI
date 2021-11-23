using Microsoft.EntityFrameworkCore;
using SistemaMedico.Core.Entities;
using SistemaMedico.Core.Interfaces;
using SistemaMedico.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SistemaMedicoContext sistemaMedicoContext;
        private readonly DbSet<T> _entities;

        public BaseRepository(SistemaMedicoContext sistemaMedicoContext)
        {
            this.sistemaMedicoContext = sistemaMedicoContext;
            _entities = sistemaMedicoContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T> GetById(int Id)
        {
            return await _entities.FindAsync(Id);
        }

        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await sistemaMedicoContext.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await sistemaMedicoContext.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            T entity = await GetById(Id);
            _entities.Remove(entity);
            sistemaMedicoContext.SaveChanges();
        }


    }

}
