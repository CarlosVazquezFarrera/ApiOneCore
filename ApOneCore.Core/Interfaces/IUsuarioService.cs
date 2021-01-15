namespace ApOneCore.Core.Interfaces
{
    using ApOneCore.Core.CustomEntities;
    using ApOneCore.Core.DTOs;
    using System;
    using System.Threading.Tasks;

    public interface IUsuarioService
    {
        /// <summary>
        /// Retorna la información sobre el fracaso o éxito de registro del usuario 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<SimpleResponse> AltaUsuario(UsuarioDTO usuario);
        /// <summary>
        /// Retorna la información sobre la actualización de un registro en específico 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<SimpleResponse> ActualizarUsuario(UsuarioDTO usuario);
        /// <summary>
        /// Retorna la información sobre la desactivación del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<SimpleResponse> EliminarUsuario(Guid IdUsuario);
    }
}
