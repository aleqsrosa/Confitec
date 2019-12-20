using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Interfaces;
using Common.Infrastructure.Cache;
using System.Collections.Generic;
using Common.Models;
using ProjetoTeste.Core.Filters;
using Common.Interfaces;
using ProjetoTeste.Core.Dto;
using ProjetoTeste.Core.Domain;
using Common.Dto;

namespace ProjetoTeste.Core.Application
{
    public partial class UsuariosApp
    {

		public void Init(string token)
        {
			this.cache = ConfigContainer.Container().GetInstance<ICache>();
            this.repUsuarios = ConfigContainer.Container().GetInstance<IRepository<Usuarios>>();
            this.Usuarios = new Usuarios(this.repUsuarios, cache);
            this.Usuarios.SetToken(token);
		}

		private IEnumerable<UsuariosDto> MapperDomainToResult(UsuariosFilter filter, PaginateResult<Usuarios> dataList)
        {
            var result = filter.IsOnlySummary ? null : AutoMapper.Mapper.Map<IEnumerable<Usuarios>, IEnumerable<UsuariosDtoSpecializedResult>>(dataList.ResultPaginatedData);
            return result;
        }

		private IEnumerable<UsuariosDto> MapperDomainToReport(UsuariosFilter filter, PaginateResult<Usuarios> dataList)
        {
            var result = filter.IsOnlySummary ? null : AutoMapper.Mapper.Map<IEnumerable<Usuarios>, IEnumerable<UsuariosDtoSpecializedReport>>(dataList.ResultPaginatedData);
            return result;
        }

		
		private UsuariosDto MapperDomainToDtoDetails(Usuarios data,  Common.Dto.DtoBase dto)
        {
            var result =  AutoMapper.Mapper.Map<Usuarios, UsuariosDtoSpecializedDetails>(data);
            return result;
        }

		private DtoBase MapperDomainToDtoSpecialized(Usuarios data,  Common.Dto.DtoBase dto)
        {
            var result =  AutoMapper.Mapper.Map<Usuarios, UsuariosDtoSpecialized>(data);
            return result;
        }
	}
}
