using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections;
namespace VacantesApi.Services.Interfaces
{
    //Interface para definir los metodos que utilizará la clase Repository
    public interface IRepository<TEntity> where TEntity : class, new()
    {
         IQueryable<TEntity> ObtenerTodos();
         Task<TEntity> AgregarAsync(TEntity entity);
         Task<TEntity> ActualizarAsync(TEntity entity, TEntity entityActualizada);
         Task<TEntity> EliminarAsync(TEntity entity);

    }
}