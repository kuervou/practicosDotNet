using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DataAccessLayer.IDALs
{
    public interface IDAL_Personas
    {
        void Insert(Persona persona);

        List<Persona> GetPersonas();
    }
}
