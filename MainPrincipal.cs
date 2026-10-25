class MainPrincipal{
    public static void Main(string [] args)
    {
        Practica21 nuevo = new Practica21();

        bool salir = false;
        while (salir != true)
        {
            Console.WriteLine("\nGESTIÓN DE ESCRITURA Y LECTURA DE FICHEROS\n");
            Console.WriteLine("1. Crear un nuevo fichero.\n");
            Console.WriteLine("2. Añadir registros en el fichero.\n");
            Console.WriteLine("3. Eliminar todos los registros del fichero.\n");
            Console.WriteLine("4. Eliminar el fichero.\n");
            Console.WriteLine("5. Visualizar los registros.\n");
            Console.WriteLine("6. Cerrar la aplicación.\n");
            Console.WriteLine("Pulse un número del 1 al 6:\n");

        
        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                nuevo.CrearNuevoFichero();
                break;
            case "2":
                nuevo.AddFichero();
                break;
            case "3":
                nuevo.EliminarRegistros();
                break;
            case "4":
                nuevo.EliminarFichero();
                break;
            case "5":
                nuevo.MostrarRegistros();
                break;
            case "6":
                salir = true;
                nuevo.CerrarAplicacion();
                break;
            default:
                Console.WriteLine("Opción no válida, prueba otra vez o sal usando el 6");
                break;
            
        }
        }
    }
}