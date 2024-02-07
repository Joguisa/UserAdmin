using BackUserAdmin.DTOs;
using BackUserAdmin.Helpers;
using BackUserAdmin.Services.Contrato;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackUserAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamento departamentoService;

        public DepartamentoController(IDepartamento departamentoService)
        {
            this.departamentoService = departamentoService;
        }


        [HttpGet(Name = "ListarDepartamentos")]
        public async Task<ActionResult> GetDepartamentos()
        {
            try
            {
                var departamentos = await departamentoService.GetDepartamentos();
                if (departamentos == null)
                {
                    return NotFound(new ServiceResponse<List<DepartamentoDto>>()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Data = null,
                        Message = "No se encontraron registros"
                    });
                }
                return Ok(new ServiceResponse<List<DepartamentoDto>>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = departamentos,
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
                    });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var departamento = await departamentoService.GetDepartamento(id);
                if (departamento == null)
                {
                    return NotFound(new ServiceResponse<DepartamentoDto>()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Data = null,
                        Message = "No se encontraron registros"
                    });
                }
                return Ok(new ServiceResponse<DepartamentoDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = departamento,
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
                    });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DepartamentoDto departamento)
        {
            try
            {
                var newDepartamento = await departamentoService.AddDepartamento(departamento);
                if (newDepartamento == null)
                {
                    return BadRequest(new ServiceResponse<DepartamentoDto>()
                    {
                        StatusCode = HttpStatusCode.Created,
                        Data = newDepartamento,
                        Message = "Registro creado"
                    });
                }

                return Ok(new ServiceResponse<DepartamentoDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = newDepartamento,
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DepartamentoDto departamento)
        {
            try
            {
                var newDepartamento = await departamentoService.UpdateDepartamento(departamento, id);
                if (newDepartamento == null)
                {
                    return BadRequest(new ServiceResponse<DepartamentoDto>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = "No se pudo actualizar el registro"
                    });
                }
                return Ok(new ServiceResponse<DepartamentoDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = newDepartamento,
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
                    });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleted = await departamentoService.DeleteDepartamento(id);
                if (!deleted)
                {
                    return BadRequest(new ServiceResponse<string?>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Data = null,
                        Message = "No se pudo eliminar el registro"
                    });
                }
                return Ok(new ServiceResponse<string?>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = null,
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
                    }
                                                                                                                                                                                                                                                                                                                                          );
            }
        }


    }
}
