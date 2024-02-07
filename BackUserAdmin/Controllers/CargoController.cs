using BackUserAdmin.DTOs;
using BackUserAdmin.Helpers;
using BackUserAdmin.Services.Contrato;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackUserAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargo _cargoService;

        public CargoController(ICargo cargoService)
        {
            _cargoService = cargoService;
        }

        // GET: api/<CargoController>
        [HttpGet(Name = "ListarCargos")]
        public async Task<ActionResult> GetCargos()
        {
            try
            {
                var cargos = await _cargoService.GetCargos();
                if (cargos == null)
                {
                    return NotFound(new ServiceResponse<List<CargoDto>>()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Data = null,
                        Message = "No se encontraron registros"
                    });
                }
                return Ok(new ServiceResponse<List<CargoDto>>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = cargos,
                    Message = "Registros encontrados"
                });
            }
            catch (Exception e) when (e is ServiceException)
            {
                return BadRequest(
                    new ServiceResponse<string?>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = e is ServiceException ? e.Message : "Something went wrong"
                    }
                );
            }
        }

        // GET api/<CargoController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var cargo = await _cargoService.GetCargo(id);
                if (cargo == null)
                {
                    return NotFound(new ServiceResponse<CargoDto>()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Data = null,
                        Message = "No se encontraron registros"
                    });
                }
                return Ok(new ServiceResponse<CargoDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = cargo,
                    Message = "Registros encontrados"
                });
            }
            catch (Exception e) when (e is ServiceException)
            {
                return BadRequest(
                    new ServiceResponse<string?>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = e is ServiceException ? e.Message : "Something went wrong"
                    }
                );
            }
        }

        // POST api/<CargoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CargoDto cargo)
        {
            try
            {
                var newCargo = await _cargoService.AddCargo(cargo);
                if (newCargo == null)
                {
                    return BadRequest(new ServiceResponse<CargoDto>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = "No se pudo crear el registro"
                    });
                }
                return Ok(new ServiceResponse<CargoDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = newCargo,
                    Message = "Registro creado"
                });
            }
            catch (Exception e) when (e is ServiceException)
            {
                return BadRequest(
                    new ServiceResponse<string?>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = e is ServiceException ? e.Message : "Something went wrong"
                    });
            }
        }

        // PUT api/<CargoController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCargo(int id, [FromBody] CargoDto cargo)
        {
            try
            {
                var cargoUpdated = await _cargoService.UpdateCargo(cargo, id);
                if (cargoUpdated == null)
                {
                    return BadRequest(new ServiceResponse<CargoDto>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = "No se pudo actualizar el registro"
                    });
                }
                return Ok(new ServiceResponse<CargoDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = cargoUpdated,
                    Message = "Registro actualizado"
                });
            }
            catch (Exception e) when (e is ServiceException)
            {
                return BadRequest(
                    new ServiceResponse<string?>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = e is ServiceException ? e.Message : "Something went wrong"
                    }
                                                      );
            }
        }

        // DELETE api/<CargoController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCargo(int id)
        {
            try
            {
                var cargo = await _cargoService.DeleteCargo(id);
                if (!cargo)
                {
                    return BadRequest(new ServiceResponse<bool>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = cargo,
                        Message = "No se pudo eliminar el registro"
                    });
                }
                return Ok(new ServiceResponse<bool>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = cargo,
                    Message = "Registro eliminado"
                });
            }
            catch (Exception e) when (e is ServiceException)
            {
                return BadRequest(
                    new ServiceResponse<string?>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = e is ServiceException ? e.Message : "Something went wrong"
                    });
            }
        }

    }
}
