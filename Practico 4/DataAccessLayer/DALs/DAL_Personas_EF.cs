using DataAccessLayer.IDALs;
using DataAccessLayer.EFModels;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private readonly DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            var persona = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);

            if (persona != null)
            {
                _dbContext.Personas.Remove(persona);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("La persona no existe.");
            }
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona
                             {
                                 Documento = p.Documento,
                                 Nombre = p.Nombres,
                                 Apellidos = p.Apellidos,
                                 Telefono = p.Telefono,
                                 Direccion = p.Direccion,
                                 FechaNacimiento = p.FechaNacimiento,
                                 Vehiculos = p.Vehiculos.Select(v => new Vehiculo
                                 {
                                     Id = v.Id,
                                     Marca = v.Marca,
                                     Modelo = v.Modelo,
                                     Matricula = v.Matricula,
                                    
                                 }).ToList()
                             })
                             .ToList();
        }

        public Persona Get(string documento)
        {
            var persona = _dbContext.Personas
                                    .Include(p => p.Vehiculos) 
                                    .FirstOrDefault(p => p.Documento == documento);

            if (persona != null)
            {
                return new Persona
                {
                    Documento = persona.Documento,
                    Nombre = persona.Nombres,  
                    Apellidos = persona.Apellidos,
                    Telefono = persona.Telefono,
                    Direccion = persona.Direccion,
                    FechaNacimiento = persona.FechaNacimiento,
                    Vehiculos = persona.Vehiculos.Select(v => new Vehiculo
                    {
                        Id = v.Id,
                        Marca = v.Marca,
                        Modelo = v.Modelo,
                        Matricula = v.Matricula
                        
                    }).ToList()
                };
            }
            return null;
        }


        public void Insert(Persona persona)
        {
            if (persona != null)
            {
                var newPersona = new Personas
                {
                    Documento = persona.Documento,
                    Nombres = persona.Nombre,
                    Apellidos = persona.Apellidos,
                    Telefono = persona.Telefono,
                    Direccion = persona.Direccion,
                    FechaNacimiento = persona.FechaNacimiento
                };

                _dbContext.Personas.Add(newPersona);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(persona));
            }
        }

        public void Update(Persona persona)
        {
            var existingPersona = _dbContext.Personas.FirstOrDefault(p => p.Documento == persona.Documento);

            if (existingPersona != null)
            {
                existingPersona.Nombres = persona.Nombre;
                existingPersona.Apellidos = persona.Apellidos;
                existingPersona.Telefono = persona.Telefono;
                existingPersona.Direccion = persona.Direccion;
                existingPersona.FechaNacimiento = persona.FechaNacimiento;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("La persona no existe.");
            }
        }
    }
}
