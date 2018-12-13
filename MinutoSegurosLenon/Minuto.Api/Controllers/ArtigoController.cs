using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Minuto.Api.Negocio;
using Minuto.Entidade;
using Minuto.Interface;
using System.Collections.Generic;

namespace Minuto.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class ArtigoController : Controller
    {

        private IArtigoServico servico;

        public ArtigoController()
        {
            servico = new ArtigoServico();
        }

        // GET api/values
        [HttpGet]
        [ActionName("consultarpalavra")]
        public IList<Artigo> ConsultarPalavra()
        {
            return servico.ConsultarPalavra();
        }
    }
}
