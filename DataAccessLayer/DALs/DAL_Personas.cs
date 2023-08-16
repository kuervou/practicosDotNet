using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.IDALs;
using Shared;
// EN la practica este data access layer seria el responsable de persistir las cosas en la bd
namespace DataAccessLayer.DALs
{
    public class DAL_Personas : IDAL_Personas
    {
        private List<Persona> personas = new List<Persona>();

        public void Insert(Persona persona)
        {
            personas.Add(persona);
        }

        public List<Persona> GetPersonas()
        {
            return personas;
        }
    }
}
