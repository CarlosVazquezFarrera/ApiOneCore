using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.DTOs;
using ApOneCore.Core.Entites;
using ApOneCore.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApOneCore.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Constructor
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this._usuarioRepository = usuarioRepository;
            this._mapper = mapper;
        } 
        #endregion

        #region Atributos
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Métodos
        /// <summary>
        /// Retorna la información referete al éxito del registro del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> AltaUsuario(UsuarioDTO usuario)
        {
            return await _usuarioRepository.AltaUsuario(_mapper.Map<Usuario>(usuario));
        }
        /// <summary>
        /// Retorna la información sobre la actualización del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> ActualizarUsuario(UsuarioDTO usuario)
        {
            return await _usuarioRepository.ActualizarUsuario(_mapper.Map<Usuario>(usuario));
        }
        /// <summary>
        /// Retorna la información referente acerca de la desactivación del usuario especificado
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public async Task<SimpleResponse> EliminarUsuario(Guid IdUsuario)
        {
            return await _usuarioRepository.EliminarUsuario(IdUsuario);
        }
        /// <summary>
        /// Retorna la información de la obtención de los usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<Response<List<UsuarioDTO>>> ObtenerUsuarios()
        {
            var responseReposiroty = await _usuarioRepository.ObtenerUsuarios();
            Response<List<UsuarioDTO>> responseDTO = new Response<List<UsuarioDTO>> {
                Exito = responseReposiroty.Exito,
                Mensaje = responseReposiroty.Mensaje,
                Data = (responseReposiroty.Data.Select(u => _mapper.Map<UsuarioDTO>(u))).ToList()
            };

            return responseDTO;
        }
        #endregion
    }
}
