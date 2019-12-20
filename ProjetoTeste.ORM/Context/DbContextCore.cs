using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.ORM.Context;
using Common.Infrastructure.Log;
using System.Data.Entity.ModelConfiguration.Conventions;
using Common.Domain.Interfaces;
using ProjetoTeste.Core.Infrastructure.ORM.Maps;

//[assembly: DbMappingViewCacheType(typeof(DbContextCore), typeof(MappingViewCacheCoreGenereted))]
namespace ProjetoTeste.Infrastructure.ORM.Contexto
{
    public class DbContextCore : DbContext, IUnitOfWork<DbContextCore>,IUnitOfWork
    {
        static DbContextCore()
        {
            Database.SetInitializer<DbContextCore>(null);
        }

        public DbContextCore(ILog log)
            : base(ConfigurationManager.ConnectionStrings["Core"].ConnectionString)
        {
			base.Database.Log = log.Info;
        }
		
		public string ConnectionStringComplete()
        {
            return ConfigurationManager.ConnectionStrings["Core"].ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UsuariosMap());


        }


        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
