using ProjetoTeste.Core.Domain;
using ProjetoTeste.Core.Dto;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace ProjetoTeste.Application.Config
{
    public class DominioToDtoProfileCore : AutoMapper.Profile
    {

		public override string ProfileName
		{
			get { return "DominioToDtoProfileCore"; }
		}


        protected override void Configure()
        {

            AutoMapper.Mapper.CreateMap<Usuarios, UsuariosDto>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Usuarios, UsuariosDtoSpecialized>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Usuarios, UsuariosDtoSpecializedResult>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Usuarios, UsuariosDtoSpecializedReport>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Usuarios, UsuariosDtoSpecializedDetails>().ReverseMap();



        }
    }
}
