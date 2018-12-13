namespace Minuto.Console
{
    using Minuto.Entidade;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;

    class Program
    {

        private static string url = "http://localhost:56263/api/artigo/";

        static void Main(string[] args)
        {
            string retorno = string.Empty;
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                retorno = response.Result;
            }

            IList<Artigo> lista = JsonConvert.DeserializeObject<Artigo[]>(retorno);
            foreach (var item in lista)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine(String.Concat("ARTIGO: ", item.Titulo));
                Console.WriteLine("--PALAVRAS------------------");

                foreach (var itemPalavra in item.Palavra)
                {
                    Console.WriteLine(string.Concat("| ", itemPalavra.Key, " | ", itemPalavra.Value, "|"));
                    Console.WriteLine("----------------------------");
                }
            }

            Console.Read();
        }
    }
}