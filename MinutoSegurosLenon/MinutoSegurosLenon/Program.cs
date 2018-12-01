using System;

namespace MinutoSegurosLenon
{
    class Program
    {
        static string caminhoArquivo = @"feed.xml";
        static void Main(string[] args)
        {
            new Negocio.Util().ConsultarPalavra(caminhoArquivo);
            Console.Read();
        }
    }
}