using System.Collections.Generic;
using System.Threading.Tasks;
using VacantesApi.Models;
using VacantesApi.Services.Repositories;
using VacantesApi.Services.Interfaces;
namespace VacantesApi.Services.Services
{
    //Clase CarreraService hereda los metodos de la interface ICarreraService, utilizando inyeccion de dependecias inyectamos la Interface ICarreraRepository para acceder a los metodos de esta.
    public class CarreraService : ICarreraService
    {
        private readonly ICarreraRepository _carreraRepository;
        public CarreraService(ICarreraRepository carreraRepository) => _carreraRepository = carreraRepository;
        public async Task<List<Carreras>> ObtenerCarrerasAsync() => await _carreraRepository.ObtenerCarrerasAsync();
        public async Task<Carreras> ObtenerCarreraPorNombre(string nombre) => await _carreraRepository.ObtenerCarreraPorNombre(nombre);
        public async Task<Carreras> ObtenerCarreraPorID(int id) => await _carreraRepository.ObtenerCarreraPorID(id);
        public async Task<Carreras> AgregarCarreraAsync(Carreras carrera) => await _carreraRepository.AgregarAsync(carrera);
        public async Task<Carreras> ActualizarCarreraAsync(Carreras carrera, Carreras carreraActualizada) => await _carreraRepository.ActualizarAsync(carrera, carreraActualizada);
        public async Task<Carreras> EliminarCarreraAsync(Carreras carrera) => await _carreraRepository.EliminarAsync(carrera);
    }
}