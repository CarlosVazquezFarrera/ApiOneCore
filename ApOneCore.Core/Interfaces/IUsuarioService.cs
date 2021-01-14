namespace ApOneCore.Core.Interfaces
{
    using ApOneCore.Core.CustomEntities;
    using ApOneCore.Core.DTOs;
    using System.Threading.Tasks;

    public interface IUsuarioService
    {
        Task<SimpleResponse> AltaUsuario(UsuarioDTO usuario);
    }
}
