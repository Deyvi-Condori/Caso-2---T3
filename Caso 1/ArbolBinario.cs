using ConfeccionesKAM;

class Program
{
    static void Main(string[] args)
    {
        Arbol arbol = new Arbol();

        arbol.Insertar(new Nodo(1164, "ROJO", "LARGA", 34, "PLÁSTICO", "CLÁSICO", 206.00, "SI"));
        arbol.Insertar(new Nodo(457, "VERDE", "CORTA", 36, "TRANSPARENTE", "POLAR", 239.00, "NO"));

        int opcion = 0;
        do
        {
            try
            {
                Console.Clear(); 
                Console.WriteLine("\n-============== MENÚ ==============\n");
                Console.WriteLine("1. Agregar una nueva chompa");
                Console.WriteLine("2. Buscar una chompa");
                Console.WriteLine("3. Eliminar una chompa");
                Console.WriteLine("4. Reporte por color");
                Console.WriteLine("5. Recorrido PreOrden");
                Console.WriteLine("6. Altura del árbol");
                Console.WriteLine("7. Contar chompas por empaquetado");
                Console.WriteLine("8. Salir");
                Console.WriteLine("\n===================================\n");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                if (opcion < 1 || opcion > 8)
                {
                    Console.WriteLine("Por favor, ingrese un número entre 1 y 8.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n=================================\n");
                        Console.Write("\t Ingrese clave \n");
                        Console.WriteLine("\n=================================\n");
                        int clave = int.Parse(Console.ReadLine());

                        // Selección del color
                        Console.Clear();
                        Console.WriteLine("\n====================================\n");
                        Console.WriteLine("Seleccione el color de la chompa\n---------------------------------\nRojo, Verde, Azul, Blanco, Amarillo");
                        Console.WriteLine("\n====================================\n");

                        string color = Console.ReadLine().ToUpper();
                        while (color != "ROJO" && color != "VERDE" && color != "AZUL" && color != "BLANCO" && color != "AMARILLO")
                        {
                            Console.WriteLine("Color no válido. Seleccione un color de la lista: Rojo, Verde, Azul, Blanco, Amarillo");
                            color = Console.ReadLine().ToUpper();
                        }

                        // Selección del tipo de manga
                        Console.Clear();
                        Console.WriteLine("\n=================================\n");
                        Console.WriteLine("Seleccione el tipo de manga\n---------------------------------\n\tLarga o Corta");
                        Console.WriteLine("\n=================================\n");
                        string tipoManga = Console.ReadLine().ToUpper();
                        while (tipoManga != "LARGA" && tipoManga != "CORTA")
                        {
                            Console.WriteLine("Tipo de manga no válido. Seleccione Larga o Corta.");
                            tipoManga = Console.ReadLine().ToUpper();
                        }

                        // Selección de la talla
                        Console.Clear();
                        Console.WriteLine("\n=================================\n");
                        Console.WriteLine("        Seleccione la talla\n---------------------------------\n      34, 36, 38, 40, 42, 44");
                        Console.WriteLine("\n=================================\n");
                        int talla = int.Parse(Console.ReadLine());
                        while (talla != 34 && talla != 36 && talla != 38 && talla != 40 && talla != 42 && talla != 44)
                        {
                            Console.WriteLine("Talla no válida. Seleccione una talla de la lista: 34, 36, 38, 40, 42, 44");
                            talla = int.Parse(Console.ReadLine());
                        }

                        // Selección del empaquetado
                        Console.Clear();
                        Console.WriteLine("\n=================================\n");
                        Console.WriteLine("Seleccione el tipo de empaquetado\n---------------------------------\nPlastico, Transparente, Sellado");
                        Console.WriteLine("\n=================================\n");
                        string empaquetado = Console.ReadLine().ToUpper();
                        while (empaquetado != "PLASTICO" && empaquetado != "TRANSPARENTE" && empaquetado != "SELLADO")
                        {
                            Console.WriteLine("Empaquetado no válido. Seleccione uno de la lista: Plástico, Transparente, Sellado");
                            empaquetado = Console.ReadLine().ToUpper();
                        }

                        // Selección del diseño
                        Console.Clear();
                        Console.WriteLine("\n=================================\n");
                        Console.WriteLine("Seleccione el diseño\n---------------------------------\nClasico, Polar, Elegante");
                        Console.WriteLine("\n=================================\n");
                        string diseño = Console.ReadLine().ToUpper();
                        while (diseño != "CLASICO" && diseño != "POLAR" && diseño != "ELEGANTE")
                        {
                            Console.WriteLine("Diseño no válido. Seleccione uno de la lista: Clasico, Polar, Elegante");
                            diseño = Console.ReadLine().ToUpper();
                        }

                        // Selección del bordado
                        Console.Clear();
                        Console.WriteLine("\n=================================\n");
                        Console.WriteLine("    ¿La chompa tiene bordado?\n---------------------------------\n\t      (SI/NO)");
                        Console.WriteLine("\n=================================\n");
                        string bordado = Console.ReadLine().ToUpper();

                        while (bordado != "SI" && bordado != "NO")

                        {
                            Console.WriteLine("Respuesta no válida. Ingrese SI o NO.");
                            bordado = Console.ReadLine().ToUpper();
                        }

                        // Generación de precio aleatorio entre 115 y 250
                        Random rand = new Random();
                        double precio = rand.Next(115, 251); // Precio aleatorio entre 115 y 250

                        // Agregar la chompa al árbol
                        arbol.Insertar(new Nodo(clave, color, tipoManga, talla, empaquetado, diseño, precio, bordado));
                        Console.WriteLine("\n=================================\n");
                        Console.WriteLine($"Chompa agregada correctamente con un precio de {precio}.");
                        Console.WriteLine("\n=================================");
                        break;
                    case 2:
                        Console.Write("Ingrese clave a buscar: ");
                        clave = int.Parse(Console.ReadLine());
                        Nodo encontrado = arbol.Buscar(clave);
                        if (encontrado != null)
                            Console.WriteLine($"Clave: {encontrado.Clave}, Color: {encontrado.Color}");
                        else
                            Console.WriteLine("No encontrado");
                        break;
                    case 3:
                        Console.Write("Ingrese clave a eliminar: ");
                        clave = int.Parse(Console.ReadLine());
                        arbol.Eliminar(clave);
                        Console.WriteLine("Chompa eliminada correctamente.");
                        break;
                    case 4:
                        Console.Write("Ingrese color para reporte: ");
                        color = Console.ReadLine();
                        arbol.ReportePorColor(color);
                        break;
                    case 5:
                        arbol.PreOrden();
                        break;
                    case 6:
                        Console.WriteLine($"Altura del árbol: {arbol.Altura()}");
                        break;
                }

                if (opcion != 8)
                {
                    Console.WriteLine("\nMuchas gracias por agregar el producto, presione enter para continuar.");
                    Console.ReadKey();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Solo se aceptan números entre 1 y 8.");
            }
        } while (opcion != 8);
    }
}
