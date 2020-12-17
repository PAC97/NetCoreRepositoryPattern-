using System.Collections.Generic;
using System.Threading.Tasks;
using VacantesApi.Models;
namespace VacantesApi.Services.Interfaces
{
    //Interface ICarreraRepository que extiende de la interface IRepository pasando como parametro la clase carreras
    public interface ICarreraRepository : IRepository<Carreras>
    {
        Task<Carreras> ObtenerCarreraPorNombre(string nombre);
        Task<Carreras> ObtenerCarreraPorID(int id);
        Task<List<Carreras>> ObtenerCarrerasAsync();
    }
}