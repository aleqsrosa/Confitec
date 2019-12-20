using AutoMapper;

namespace ProjetoTeste.Application.Config
{
	public class AutoMapperConfigCore
    {
		public static void RegisterMappings()
		{

			Mapper.Initialize(x =>
			{
				x.AddProfile<DominioToDtoProfileCore>();
				//x.AddProfile<DominioToDtoProfileCoreCustom>();
			});

		}
	}
}
