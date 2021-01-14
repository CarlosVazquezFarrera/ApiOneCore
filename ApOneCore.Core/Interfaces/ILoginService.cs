using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.DTOs;
using System.Threading.Tasks;

namespace ApOneCore.Core.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Retorna el resultado que ha generado la base de datos
        /// </summary>
        /// <returns></returns>
        Task<Response<UsuarioDTO>> Login(UsuarioDTO usuario);
    }
}
