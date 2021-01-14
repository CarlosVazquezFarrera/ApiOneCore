using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.Entites;
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
    }
}
