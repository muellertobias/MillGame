using System.Reflection;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MillGame.Models;

namespace MillGame.Models.Tests
{
    /// <summary>Diese Klasse enthält parametrisierte Komponententests für Mill.</summary>
    [TestClass]
    [PexClass(typeof(Mill))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MillTest
    {

        /// <summary>Test-Stub für .ctor(GameStatus)</summary>
        [PexMethod]
        public Mill ConstructorTest(GameStatus status)
        {
            Mill target = new Mill(status);
            return target;
            // TODO: Assertionen zu Methode MillTest.ConstructorTest(GameStatus) hinzufügen
        }

        [PexMethod]
        [PexMethodUnderTest("SetupFields()")]
        internal void SetupFields([PexAssumeUnderTest]Mill target)
        {
            object[] args = new object[0];
            Type[] parameterTypes = new Type[0];
            object result = ((MethodBase)(typeof(Mill).GetMethod("SetupFields",
                                                                 BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null,
                                                                 CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                                .Invoke((object)target, args);
            // TODO: Assertionen zu Methode MillTest.SetupFields(Mill) hinzufügen
        }
    }
}
