using Common.Domain.Interfaces;
using SimpleInjector;
using Common.Cripto;
using ProjetoTeste.Infrastructure.ORM.Contexto;
using Common.Infrastructure.ORM.Repositories;

public static partial class ConfigContainer
{

    public static void RegisterOtherComponents(Container container)
    {
        container.Register<ICripto, Cripto>(Lifestyle.Scoped);
        container.Register<IRepository, RepositoryBase<DbContextCore>>(Lifestyle.Scoped);

    }

}

