using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using VacantesApi.Models;
using VacantesApi.Services.Interfaces;
namespace VacantesApi.Services.Repositories
{
    //Repositorio Base, contiene los metodos CRUD genericos, el repositorio recibe como parametro una enitdad que sea de una clase
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DBContext _db;
        public Repository(DBContext db){
            _db = db;
        }
        public IQueryable<TEntity> ObtenerTodos(){
            try
            {
                return _db.Set<TEntity>();
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AgregarAsync(TEntity entity){
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AgregarAsync)} entity must not be null");
            }
            try
            {
                await _db.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;

            }
            catch (System.Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> ActualizarAsync(TEntity entity, TEntity entityActualizada){
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(ActualizarAsync)} entity must not be null");
            }
            try
            {
                _db.Entry(entity).CurrentValues.SetValues(entityActualizada);
                await _db.SaveChangesAsync();
                return entity;

            }
            catch (System.Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<TEntity> EliminarAsync(TEntity entity){
            try
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }
    }
}