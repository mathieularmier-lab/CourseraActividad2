using System;

namespace ApuntesClaseDyA
{
    class Program
    {
        static void Main(string[] args)
        {
            ActCur2 arbol = new ActCur2();

            Console.WriteLine("Escribe una oración:");
            string texto = Console.ReadLine();

            arbol.DivINPT(texto);

            Console.WriteLine();
            Console.WriteLine("RECORRIDOS");
            Console.WriteLine("--------------------");

            arbol.Inorden();
            arbol.Preorden();
            arbol.Postorden();

            Console.WriteLine();
            Console.WriteLine("INFORMACIÓN");
            Console.WriteLine("--------------------");

            Console.WriteLine(
                "Total de nodos: " + arbol.TotalNodos()
            );

            Console.WriteLine(
                "Nodos internos: " + arbol.NodosInternos()
            );

            Console.WriteLine(
                "Máximo alfabético: " + arbol.Maximo()
            );

            Console.WriteLine();
            arbol.MostrarHojas();
            arbol.MostrarNodosInternos();
        }
    }
}










