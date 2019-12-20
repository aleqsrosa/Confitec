using ProjetoTeste.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoTeste.Core.Infrastructure.ORM.Maps
{
    public partial class UsuariosMap : EntityTypeConfiguration<Usuarios>
    {

		public void CustomConfig()
		{
			


		}

    }
}