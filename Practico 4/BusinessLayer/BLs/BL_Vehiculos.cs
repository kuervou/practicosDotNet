using Shared;
using DataAccessLayer.IDALs;
using System.Collections.Generic;
using BusinessLayer.IBLs;

namespace BusinessLayer.BLs
{
    public class BL_Vehiculos : IBL_Vehiculos
    {
        private readonly IDAL_Vehiculos _dalVehiculos;

        public BL_Vehiculos(IDAL_Vehiculos dalVehiculos)
        {
            _dalVehiculos = dalVehiculos;
        }

        public List<Vehiculo> GetAllVehiculos() { 
            return _dalVehiculos.Get();
        }
        public Vehiculo GetVehiculoById(long id) { 
            return _dalVehiculos.Get(id);
        }
        public void AddVehiculo(Vehiculo vehiculo)
        {
             _dalVehiculos.Insert(vehiculo);
        }
        public void UpdateVehiculo(Vehiculo vehiculo)
        {
            _dalVehiculos.Update(vehiculo);   
        }
        public void DeleteVehiculo(long id)
        {
            _dalVehiculos.Delete(id);
        }
    }
}
