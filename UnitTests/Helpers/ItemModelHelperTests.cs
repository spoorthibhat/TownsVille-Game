using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Game.Helpers;
using Game.ViewModels;
using Game.Models;
using System.Threading.Tasks;

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

        [Test]
        public async Task ItemModelHelper_GetItemModelFromGuid_Valid_Should_Pass()
        {
            // Arrange
            var ViewModel = ItemIndexViewModel.Instance;
            var dataTest = new ItemModel { Name = "test" };
            await ViewModel.CreateAsync(dataTest);

            // act
            var result = ItemModelHelper.GetItemModelFromGuid(dataTest.Id);

            // assert
            Assert.AreEqual(dataTest, result);
        }
    }
}
