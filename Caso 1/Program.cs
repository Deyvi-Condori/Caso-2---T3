using System;

namespace ConfeccionesKAM
{
    // Clase Nodo para el árbol
    class Nodo
    {
        public int Clave;
        public string Color;
        public string TipoManga;
        public int Talla;
        public string Empaquetado;
        public string Diseño;
        public double Precio;
        public string Bordado;
        public Nodo Izquierda, Derecha;

        public Nodo(int clave, string color, string tipoManga, int talla, string empaquetado, string diseño, double precio, string bordado)
        {
            Clave = clave;
            Color = color;
            TipoManga = tipoManga;
            Talla = talla;
            Empaquetado = empaquetado;
            Diseño = diseño;
            Precio = precio;
            Bordado = bordado;
            Izquierda = Derecha = null;
        }
    }

    // Clase Árbol Binario de Búsqueda
    class Arbol
    {
        private Nodo Raiz;

        public void Insertar(Nodo nuevo)
        {
            Raiz = InsertarRecursivo(Raiz, nuevo);
        }

        private Nodo InsertarRecursivo(Nodo actual, Nodo nuevo)
        {
            if (actual == null) return nuevo;

            if (nuevo.Clave < actual.Clave)
                actual.Izquierda = InsertarRecursivo(actual.Izquierda, nuevo);
            else if (nuevo.Clave > actual.Clave)
                actual.Derecha = InsertarRecursivo(actual.Derecha, nuevo);

            return actual;
        }

        public Nodo Buscar(int clave)
        {
            return BuscarRecursivo(Raiz, clave);
        }

        private Nodo BuscarRecursivo(Nodo actual, int clave)
        {
            if (actual == null || actual.Clave == clave) return actual;

            if (clave < actual.Clave)
                return BuscarRecursivo(actual.Izquierda, clave);

            return BuscarRecursivo(actual.Derecha, clave);
        }

        public void Eliminar(int clave)
        {
            Raiz = EliminarRecursivo(Raiz, clave);
        }

        private Nodo EliminarRecursivo(Nodo actual, int clave)
        {
            if (actual == null) return null;

            if (clave < actual.Clave)
                actual.Izquierda = EliminarRecursivo(actual.Izquierda, clave);
            else if (clave > actual.Clave)
                actual.Derecha = EliminarRecursivo(actual.Derecha, clave);
            else
            {
                if (actual.Izquierda == null) return actual.Derecha;
                if (actual.Derecha == null) return actual.Izquierda;

                Nodo sucesor = EncontrarMinimo(actual.Derecha);
                actual.Clave = sucesor.Clave;
                actual.Derecha = EliminarRecursivo(actual.Derecha, sucesor.Clave);
            }
            return actual;
        }

        private Nodo EncontrarMinimo(Nodo actual)
        {
            while (actual.Izquierda != null)
                actual = actual.Izquierda;
            return actual;
        }

        public void PreOrden()
        {
            PreOrdenRecursivo(Raiz);
        }

        private void PreOrdenRecursivo(Nodo actual)
        {
            if (actual != null)
            {
                Console.WriteLine($"Clave: {actual.Clave}, Color: {actual.Color}, Precio: {actual.Precio}");
                PreOrdenRecursivo(actual.Izquierda);
                PreOrdenRecursivo(actual.Derecha);
            }
        }

        public int Altura()
        {
            return AlturaRecursiva(Raiz);
        }

        private int AlturaRecursiva(Nodo actual)
        {
            if (actual == null) return 0;

            int alturaIzquierda = AlturaRecursiva(actual.Izquierda);
            int alturaDerecha = AlturaRecursiva(actual.Derecha);

            return Math.Max(alturaIzquierda, alturaDerecha) + 1;
        }

        public void ReportePorColor(string color)
        {
            ReportePorColorRecursivo(Raiz, color);
        }

        private void ReportePorColorRecursivo(Nodo actual, string color)
        {
            if (actual != null)
            {
                if (actual.Color == color)
                    Console.WriteLine($"Clave: {actual.Clave}, Diseño: {actual.Diseño}, Precio: {actual.Precio}");
                ReportePorColorRecursivo(actual.Izquierda, color);
                ReportePorColorRecursivo(actual.Derecha, color);
            }
        }

        public int ContarPorEmpaquetado(string empaquetado)
        {
            return ContarPorEmpaquetadoRecursivo(Raiz, empaquetado);
        }

        private int ContarPorEmpaquetadoRecursivo(Nodo actual, string empaquetado)
        {
            if (actual == null) return 0;

            int count = actual.Empaquetado == empaquetado ? 1 : 0;
            return count + ContarPorEmpaquetadoRecursivo(actual.Izquierda, empaquetado) + ContarPorEmpaquetadoRecursivo(actual.Derecha, empaquetado);
        }
    }
}
