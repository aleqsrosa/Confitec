using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Core.Filters
{
    public partial class UsuariosFilter : Filter
    {


        public int UsuariosId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }


    }
}
