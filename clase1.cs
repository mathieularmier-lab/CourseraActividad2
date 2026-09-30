namespace ApuntesClaseDyA;

public class ActCur2
{
    // Clase que representa cada nodo del árbol
    private class Nodo
    {
        public string palabra;
        public int repeticiones;
        public Nodo izquierdo;
        public Nodo derecho;

        public Nodo(string palabra)
        {
            this.palabra = palabra;
            repeticiones = 1;
            izquierdo = null;
            derecho = null;
        }
    }

    private Nodo raiz;

    // Divide el texto en palabras y las inserta en el árbol
    public void DivINPT(string str)
    {
        string[] palabras = str.Split(
            new char[] { ' ', ',', '.', ';', ':', '!', '?', '¿', '¡' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string palabra in palabras)
        {
            Insertar(palabra);
        }
    }

    // Inserta una palabra en el árbol
    public void Insertar(string palabra)
    {
        raiz = InsertarRecursivo(raiz, palabra);
    }

    private Nodo InsertarRecursivo(Nodo actual, string palabra)
    {
        // Si no existe nodo, se crea
        if (actual == null)
        {
            return new Nodo(palabra);
        }

        int comparacion = string.Compare(
            palabra,
            actual.palabra,
            StringComparison.OrdinalIgnoreCase
        );

        // Menor alfabéticamente
        if (comparacion < 0)
        {
            actual.izquierdo = InsertarRecursivo(
                actual.izquierdo,
                palabra
            );
        }

        // Mayor alfabéticamente
        else if (comparacion > 0)
        {
            actual.derecho = InsertarRecursivo(
                actual.derecho,
                palabra
            );
        }

        // Palabra repetida
        else
        {
            actual.repeticiones++;
        }

        return actual;
    }

    // -----------------------------
    // INORDEN
    // Izquierda - Raíz - Derecha
    // -----------------------------

    public void Inorden()
    {
        Console.Write("Inorden: ");
        InordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void InordenRecursivo(Nodo actual)
    {
        if (actual != null)
        {
            InordenRecursivo(actual.izquierdo);

            ImprimirNodo(actual);

            InordenRecursivo(actual.derecho);
        }
    }

    // -----------------------------
    // PREORDEN
    // Raíz - Izquierda - Derecha
    // -----------------------------

    public void Preorden()
    {
        Console.Write("Preorden: ");
        PreordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PreordenRecursivo(Nodo actual)
    {
        if (actual != null)
        {
            ImprimirNodo(actual);

            PreordenRecursivo(actual.izquierdo);
            PreordenRecursivo(actual.derecho);
        }
    }

    // -----------------------------
    // POSTORDEN
    // Izquierda - Derecha - Raíz
    // -----------------------------

    public void Postorden()
    {
        Console.Write("Postorden: ");
        PostordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PostordenRecursivo(Nodo actual)
    {
        if (actual != null)
        {
            PostordenRecursivo(actual.izquierdo);
            PostordenRecursivo(actual.derecho);

            ImprimirNodo(actual);
        }
    }

    // Imprime palabra y repeticiones
    private void ImprimirNodo(Nodo nodo)
    {
        if (nodo.repeticiones > 1)
        {
            Console.Write(
                nodo.palabra + "(x" + nodo.repeticiones + ") "
            );
        }
        else
        {
            Console.Write(nodo.palabra + " ");
        }
    }

    // -----------------------------
    // TOTAL DE NODOS
    // -----------------------------

    public int TotalNodos()
    {
        return TotalNodosRecursivo(raiz);
    }

    private int TotalNodosRecursivo(Nodo actual)
    {
        if (actual == null)
        {
            return 0;
        }

        return 1
            + TotalNodosRecursivo(actual.izquierdo)
            + TotalNodosRecursivo(actual.derecho);
    }

    // -----------------------------
    // NODOS INTERNOS
    // -----------------------------

    public int NodosInternos()
    {
        return NodosInternosRecursivo(raiz);
    }

    private int NodosInternosRecursivo(Nodo actual)
    {
        if (actual == null)
        {
            return 0;
        }

        // Si no tiene hijos es una hoja
        if (actual.izquierdo == null &&
            actual.derecho == null)
        {
            return 0;
        }

        return 1
            + NodosInternosRecursivo(actual.izquierdo)
            + NodosInternosRecursivo(actual.derecho);
    }

    // -----------------------------
    // MÁXIMO VALOR ALFABÉTICO
    // -----------------------------

    public string Maximo()
    {
        if (raiz == null)
        {
            return "";
        }

        Nodo actual = raiz;

        // El mayor siempre está hasta la derecha
        while (actual.derecho != null)
        {
            actual = actual.derecho;
        }

        return actual.palabra;
    }

    // -----------------------------
    // HOJAS
    // -----------------------------

    public void MostrarHojas()
    {
        Console.Write("Hojas: ");
        MostrarHojasRecursivo(raiz);
        Console.WriteLine();
    }

    private void MostrarHojasRecursivo(Nodo actual)
    {
        if (actual == null)
        {
            return;
        }

        if (actual.izquierdo == null &&
            actual.derecho == null)
        {
            ImprimirNodo(actual);
            return;
        }

        MostrarHojasRecursivo(actual.izquierdo);
        MostrarHojasRecursivo(actual.derecho);
    }

    // -----------------------------
    // MOSTRAR NODOS INTERNOS
    // -----------------------------

    public void MostrarNodosInternos()
    {
        Console.Write("Nodos internos: ");
        MostrarInternosRecursivo(raiz);
        Console.WriteLine();
    }

    private void MostrarInternosRecursivo(Nodo actual)
    {
        if (actual == null)
        {
            return;
        }

        if (actual.izquierdo != null ||
            actual.derecho != null)
        {
            ImprimirNodo(actual);
        }

        MostrarInternosRecursivo(actual.izquierdo);
        MostrarInternosRecursivo(actual.derecho);
    }
}