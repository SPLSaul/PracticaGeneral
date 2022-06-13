using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticaGeneral
{
    class Program
    {        static void Main(string[] args)
        {
            Crear creacion = new Crear();            
            int opc;
            do
            {
                Console.WriteLine("Menu\n(1)Crear un documento\n(2)Imprimir documento\n(3)Salir del programa");
                opc = int.Parse(Console.ReadLine());
                creacion.Limpiar();
                switch (opc)
                {
                    case 1:
                        creacion.Lectura();
                        creacion.Limpiar();
                        break;
                    case 2:
                        creacion.Imprimir();
                        creacion.Limpiar();
                        break;
                    case 3:
                        Console.WriteLine("Programa finalizado");
                        creacion.Limpiar();
                        break;

                }
            } while (opc != 3);
        }       
    }
    class Limpieza
    {
        public void Limpiar()
        {
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
    class Crear:Limpieza
    {        
        public void Lectura()
        {
             
            StreamWriter escritor = new StreamWriter("99.txt",true);
            try
            {                
                Console.Write("Ingresa la cancion: ");
                string cancion = Console.ReadLine();
                Limpiar();
                Console.Write("Ingresa la duracion: ");
                float duracion = float.Parse(Console.ReadLine());
                Limpiar();
                Console.Write("Ingresa el artista: ");
                string artista = Console.ReadLine();
                escritor.WriteLine($" Titulo {cancion}\nDuracion {duracion}\nArtista: {artista}");
                
            }catch(IOException e)
            {
                Console.WriteLine($"Error en la creacion {e.Message}");
            }
            finally
            {
                escritor.Close();
            }            
        }
        public void Imprimir()
        {
            StreamReader lector = new StreamReader("99.txt",true);
            try
            {
                int c = lector.Read();
                while(c != -1)
                {
                    c = lector.Read();
                    char letra = (char)c;
                    Console.Write(letra);
                }

            }
            catch(IOException e)
            {
                Console.WriteLine($"Error en la lectura {e.Message}");
            }
            finally
            {
                //
                lector.Close();
            }
        }
    }
}
