using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.DTOs;
using System.Threading.Tasks;

namespace ApOneCore.Core.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Corrobora que el usuario exista en la base de datos y lo retorna si es así
        /// </summary>
        /// <returns></returns>
        Task<Response<UsuarioDTO>> Login(UsuarioDTO usuario);
    }
}
