using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class ItemModelHelperTests
    {
        [Test]
        public void ItemModelHelper_GetItemModelFromGuid_Null_Should_ReturnNull()
        {
            // act
            var result = ItemModelHelper.GetItemModelFromGuid(null);

            // assert
            Assert.IsNull(result);
        }
    }
}
