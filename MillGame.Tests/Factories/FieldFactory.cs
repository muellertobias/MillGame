using MillGame.Utilities;
using MillGame.Models;
// <copyright file="FieldFactory.cs">Copyright ©  2017</copyright>

using System;
using Microsoft.Pex.Framework;

namespace MillGame.Models
{
    /// <summary>A factory for MillGame.Models.Field instances</summary>
    public static partial class FieldFactory
    {
        /// <summary>A factory for MillGame.Models.Field instances</summary>
        [PexFactoryMethod(typeof(Field))]
        public static Field Create(Mill board_mill, FieldState value_i)
        {
            Field field = new Field(board_mill);
            field.CurrentState = value_i;
            return field;

            // TODO: Edit factory method of Field
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
