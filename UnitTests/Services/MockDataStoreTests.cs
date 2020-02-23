﻿using Game.Models;
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
    }

    
}
