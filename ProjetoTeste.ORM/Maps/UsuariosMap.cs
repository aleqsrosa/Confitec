using ProjetoTeste.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoTeste.Core.Infrastructure.ORM.Maps
{
    public partial class UsuariosMap : EntityTypeConfiguration<Usuarios>
    {
        public UsuariosMap()
        {
            this.ToTable("Usuarios");
            this.Property(t => t.UsuariosId).HasColumnName("Id");
           

            this.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(50);
            this.Property(t => t.Sobrenome).HasColumnName("Sobrenome").HasColumnType("varchar").HasMaxLength(50);
            this.Property(t => t.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(50);
            this.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            this.Property(t => t.Escolaridade).HasColumnName("Escolaridade");


            this.HasKey(d => new { d.UsuariosId, }); 

			this.CustomConfig();

        }
    }
}