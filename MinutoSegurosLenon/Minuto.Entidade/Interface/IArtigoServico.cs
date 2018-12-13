using Minuto.Entidade;
using System.Collections.Generic;

namespace Minuto.Interface
{
    public interface IArtigoServico
    {

        IList<Artigo> ConsultarPalavra();
    }
}
