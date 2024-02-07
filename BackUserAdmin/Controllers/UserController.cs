using BackUserAdmin.DTOs;
using BackUserAdmin.Helpers;
using BackUserAdmin.Services.Contrato;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackUserAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet(Name = "ListarUsuarios")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                if (users == null)
                {
                    return NotFound(new ServiceResponse<List<UserDto>>()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Data = null,
                        Message = "No se encontraron registros"
                    });
                }
                return Ok(new ServiceResponse<List<UserDto>>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = users,
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

        // GET api/<UserController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                if (user == null)
                {
                    return NotFound(new ServiceResponse<UserDto>()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Data = null,
                        Message = "No se encontraró el registro"
                    });
                }
                return Ok(new ServiceResponse<UserDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = user,
                    Message = "Registro encontrado"
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

        // POST api/<UserController>
        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                var user = await _userService.AddUser(userDto);

                return Ok(new ServiceResponse<UserDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = user,
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
                    }
                );
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            try
            {
                var user = await _userService.UpdateUser(userDto, id);
                return Ok(new ServiceResponse<UserDto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = user,
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

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.DeleteUser(id);
                return Ok(new ServiceResponse<bool>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = user,
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
