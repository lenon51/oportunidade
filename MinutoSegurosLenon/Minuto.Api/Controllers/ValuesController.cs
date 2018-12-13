using Microsoft.AspNetCore.Mvc;
using MinutoSegurosLenon.Entidade;
using MinutoSegurosLenon.Negocio;
using System.Collections.Generic;

namespace MinutaApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IList<Artigo> ConsultarPalavra()
        {
            return new ArtigoServico().ConsultarPalavra();
        }
    }
}
