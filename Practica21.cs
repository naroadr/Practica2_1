using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;

class Practica21
{
    private string nombre;
    private string registro;
    private string carpeta = "ficheros";

    public Practica21(String pNom, string pRegistro)
    {
        this.nombre = pNom;
        this.registro = pRegistro;
    }
    public Practica21(){} 
    public string getNombre()
    {
        return this.nombre;
    }
    public void setNombre(string pNom)
    {
        this.nombre = pNom;
    }
    public string getRegistro()
    {
        return this.registro;
    }
    public void setRegistro(string pRegistro)
    {
        this.registro = pRegistro;
    }
    public void CrearNuevoFichero()
    {
        Console.Clear();
        try
        {
            Directory.CreateDirectory(carpeta);
            Console.WriteLine("Introduce el nombre del fichero de texto: ");
            nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("No se ha añadido nada en el nombre del fichero, no es válido.");
                return;
            } 
            string ruta = Path.Combine(carpeta, nombre);
            if (File.Exists(ruta))
            {
                Console.WriteLine("El nombre del fichero ya existe.");
            }
            else
            {
                using (FileStream archivo = File.Create(ruta));
                Console.WriteLine("Archivo creado correctamente.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fallo al crear el nuevo fichero: "+ ex.Message);
        }
        Console.WriteLine("Volviendo al menú principal en unos segundos.");
        Thread.Sleep(2500);
        Console.Clear();
    }    
    public void AddFichero()
    {
        try
        {
            Directory.CreateDirectory(carpeta);
            Console.WriteLine("Introduce el nombre del fichero: ");
            nombre = Console.ReadLine();
            string ruta = Path.Combine(carpeta, nombre);
            if (!File.Exists(ruta))
            {
                Console.WriteLine("El fichero no existe, créalo desde el menú primero.");
                Console.WriteLine("Volviendo al menú principal en unos segundos.");
                Thread.Sleep(2500);
                Console.Clear();
                return;
            }
            Console.Write("Introduce el registro que quieres añadir: ");
            registro = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(registro))
            {
                Console.WriteLine("No se ha añadido nada en el registro.");
                Console.WriteLine("Volviendo al menú principal en unos segundos.");
                Thread.Sleep(2500);
                Console.Clear();
                return;
            }
            List<string> lineas = File.ReadAllLines(ruta).ToList();
            lineas.Add(registro);
            File.WriteAllLines(ruta, lineas);
            Console.WriteLine("Registro añadido correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fallo al añadir el registro en el fichero: "+ ex.Message);
        }
        Console.WriteLine("Volviendo al menú principal en unos segundos.");
        Thread.Sleep(2500);
        Console.Clear();
    }
    public void EliminarRegistros()
    {
        try
        {
            Console.WriteLine("Introduce el nombre del fichero para borrar todos los registros: ");   
            nombre = Console.ReadLine();
            string ruta = Path.Combine(carpeta, nombre);
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
                File.WriteAllText(ruta, string.Empty);
                Console.WriteLine("Todos los registros han sido eliminados correctamente."); 
            }
            else
            {
                Console.WriteLine("Ese fichero no existe.");
                Console.WriteLine("Volviendo al menú principal en unos segundos.");
                Thread.Sleep(2500);
                Console.Clear();
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fallo al eliminar el registro en el fichero: "+ ex.Message);
        }
        Console.WriteLine("Volviendo al menú principal en unos segundos.");
        Thread.Sleep(2500);
        Console.Clear();
    }
    public void EliminarFichero()
    {
        try
        {
            Console.Write("Introduce el nombre del fichero a eliminar: ");
            string nombre = Console.ReadLine();
            string ruta = Path.Combine(carpeta, nombre);
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
                Console.WriteLine("Fichero eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Ese fichero no existe.");
                Console.WriteLine("Volviendo al menú principal en unos segundos.");
                Thread.Sleep(2500);
                Console.Clear();
                return;
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fallo al eliminar el fichero: "+ ex.Message);
        }
        Console.WriteLine("Volviendo al menú principal en unos segundos.");
        Thread.Sleep(2500);
        Console.Clear();
    }
    public void MostrarRegistros()
    {
        try
        {
            Console.WriteLine("Introduce el nombre del fichero para ver los registros: ");
            nombre = Console.ReadLine();
            string ruta = Path.Combine(carpeta, nombre);
            if (File.Exists(ruta))
            {
                string [] lineas = File.ReadAllLines(ruta);
                Console.WriteLine("Todos los registros: ");
                foreach (string linea in lineas)
                {
                    Console.WriteLine(linea);
                }
            } else
            {
                Console.WriteLine("El fichero no existe, créalo y luego vuelve a intentarlo.");
                Console.WriteLine("¿Quieres crear un fichero nuevo?");
                Console.WriteLine("1. Crear nuevo fichero.");
                Console.WriteLine("2. Volver al menú.");
                Console.WriteLine("0. Salir de la aplicación.");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CrearNuevoFichero();
                        break;
                    case "2":
                        break;
                    case "0":
                        CerrarAplicacion();
                        break;
                    default: 
                        Console.WriteLine("No es un carácter válido, pulse un número del 0 al 2.");
                        break;
                }
            }
        } catch (Exception ex)
        {
            Console.WriteLine("Fallo al mostrar los registros: "+ ex.Message);

        }
        Console.WriteLine("Volviendo al menú principal en unos segundos.");
        Thread.Sleep(3000);
        Console.Clear();

    }
    public void CerrarAplicacion()
    {
        Console.WriteLine("Gracias por usar la aplicación.");
    }

         
}