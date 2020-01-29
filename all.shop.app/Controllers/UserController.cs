using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Application.Contracts.Services;

namespace Shop.Api.Controllers
{
    [Produces("appliaction/json")]
    [Route("api/[controller]")]
    [ApiController]
  
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        public UserController(IUserService userSerices) {
            _userService = userSerices;

        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<String>> GetDetail(int id)
        {
            var detail = await _userService.GetUserNombreApellido(id);

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }




    }
}