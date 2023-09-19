using DataAccessLayer.IDALs;
using DataAccessLayer.EFModels;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DALs
{
    public class DAL_Vehiculos_EF : IDAL_Vehiculos
    {
        private readonly DBContextCore _dbContext;

        public DAL_Vehiculos_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(long id)
        {
            var vehiculo = _dbContext.Vehiculos.FirstOrDefault(v => v.Id == id);

            if (vehiculo != null)
            {
                _dbContext.Vehiculos.Remove(vehiculo);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El vehículo no existe.");
            }
        }

        public List<Vehiculo> Get()
        {
            return _dbContext.Vehiculos
                             .Select(v => new Vehiculo
                             {
                                 Id = v.Id,
                                 Marca = v.Marca,
                                 Modelo = v.Modelo,
                                 Matricula = v.Matricula,
                                 Propietario = new Persona { Documento = v.Persona.Documento, Nombre = v.Persona.Nombres, Apellidos = v.Persona.Apellidos, Direccion = v.Persona.Direccion, FechaNacimiento = v.Persona.FechaNacimiento, Telefono = v.Persona.Telefono}
                             })
                             .ToList();
        }

        public Vehiculo Get(long id)
        {
            var vehiculo = _dbContext.Vehiculos
                                    .Include(v => v.Persona) 
                                    .FirstOrDefault(v => v.Id == id);

            if (vehiculo != null)
            {
                var result = new Vehiculo
                {
                    Id = vehiculo.Id,
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Matricula = vehiculo.Matricula
                };

                if (vehiculo.Persona != null)  
                {
                    result.Propietario = new Persona
                    {
                        
                        Documento = vehiculo.Persona.Documento,
                        Nombre = vehiculo.Persona.Nombres,
                        Apellidos = vehiculo.Persona.Apellidos,
                        Telefono = vehiculo.Persona.Telefono,
                        Direccion = vehiculo.Persona.Direccion,
                        FechaNacimiento = vehiculo.Persona.FechaNacimiento,
                        
                    };
                }

                return result;
            }
            return null;
        }


        public void Insert(Vehiculo vehiculo)
        {
            if (vehiculo != null)
            {
                var newVehiculo = new Vehiculos
                {
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Matricula = vehiculo.Matricula,
                    PersonaId = _dbContext.Personas.FirstOrDefault(p => p.Documento == vehiculo.Propietario.Documento)?.Id ?? 7
                };

                _dbContext.Vehiculos.Add(newVehiculo);
                _dbContext.SaveChanges();

                // Actualizar el ID del objeto vehiculo con el ID generado
                vehiculo.Id = newVehiculo.Id;
            }
            else
            {
                throw new ArgumentNullException(nameof(vehiculo));
            }
        }


        public void Update(Vehiculo vehiculo)
        {
            var existingVehiculo = _dbContext.Vehiculos.FirstOrDefault(v => v.Id == vehiculo.Id);

            if (existingVehiculo != null)
            {
                existingVehiculo.Marca = vehiculo.Marca;
                existingVehiculo.Modelo = vehiculo.Modelo;
                existingVehiculo.Matricula = vehiculo.Matricula;
                existingVehiculo.PersonaId = _dbContext.Personas.FirstOrDefault(p => p.Documento == vehiculo.Propietario.Documento)?.Id ?? 0;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El vehículo no existe.");
            }
        }
    }
}
