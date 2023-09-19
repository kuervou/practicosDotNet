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
        IBL_Vehiculos _vehiculosBL;

        public Commands(IBL_Personas personasBL, IBL_Vehiculos vehiculosBL)
        {
            _personasBL = personasBL;
            _vehiculosBL = vehiculosBL;

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

            Console.WriteLine("Persona eliminada correctamente.");
        }

        public void AddVehiculo()
        {
            // Pedimos los datos del vehículo.
            Vehiculo vehiculo = new Vehiculo();
            Console.WriteLine("Ingrese la marca del vehículo: ");
            vehiculo.Marca = Console.ReadLine();
            Console.WriteLine("Ingrese el modelo del vehículo: ");
            vehiculo.Modelo = Console.ReadLine();
            Console.WriteLine("Ingrese la matrícula del vehículo: ");
            vehiculo.Matricula = Console.ReadLine();

            // Pide el documento del propietario
            Console.WriteLine("Ingrese el documento del propietario del vehículo: ");
            string documentoPropietario = Console.ReadLine();

            // Buscar el propietario en la base de datos
            Persona propietario = _personasBL.Get(documentoPropietario);

            if (propietario == null)
            {
                Console.WriteLine("No se encontró un propietario con ese documento. Intente de nuevo.");
                return;
            }

            // Asocia el propietario al vehículo
            vehiculo.Propietario = propietario;

            // Guarda el vehículo
            _vehiculosBL.AddVehiculo(vehiculo);

            // Mostrar el vehículo agregado 
            _vehiculosBL.GetVehiculoById(vehiculo.Id).Print();
        }


        public void ListVehiculos()
        {
            List<Vehiculo> vehiculos = _vehiculosBL.GetAllVehiculos();

            Console.WriteLine("Listado de vehículos:");
            Console.WriteLine("| Id | Marca | Modelo | Matricula |");

            foreach (Vehiculo vehiculo in vehiculos)
            {
                vehiculo.PrintTable();
            }
        }

        public void RemoveVehiculo()
        {
            Console.WriteLine("Ingrese el ID del vehículo a eliminar: ");
            long id = long.Parse(Console.ReadLine());

            _vehiculosBL.DeleteVehiculo(id);

            Console.WriteLine("Vehículo eliminado correctamente.");
        }
    }
}
