using System;

namespace Shared
{
    public class Vehiculo
    {
        public long Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public Persona Propietario { get; set; }

        public void Print()
        {
            Console.WriteLine("-- Vehículo --");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Matrícula: " + Matricula);
            Console.WriteLine("Propietario: ");
            Propietario?.Print();  // Usando el operador de propagación nula para manejar el caso en que Propietario sea null
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Id + " | " + Marca + " | " + Modelo + " | " + Matricula + " | " + (Propietario != null ? Propietario.Documento : "Sin propietario") + " |");
        }
    }
}
