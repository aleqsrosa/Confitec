using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Common.Dto;

namespace ProjetoTeste.Core.Dto
{
	public class UsuariosDto  : DtoBase
	{
        public int UsuariosId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }

    }
}