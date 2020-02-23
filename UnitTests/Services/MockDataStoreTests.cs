using Game.Models;
using Game.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    [TestFixture]
    public class MockDataStoreTests
    {
        MockDataStore<ItemModel> DataStore;

        [SetUp]
        public void Setup()
        {
            DataStore = MockDataStore<ItemModel>.Instance;
        }

        [TearDown]
        public async Task TearDown()
        {
            await DataStore.WipeDataListAsync();
        }

        [Test]
        public void MockDataStore_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DataStore;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task MockDataStore_SetNeedsRefresh_Valid_True_Should_Pass()
        {
            // Arrange
            var originalState = await DataStore.GetNeedsInitializationAsync();

            // Act
            DataStore.NeedsInitialization = true;
            var newState = await DataStore.GetNeedsInitializationAsync();

            // Reset

            // Turn it back to the original state
            DataStore.NeedsInitialization = originalState;

            // Assert
            Assert.AreEqual(true, newState);
        }

        [Test]
        public async Task MockDataStore_SetNeedsRefresh_Twice_True_Should_Pass()
        {
            // Arrange
            var originalState = await DataStore.GetNeedsInitializationAsync();

            // Act
            DataStore.NeedsInitialization = true;
            var newState = await DataStore.GetNeedsInitializationAsync();
            var newState2 = await DataStore.GetNeedsInitializationAsync();

            // Reset

            // Turn it back to the original state
            DataStore.NeedsInitialization = originalState;

            // Assert
            Assert.AreEqual(false, newState2);
        }

        [Test]
        public async Task MockDataStore_WipeDataListAsync_Valid_True_Should_Pass()
        {
            // Arrange

            // Act
            var newState = await DataStore.WipeDataListAsync();

            // Reset

            // Turn it back to the original state

            // Assert
            Assert.AreEqual(true, newState);
        }

        [Test]
        public async Task MockDataStore_CreateAsync_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = await DataStore.CreateAsync(new ItemModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task MockDataStore_CreateAsync_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await DataStore.CreateAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task MockDataStore_Read_Valid_Should_Pass()
        {
            // Arrange
            var item = new ItemModel();
            await DataStore.CreateAsync(item);

            // Act
            var result = await DataStore.ReadAsync(item.Id);

            // Reset

            // Assert
            Assert.AreEqual(item.Id, result.Id);
        }
    }

    
}
