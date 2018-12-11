using System;
using System.Text;

namespace MinutoSegurosLenon
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new MinutaApi.Controllers.ArtigoController();
            foreach( var item in x.ConsultarPalavra())
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine(String.Concat("ARTIGO: ", item.Titulo));
                Console.WriteLine("--PALAVRAS------------------");

                foreach(var itemPalavra in item.Palavra)
                {
                    Console.WriteLine(string.Concat("| ", itemPalavra.Key, " | ", itemPalavra.Value, "|"));
                    Console.WriteLine("----------------------------");
                }
            }

            Console.Read();
        }
    }
}