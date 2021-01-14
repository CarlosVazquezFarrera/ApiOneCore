using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.Entites;
using System.Threading.Tasks;

namespace ApOneCore.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<Response<Usuario>> Login(Usuario usuario);
    }
}
