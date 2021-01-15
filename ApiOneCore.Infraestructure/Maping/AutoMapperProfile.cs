using ApOneCore.Core.CustomEntities;
using ApOneCore.Core.DTOs;
using ApOneCore.Core.Entites;
using AutoMapper;
using System.Collections.Generic;

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
