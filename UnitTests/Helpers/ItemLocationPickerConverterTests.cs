using Game.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Helpers
{
    [TestFixture]
    class ItemLocationPickerConverterTests
    {
        [Test]
        public void ItemLocationPickerConverter_Convert_Invalid_Should_Fail()
        {
            // Arrange
            var ItemLocationConverter = new ItemLocationPickerConverter();

            // Act
            var result = ItemLocationConverter.Convert("0", null, null, null);

            // Assert
            Assert.AreEqual("None", result);
        }
    }
}
