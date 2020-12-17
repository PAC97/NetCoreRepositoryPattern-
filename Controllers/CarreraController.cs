using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using VacantesApi.Models;
using VacantesApi.Models.Response;
using VacantesApi.Services.Services;
using VacantesApi.Services.Interfaces;

namespace VacantesApi.Controllers
{
    [Route("api/Carrera")]
    /* [Authorize] */
    [ApiController]
    //Utilizando inyeccion de dependencias inyectamos la Interface ICarreraService para poder acceder a su metodos
    public class CarreraController : ControllerBase
    {
        private readonly ICarreraService _carreraService;
        public CarreraController(ICarreraService carreraService){
            _carreraService = carreraService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Carreras>>> Get(){
            var result = await _carreraService.ObtenerCarrerasAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> GuardarCarrera(Carreras carreraReq){
            Respuesta respuesta = new Respuesta();
            Carreras existe = await _carreraService.ObtenerCarreraPorNombre(carreraReq.NombreCarrera);
            if (existe != null)
            {
                respuesta.Mensaje = "Ya existe esa carrera" + carreraReq.NombreCarrera;
                return StatusCode(302, respuesta);
            }
            Carreras carrera = new Carreras();
            carrera = carreraReq;
            carrera.Activo = true;
            carrera.Creado = DateTime.Now;
            carrera.NombreCarrera.ToUpper().Trim();
            respuesta.Exito = 1;
            respuesta.Mensaje = "Carrera agregada";
            await _carreraService.AgregarCarreraAsync(carrera);
            return Ok(respuesta);
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarCarrera(Carreras carreraReq){
            Respuesta respuesta = new Respuesta();
            try
            {
                Carreras carrera = await _carreraService.ObtenerCarreraPorID(carreraReq.ID);
                if (carrera == null)
                {
                    respuesta.Mensaje = "No se encuentra ese registro";
                    return NotFound(respuesta);
                }
                Carreras existe = await _carreraService.ObtenerCarreraPorNombre(carreraReq.NombreCarrera);
                if (existe != null)
                {
                    respuesta.Mensaje = "Ya se encuentra registrada la carrera " + carreraReq.NombreCarrera;
                    return StatusCode(302, respuesta);
                }
                carreraReq.NombreCarrera.ToUpper().Trim();
                await _carreraService.ActualizarCarreraAsync(carrera, carreraReq);
                respuesta.Exito = 1;
                respuesta.Mensaje = "Carrera Actualizada";
                return Ok(respuesta);
            }
            catch (System.Exception ex)
            {
                respuesta.Mensaje = ex.Message;
                return StatusCode(500, respuesta);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> EliminarCarrera(int Id){
            Respuesta respuesta = new Respuesta();
            try
            {
                Carreras carrera = await _carreraService.ObtenerCarreraPorID(Id);
                if (carrera == null)
                {
                    respuesta.Mensaje = "No se encuentra ese registro";
                    return NotFound(respuesta);
                }
                await _carreraService.EliminarCarreraAsync(carrera);
                respuesta.Exito = 1;
                respuesta.Mensaje = "Carrera Eliminada" + carrera.NombreCarrera;
                return Ok(respuesta);
            }
            catch (System.Exception)
            {
                return StatusCode(500, respuesta);
            }
        }
    }
}
