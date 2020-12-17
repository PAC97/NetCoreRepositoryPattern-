using System.Collections.Generic;
using System.Threading.Tasks;
using VacantesApi.Models;

namespace VacantesApi.Services.Interfaces
{
    //Interface para definir los metodos que debe utilizar la clase CarreraService
    public interface ICarreraService
    {
        Task<List<Carreras>> ObtenerCarrerasAsync();
        Task<Carreras> ObtenerCarreraPorNombre(string nombre);
        Task<Carreras> ObtenerCarreraPorID(int id);
        Task<Carreras> AgregarCarreraAsync(Carreras carrera);
        Task<Carreras> ActualizarCarreraAsync(Carreras carrera, Carreras carreraActualizada);
        Task<Carreras> EliminarCarreraAsync(Carreras carrera);
    }
}