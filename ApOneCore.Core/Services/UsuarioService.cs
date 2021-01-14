using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.DTOs;
using ApOneCore.Core.Entites;
using ApOneCore.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApOneCore.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Constructor
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this._usuarioService = usuarioRepository;
            this._mapper = mapper;
        } 
        #endregion

        #region Atributos
        private readonly IUsuarioRepository _usuarioService;
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
            return await _usuarioService.AltaUsuario(_mapper.Map<Usuario>(usuario));
        } 
        #endregion
    }
}
