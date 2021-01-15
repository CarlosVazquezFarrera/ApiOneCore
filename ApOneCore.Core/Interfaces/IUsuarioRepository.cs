using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.Entites;
using System;
using System.Threading.Tasks;

namespace ApOneCore.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Inserta en la base de datos al usuario y retorna información referente al proceso mismo
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<SimpleResponse> AltaUsuario(Usuario usuario);
        /// <summary>
        /// Hace la actualización de la entidad especificada
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<SimpleResponse> ActualizarUsuario(Usuario usuario);
        /// <summary>
        /// Hace la desactivación del usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        Task<SimpleResponse> EliminarUsuario(Guid IdUsuario);
    }
}
