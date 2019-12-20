using ProjetoTeste.Infrastructure.ORM.Contexto;
using Common.Domain.Interfaces;
using Common.Infrastructure.Cache;
using Common.Infrastructure.Log;
using Common.Infrastructure.ORM.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;

public static partial class ConfigContainer
{

    private static Container container = new Container();

    static ConfigContainer()
    {
        container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
        container.Register<ILog, LogFileComponent>(Lifestyle.Scoped);
        container.Register<IUnitOfWork<DbContextCore>, DbContextCore>(Lifestyle.Scoped);
        container.Register<ICache, FactoryCache>(Lifestyle.Singleton);

        container.Register<IRepository<ProjetoTeste.Core.Domain.Usuarios>, Repository<ProjetoTeste.Core.Domain.Usuarios, DbContextCore>>(Lifestyle.Scoped);

        RegisterOtherComponents(container);

        container.Verify();

    }

    public static Container Container()
    {
        return container;
    }

}

