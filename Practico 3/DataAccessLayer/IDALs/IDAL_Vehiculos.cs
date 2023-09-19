using System.Collections.Generic;
using Shared;

namespace DataAccessLayer.IDALs
{
    public interface IDAL_Vehiculos
    {
        List<Vehiculo> Get();
        Vehiculo Get(long id);
        void Insert(Vehiculo vehiculo);
        void Update(Vehiculo vehiculo);
        void Delete(long id);
    }
}
