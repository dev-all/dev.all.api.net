using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shop.Api.Application.Configuration;
using Shop.Api.Application.Contracts.ApiCaller;
using Shop.Api.Application.Contracts.Services;
using Shop.Api.Business.Models;
using Shop.Api.Mappers;
using Shop.Api.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]

    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IApiCaller _apiCaller;
        //public readonly IAppConfig _appConfig;
       // private readonly IConfiguration _configuration;

        public UserController(IUserService userSerices, IApiCaller apiCaller)
        {
            _userService = userSerices;
            _apiCaller = apiCaller;
          

        }


        //public UserController(IUserService userSerices, IApiCaller apiCaller, IAppConfig appConfig, IConfiguration configuration)
        //{
        //    _userService = userSerices;
        //    _apiCaller = apiCaller;
        //    _appConfig = appConfig;
        //    _configuration = configuration;

        //}


        /// <summary>
        /// Get User - Nombre del Accion que se ejecutara - isualizacion via SWAGGER
        /// </summary>
        /// <param name="id"></param>
        /// <returns>String</returns>
        /// 

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(UserMapper))] //string o model  return
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUser(int id)
        {
            //solo para evaluar y aprender la utilizacion de polly
            //var maxActual = _configuration.GetSection("Polly:MaxTrys").Value;
            //var max = _appConfig.MaxTrys;
            //var seconds = _appConfig.SecondsToWait;

            var response = _apiCaller.GetServiceResponseById<User>("Values", 1);

            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(UserMapper.Map(user));
        }

        /// <summary>
        /// Lista de Usuarios - Visualizacion via SWAGGER
        /// </summary>
        /// <param name="id"></param>
        /// <returns>String</returns>
        /// 
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(IEnumerable<UserModels>))] //string o model  return
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserModels>>> GetUserList()
        {
            

            var userList = await _userService.GetUserAll();

            if (userList == null)
            {
                return NotFound();
            }
            var list = userList.Select(UserMapper.Map);
            return Ok(list);
        }






        /// <summary>
        /// Registrar Nuevo Usuario
        /// </summary>
        /// <param name="userModels"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(UserModels))] //string o model  return
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModels userModels)
        {
            var user = await _userService.AddUser(UserMapper.Map(userModels));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(UserMapper.Map(user));
        }




        /// <summary>
        /// Actualizar Usuario
        /// </summary>
        /// <param name="userModels"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(UserModels))] //string o model  return
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserModels userModels)
        {
            var user = await _userService.UpdateUser(UserMapper.Map(userModels));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(UserMapper.Map(user));
        }


        /// <summary>
        /// Eliminar del la BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 


        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);

            return NoContent();
        }

    }
}