using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoClase1
{
    public class Commands
    {
        IBL_Personas _personasBL;

        public Commands(IBL_Personas personasBL)
        {
            _personasBL = personasBL;
        }

        public void AddPersona()
        {
            // Pedimos los datos de la pesona.
            Persona persona = new Persona();
            Console.WriteLine("Ingrese el nombre de la persona: ");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el documento de la persona: ");
            persona.Documento = Console.ReadLine();

            _personasBL.Insert(persona);

            _personasBL.Get(persona.Documento).Print();
        }

        public void UpdatePersona()
        {
            // Pedimos los datos de la pesona.
            Persona persona = new Persona();

            Console.WriteLine("Ingrese el documento de la persona que desea modificar: ");
            persona.Documento = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo nombre: ");
            persona.Nombre = Console.ReadLine();

            int filasAfectadas = _personasBL.Update(persona);

            if (filasAfectadas == 0)
            {
                Console.WriteLine("No se encontró ninguna persona con ese documento.");
                return;
            }

            Persona personaActualizada = _personasBL.Get(persona.Documento);

            if (personaActualizada != null)
            {
                personaActualizada.Print();
            }
            else
            {
                Console.WriteLine("Ocurrió un error al obtener los detalles de la persona actualizada.");
            }
        }

        public void ListPersonas()
        {
            List<Persona> personas = _personasBL.Get();

            Console.WriteLine("Listado de personas:");
            Console.WriteLine("| Documento | Nombre |");

            foreach (Persona persona in personas)
            {
                persona.PrintTable();
            }
        }

        public void RemovePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a eliminar: ");
            string documento = Console.ReadLine();

            _personasBL.Delete(documento);
        }
    }
}
