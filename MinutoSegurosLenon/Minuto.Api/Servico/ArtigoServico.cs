﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Minuto.Entidade;
using Minuto.Interface;

namespace Minuto.Api.Negocio
{
    public class ArtigoServico: IArtigoServico
    {
        public IList<Artigo> ConsultarPalavra()
        {
            IList<Artigo> listaRetorno = new List<Artigo>();
            foreach (Artigo item in ConsultarRss())
            {
                Artigo artigo = new Artigo(){  Titulo = item.Titulo };

                string[] listaPalavra = item.Descricao.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                IList<string> lista = new List<string>(listaPalavra);
                foreach (var resultadoItem in lista.GroupBy(p => p)
                                                  .Select(g => new { palavra = g.Key, total = g.Count() })
                                                  .OrderByDescending(g => g.total)
                                                  .Take(10))
                    artigo.Palavra.Add(new KeyValuePair<string, int>(resultadoItem.palavra.PadRight(20, ' '), resultadoItem.total));
                
                listaRetorno.Add(artigo);
            }
            return listaRetorno;
        }

        private string ConsultarRss(string url)
        {
            string retorno = string.Empty;
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                retorno = response.Result;
            }
            return retorno;
        }

        private IList<Artigo> ConsultarRss()
        {

            string url = Minuto.Api.Properties.Resources.ResourceManager.GetString("UrlRss");

            string rss = ConsultarRss(url);
            XDocument xmlDocument = XDocument.Parse(rss);
            xmlDocument.Declaration = new XDeclaration("1.0", "utf-8", null);

            IList<Artigo> lista = new List<Artigo>();
            XNamespace ns = "http://purl.org/rss/1.0/modules/content/";
            foreach (XElement xmlElement in xmlDocument.Descendants("item"))
                lista.Add(
                new Artigo()
                {
                    Titulo = Regex.Replace(xmlElement.Element("title").Value, Minuto.Api.Properties.Resources.ResourceManager.GetString("TagHtml"), String.Empty),
                    Descricao = Regex.Replace(Regex.Replace(
                                              Regex.Replace(xmlElement.Element(ns + "encoded").Value.ToLower(),
                                              Minuto.Api.Properties.Resources.ResourceManager.GetString("TagHtml"), " "),
                                              Minuto.Api.Properties.Resources.ResourceManager.GetString("Tag"), " "),
                                              Minuto.Api.Properties.Resources.ResourceManager.GetString("Palavra"), " ")
                });

            return lista;
        }

    }



}
