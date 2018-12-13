using System.Collections.Generic;

namespace Minuto.Entidade
{
    public class Artigo
    {

        public Artigo()
        {
            this.Palavra = new Dictionary<string, int>();
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public IDictionary<string, int> Palavra { get; set; }

    }
}
