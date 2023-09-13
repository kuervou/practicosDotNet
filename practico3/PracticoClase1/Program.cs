﻿// See https://aka.ms/new-console-template for more information
using Shared;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using BusinessLayer.IBLs;
using BusinessLayer.BLs;
using PracticoClase1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Primera Aplicación con .NET");

IDAL_Personas _personas = new DAL_Personas_EF(new DataAccessLayer.DBContextCore());
IBL_Personas _personasBL = new BL_Personas(_personas);
IDAL_Vehiculos _vehiculos = new DAL_Vehiculos_EF(new DataAccessLayer.DBContextCore());
IBL_Vehiculos _vehiculosBL = new BL_Vehiculos(_vehiculos);
Commands commands = new Commands(_personasBL, _vehiculosBL);
UpdateDatabase();

Console.WriteLine("Comandos Posibles:");
Console.WriteLine("1 - Agregar Persona");
Console.WriteLine("2 - Listar Personas");
Console.WriteLine("3 - Eliminar Persona");
Console.WriteLine("4 - Agregar Vehiculo");
Console.WriteLine("5 - Listar Vehiculos");
Console.WriteLine("6 - Eliminar Vehiculo");
Console.WriteLine("7 - Salir");

Console.Write("Ingrese Comando> ");
string command = Console.ReadLine();

while(command != "7")
{
    try
    {
        switch (command)
        {
            case "1":
                commands.AddPersona();
                break;
            case "2":
                commands.ListPersonas();
                break;
            case "3":
                commands.RemovePersona();
                break;
            case "4":
                commands.AddVehiculo();
                break;
            case "5":
                commands.ListVehiculos();
                break;
            case "6":
                commands.RemoveVehiculo();
                break;
            default:
                Console.WriteLine("Comando no reconocido");
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("ERROR> " + ex.Message);
    }
    finally
    {
        Console.Write("Ingrese Comando> ");
        command = Console.ReadLine();
    }
}

Console.WriteLine("Gracias por usar la aplicación");

void UpdateDatabase()
{
    using (var context = new DataAccessLayer.DBContextCore())
    {
        context?.Database.Migrate();
    }
}