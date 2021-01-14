

using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.DTOs;
using ApOneCore.Core.Entites;
using ApOneCore.Core.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace ApOneCore.Core.Services
{
    public class LoginServices : ILoginService
    {
        #region Constructor
        public LoginServices(ILoginRepository loginRepository, IMapper mapper)
        {
            this._loginRepository = loginRepository;
            this._mapper = mapper;
        } 
        #endregion

        #region Atributos
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Métodos
        public async Task<Response<UsuarioDTO>> Login(UsuarioDTO usuario)
        {
            var repositoryResponse = await _loginRepository.Login(_mapper.Map<Usuario>(usuario));
            Response<UsuarioDTO> responseDtoService = new Response<UsuarioDTO>
            {
                Exito = repositoryResponse.Exito,
                Mensaje = repositoryResponse.Mensaje,
                Data = _mapper.Map<UsuarioDTO>(repositoryResponse.Data)
            };
            return responseDtoService;
        } 
        #endregion
    }
}
