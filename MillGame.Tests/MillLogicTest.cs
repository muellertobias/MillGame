using MillGame.Models;
// <copyright file="MillLogicTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MillGame.Algorithms;
using MillGame.Models.Players;

namespace MillGame.Algorithms.Tests
{
    /// <summary>Diese Klasse enthält parametrisierte Komponententests für MillLogic.</summary>
    [PexClass(typeof(MillLogic))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MillLogicTest
    {
        /// <summary>Test-Stub für FindMill(Player)</summary>
        [PexMethod]
        public bool FindMillTest(Player player)
        {
            bool result = MillLogic.FindMill(player);
            return result;
            // TODO: Assertionen zu Methode MillLogicTest.FindMillTest(Player) hinzufügen
        }

        /// <summary>Test-Stub für IsMill(Field)</summary>
        [PexMethod]
        public bool IsMillTest(Field current)
        {
            bool result = MillLogic.IsMill(current);
            return result;
            // TODO: Assertionen zu Methode MillLogicTest.IsMillTest(Field) hinzufügen
        }
    }
}
