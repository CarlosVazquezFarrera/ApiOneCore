using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.Entites;
using System.Threading.Tasks;

namespace ApOneCore.Core.Interfaces
{
    public interface ILoginRepository
    {
        /// <summary>
        /// Corrobora que el usuario exista en la base de datos y lo retorna si es así
        /// </summary>
        /// <returns></returns>
        Task<Response<Usuario>> Login(Usuario usuario);
    }
}
