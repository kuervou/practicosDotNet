using Shared;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Registro de Personas (Escribe 'exit' para salir y mostrar resultados)");

        IDAL_Personas _personas = new DAL_Personas();

        while (true)
        {
            try
            {
                Console.WriteLine("Nueva Persona");

                Console.WriteLine("Nombre:");
                var nombre = Console.ReadLine();

                if (nombre.ToLower() == "exit")
                    break;

                Console.WriteLine("Apellido:");
                var apellido = Console.ReadLine();

                Console.WriteLine("Documento:");
                var documento = Console.ReadLine();

                Console.WriteLine("Fecha de Nacimiento (formato YYYY-MM-DD):");
                DateTime fechaNacimiento;
                while (!DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
                {
                    Console.WriteLine("Fecha inválida. Por favor, ingrese nuevamente en el formato YYYY-MM-DD:");
                }

                Persona persona = new Persona
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Documento = documento,
                    FechaNacimiento = fechaNacimiento
                };

                _personas.Insert(persona);

                // Si deseas mostrar cada persona registrada inmediatamente después de su ingreso:
                // _personas.GetPersonas().ForEach(p => p.Print());
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        // Mostrar todas las personas ordenadas por edad después de finalizar el ingreso
        Console.WriteLine("\nPersonas registradas ordenadas por edad:");
        foreach (var persona in _personas.GetPersonas().OrderBy(p => p.Edad))
        {
            persona.Print();
        }
    }
}
