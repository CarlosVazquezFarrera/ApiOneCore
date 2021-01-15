using ApOneCore.Core.DTOs;
using ApOneCore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiOneCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [HttpPost("AltaUsuario")]

        public async Task<IActionResult> Alta([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var ServiceResponse = await _usuarioService.AltaUsuario(usuario);
                return Ok(ServiceResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("ActualizarUsuario")]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var ServicioResponse = await _usuarioService.ActualizarUsuario(usuario);
                return Ok(ServicioResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
