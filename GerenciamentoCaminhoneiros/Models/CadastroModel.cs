using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCaminhoneiro.Models
{
    public class CadastroModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string UltimoNome { get; set; }
        public string MarcaCaminhao { get; set; }
        public string ModeloCaminhao { get; set; }
        public string PlacaCaminhao { get; set; }
        public string eixos { get; set; }
        public string endereco { get; set; }
    }
}
