namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; } = "-- Sin Nombre --";

        private string documento = "";
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length >= 7)
                {
                    documento = value;
                }
                else
                {
                    throw new Exception("El formato del documento no es correcto.");
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Documento: " + Documento);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Documento + " | " + Nombre + " |");
        }
    }
}