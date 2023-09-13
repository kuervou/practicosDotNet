using Shared;
using System.Collections.Generic;

namespace BusinessLayer.IBLs
{
    public interface IBL_Vehiculos
    {
        List<Vehiculo> GetAllVehiculos();
        Vehiculo GetVehiculoById(long id);
        void AddVehiculo(Vehiculo vehiculo);
        void UpdateVehiculo(Vehiculo vehiculo);
        void DeleteVehiculo(long id);
    }
}
