using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoTeste.Core.Domain
{	
	public partial class UsuariosValidation
	{
        [Required(ErrorMessage="Usuarios - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Usuarios - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual object Nome {get; set;}

        [Required(ErrorMessage="Usuarios - Campo DataNascimento é Obrigatório")]
        public virtual object DataNascimento {get; set;}

        [Required(ErrorMessage="Usuarios - Campo Sobrenome é Obrigatório")]
        public virtual object Sobrenome {get; set;}

        [Required(ErrorMessage="Usuarios - Campo Email é Obrigatório")]
        public virtual object Email {get; set;}

        [Required(ErrorMessage="Usuarios - Escolaridade é Obrigatório")]
        public virtual object Escolaridade {get; set;}


	}
}