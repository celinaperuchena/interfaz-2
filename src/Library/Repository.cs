//------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Ucu.Poo.Repositories
{
    /// <summary>
    /// Representa un repositorio genérico de elementos.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos que guarda el repositorio.</typeparam>
    public class Repository<T>
        where T : IHasValue
    {
        // Lista donde se guardan los elementos.
        private List<T> items = new List<T>();

        /// <summary>
        /// Obtiene los elementos guardados en el repositorio.
        /// </summary>
        public ReadOnlyCollection<T> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        /// <summary>
        /// Agrega un elemento al repositorio.
        /// </summary>
        /// <param name="item">El elemento que se quiere agregar.</param>
        public void Add(T item)
        {
            if (item != null)
            {
                this.items.Add(item);
            }
        }

        /// <summary>
        /// Elimina un elemento del repositorio.
        /// </summary>
        /// <param name="item">El elemento que se quiere eliminar.</param>
        public void Remove(T item)
        {
            this.items.Remove(item);
        }

        /// <summary>
        /// Busca un elemento que tenga un valor determinado.
        /// </summary>
        /// <param name="field">El atributo donde se busca.</param>
        /// <param name="value">El valor que se busca.</param>
        /// <returns>El elemento encontrado o null si no existe.</returns>
        public T Find(string field, string value)
        {
            foreach (T item in this.items)
            {
                if (item.HasValue(field, value))
                {
                    return item;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Convierte los elementos del repositorio a formato JSON.
        /// </summary>
        /// <returns>Los elementos en formato JSON.</returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this.items);
        }

        /// <summary>
        /// Carga los elementos desde un texto en formato JSON.
        /// </summary>
        /// <param name="content">El contenido en formato JSON.</param>
        public void LoadFromJson(string content)
        {
            List<T> loadedItems = JsonSerializer.Deserialize<List<T>>(content);

            if (loadedItems != null)
            {
                this.items = loadedItems;
            }
            else
            {
                this.items = new List<T>();
            }
        }

        /// <summary>
        /// Guarda los elementos en un archivo.
        /// </summary>
        /// <param name="filePath">La ruta del archivo.</param>
        public void SaveToFile(string filePath)
        {
            string content = this.ConvertToJson();
            File.WriteAllText(filePath, content);
        }

        /// <summary>
        /// Carga los elementos desde un archivo.
        /// </summary>
        /// <param name="filePath">La ruta del archivo.</param>
        /// <returns>True si pudo cargar el archivo; false si no existe.</returns>
        public bool LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                this.LoadFromJson(content);
                return true;
            }

            return false;
        }
    }
}