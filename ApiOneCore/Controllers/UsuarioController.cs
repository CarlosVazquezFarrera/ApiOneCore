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
        /// <summary>
        /// Dat de lata a un usuario nuevo
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("AltaUsuario")]

        public async Task<IActionResult> Alta(UsuarioDTO usuario)
        {
            try
            {
                var serviceResponse = await _usuarioService.AltaUsuario(usuario);
                return Ok(serviceResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Actualizar a un usuario que ya se encuentra en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPatch("ActualizarUsuario")]
        public async Task<IActionResult> Actualizar(UsuarioDTO usuario)
        {
            try
            {
                var servicioResponse = await _usuarioService.ActualizarUsuario(usuario);
                return Ok(servicioResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Desactiva de la base de datos el usuario que se especifica en el ID
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        [HttpDelete("EliminarUsuario")]
        public async Task<IActionResult> Eliminar([FromBody]Guid IdUsuario)
        {
            try
            {
                var servicivioResponse = await _usuarioService.EliminarUsuario(IdUsuario);
                return Ok(servicivioResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
