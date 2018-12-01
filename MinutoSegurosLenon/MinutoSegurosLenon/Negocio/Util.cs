using MinutoSegurosLenon.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Linq;

namespace MinutoSegurosLenon.Negocio
{
    public class Util
    {
        public IList<Artigo> ConsultarRss(string caminho)
        {
            IList<Artigo> lista = new List<Artigo>();

            XDocument xmlDocument = XDocument.Load(caminho);
            xmlDocument.Declaration = new XDeclaration("1.0", "utf-8", null);

            XNamespace ns = "http://purl.org/rss/1.0/modules/content/";
            foreach (XElement xmlElement in xmlDocument.Descendants("item"))
                lista.Add(
                new Artigo()
                {
                    Titulo = Regex.Replace(xmlElement.Element("title").Value, "<.*?>", String.Empty),
                    Descricao = Regex.Replace(Regex.Replace(xmlElement.Element(ns + "encoded").Value.ToLower(), 
                                              Properties.Resources.Tag, " "),
                                              Properties.Resources.Palavra, " ")
                });

            return lista;
        }

        public void ConsultarPalavra(string caminhoArquivo)
        {
            foreach (Artigo item in ConsultarRss(caminhoArquivo))
            {
                string[] listaPalavra = item.Descricao.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                IList<string> lista = new List<string>(listaPalavra);
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine(" ");
                Console.WriteLine(String.Concat("ARTIGO: ", item.Titulo));
                Console.WriteLine("--PALAVRAS------------------");
                foreach (var resultadoItem in lista.GroupBy(p => p)
                                                  .Select(g => new { palavra = g.Key, total = g.Count() })
                                                  .OrderByDescending(g => g.total)
                                                  .Take(10))
                {
                    Console.WriteLine(string.Concat("| ", resultadoItem.palavra.PadRight(20, ' '), " | ", resultadoItem.total.ToString().PadLeft(2, '0'), "|"));
                    Console.WriteLine("----------------------------");
                }
            }

        }

    }



}
