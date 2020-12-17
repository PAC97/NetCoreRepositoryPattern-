using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VacantesApi.Services.Interfaces;
using VacantesApi.Models;
namespace VacantesApi.Services.Repositories
{
    //CarreraRepository hereda los metodos de la clase Repository y se pasa como parametro la clase Carreras que es la que será afectada, tambien extiende de la interface ICarreraRepository para definir los metodos que debe contener la clase
    public class CarreraRepository : Repository<Carreras>, ICarreraRepository
    {
        public CarreraRepository(DBContext _carreraContext):base(_carreraContext){}
        public async Task<Carreras> ObtenerCarreraPorNombre(string nombre) => await ObtenerTodos().FirstOrDefaultAsync(x => x.NombreCarrera == nombre);
        public async Task<Carreras> ObtenerCarreraPorID(int id) => await ObtenerTodos().FirstOrDefaultAsync(x => x.ID == id);
        public async Task<List<Carreras>> ObtenerCarrerasAsync() => await ObtenerTodos().Where(x => x.Activo == true).ToListAsync();
    }
}