using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.DTOs;
using ApOneCore.Core.Entites;
using AutoMapper;

namespace ApiOneCore.Infraestructure.Maping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
