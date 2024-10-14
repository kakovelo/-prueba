using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final
{
    internal class Program
    {
        ///crear el struct va afuera del main y el public es necesario para dsp poder usarlo/
        public struct ClientesStruct
        {
            public string nombreCliente;
            public string apellidoCliente;
            public int dniCliente;
            public string mailCliente;
            public int telefonoCliente;
            public bool estadoCliente;

            ///crear el constructor/
            public ClientesStruct(string nombre, string apellido, int dni, string mail, int telefono, bool estado)
            {
                nombreCliente = nombre;
                apellidoCliente = apellido;
                dniCliente = dni;
                mailCliente = mail;
                telefonoCliente = telefono;
                estadoCliente = estado;
            }
        }
        //funcion agregar
        static ClientesStruct[] AñadirClientes(ClientesStruct[] array)
        {
            Console.WriteLine(" Cuantos clientes quiere añadir");
            int cantidadClientes = int.Parse(Console.ReadLine());

            ClientesStruct[] nuevoArray = new ClientesStruct[array.Length + cantidadClientes];
            int contador = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (array.Length > 0)
                {
                    nuevoArray[contador] = array[j];
                    contador++;
                }
            }
            for (int i = contador; i < nuevoArray.Length; i++)
            {
                if (i >= array.Length || array.Length == 0)
                {
                    Console.WriteLine($"Ingrese los datos del cliente {i + 1}:");

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Apellido: ");
                    string apellido = Console.ReadLine();

                    Console.Write("DNI: ");

                    //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
                    int dni;
                    while (!int.TryParse(Console.ReadLine(), out dni))
                    {
                        Console.WriteLine("DNI inválido. Inténtelo de nuevo.");
                    }

                    Console.Write("Email: ");
                    string mail = Console.ReadLine();

                    Console.Write("Teléfono: ");

                    //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
                    int telefono;
                    while (!int.TryParse(Console.ReadLine(), out telefono))
                    {
                        Console.WriteLine("Teléfono inválido. Inténtelo de nuevo.");
                    }

                    //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
                    Console.Write("Estado (true/false): ");
                    bool estado;
                    while (!bool.TryParse(Console.ReadLine(), out estado))
                    {
                        Console.WriteLine("Estado inválido. Debe ser true o false.");
                    }

                    nuevoArray[i] = new ClientesStruct(nombre, apellido, dni, mail, telefono, estado);

                    Console.WriteLine();
                }
            }
            return nuevoArray;
        }

        static ClientesStruct[] EliminarCliente(ClientesStruct[] array)
        {
            Console.WriteLine("Ingrese el DNI del cliente que desea eliminar:");
            int dniEliminar;
            while (!int.TryParse(Console.ReadLine(), out dniEliminar))
            {
                Console.WriteLine("DNI inválido. Inténtelo de nuevo.");
            }

            int indiceEliminar = BuscarCliente(array, dniEliminar);

            // si no lo encontramos
            if (indiceEliminar == -1)
            {
                Console.WriteLine("Cliente no encontrado.");
                return array;
            }

            // Creamos un nuevo array con un tamaño reducido
            ClientesStruct[] nuevoArray = new ClientesStruct[array.Length - 1];
            int contador = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i != indiceEliminar) // Copiamos todos los elementos excepto el que vamos a eliminar
                {
                    nuevoArray[contador] = array[i];
                    contador++;
                }
            }

            Console.WriteLine("Cliente eliminado correctamente.");
            return nuevoArray;
        }

        static int BuscarCliente(ClientesStruct[] array, int dni)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].dniCliente == dni)
                {
                    return i; // Retorna el índice del cliente si se encuentra
                }
            }
            return -1; // Retorna -1 si no se encuentra el cliente
        }
    }
}
