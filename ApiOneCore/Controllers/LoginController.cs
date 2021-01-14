using ApOneCore.Core.DTOs;
using ApOneCore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiOneCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Constructor
        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;
        } 
        #endregion
        #region Atributos
        private readonly ILoginService _loginService;
        #endregion 

        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var ServiceResponse = await _loginService.Login(usuario);
                return Ok(ServiceResponse);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
