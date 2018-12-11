using Microsoft.AspNetCore.Mvc;
using MinutoSegurosLenon.Entidade;
using MinutoSegurosLenon.Negocio;
using System.Collections.Generic;

namespace MinutaApi.Controllers
{
    [Route("api/[controller]")]
    public class ArtigoController : Controller
    {
        // GET api/values
        [HttpGet]
        public IList<MinutoSegurosLenon.Entidade.Artigo> ConsultarPalavra()
        {
            return new Util().ConsultarPalavra();
        }
    }
}
