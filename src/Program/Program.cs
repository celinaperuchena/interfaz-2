//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Repositories
{
    /// <summary>
    /// Programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            // Creamos dos autos.
            Car jimny = new Car("Jimny", "Suzuki", 2024);
            Car focus = new Car("Focus", "Ford", 2018);

            // Creamos un repositorio que guarda autos.
            Repository<Car> database = new Repository<Car>();

            // Agregamos los autos al repositorio.
            database.Add(jimny);
            database.Add(focus);

            // Guardamos el repositorio en un archivo.
            database.SaveToFile("cars.json");

            Console.WriteLine("Database saved:");

            // Mostramos todos los autos guardados.
            foreach (Car car in database.Items)
            {
                Console.WriteLine(
                    $"Model: {car.Model}, Maker: {car.Maker}, Year: {car.Year}");
            }

            // Creamos otro repositorio de autos.
            Repository<Car> restoredDatabase = new Repository<Car>();

            // Cargamos los autos desde el archivo.
            restoredDatabase.LoadFromFile("cars.json");

            Console.WriteLine("Restored database:");

            // Mostramos los autos que fueron cargados.
            foreach (Car car in restoredDatabase.Items)
            {
                Console.WriteLine(
                    $"Model: {car.Model}, Maker: {car.Maker}, Year: {car.Year}");
            }
        }
    }
}