using Game.Helpers;
using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Helpers
{
    [TestFixture]
    class IntStringConverterTests
    {
        [Test]
        public void IntString_Convert_Should_Skip()
        {
            var myConverter = new IntStringConverter();

            var myObject = new ItemModel();

            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}
