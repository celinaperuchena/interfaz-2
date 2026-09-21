//------------------------------------------------------------------------------
// <copyright file="IHasValue.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Ucu.Poo.Repositories
{
    /// <summary>
    /// Representa un objeto en el que se puede buscar un valor.
    /// </summary>
    public interface IHasValue
    {
        /// <summary>
        /// Indica si el objeto tiene un valor determinado en un atributo.
        /// </summary>
        /// <param name="field">El atributo donde se busca.</param>
        /// <param name="value">El valor que se busca.</param>
        /// <returns>
        /// Retorna true si encuentra el valor y false si no lo encuentra.
        /// </returns>
        bool HasValue(string field, string value);
    }
}