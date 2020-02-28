using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class SpecialAbilityEnumHelperTests
    {

        [Test]
        public void SpecialAbilityEnumHelper_GetSpecialAbilityList_Result_GreaterThanZero()
        {
            // Act
            var result = SpecialAbilityEnumHelper.GetSpecialAbilityList;

            // Assert
            Assert.Greater(result.Count, 0);
        }
    }
}
