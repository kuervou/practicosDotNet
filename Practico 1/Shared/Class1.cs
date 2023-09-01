using System;

namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; } = "--Sin Nombre--";

        public string Apellido { get; set; } 

        private string documento = "";

        public string Documento
        {
            get { return documento; }
            set
            {
                if (value.Length < 7)
                    throw new Exception("Formato incorrecto pa");
                else
                    documento = value.ToUpper();
            }
        }

        public DateTime FechaNacimiento { get; set; } 

        public int Edad 
        {
            get
            {
                int age = DateTime.Now.Year - FechaNacimiento.Year;
                if (DateTime.Now.DayOfYear < FechaNacimiento.DayOfYear)
                    age -= 1;

                return age;
            }
        }

        public void Print()
        {
            Console.WriteLine("Persona");
            Console.WriteLine(" Documento: " + Documento);
            Console.WriteLine(" Nombre: " + Nombre + " " + Apellido); 
            Console.WriteLine(" Fecha de Nacimiento: " + FechaNacimiento.ToShortDateString()); 
            Console.WriteLine(" Edad: " + Edad);
        }
    }
}
