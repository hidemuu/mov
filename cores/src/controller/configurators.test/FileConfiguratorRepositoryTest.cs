﻿using Mov.Core.Accessors.Models;
using Mov.Core.Configurators.Repositories;

namespace Mov.Core.Configurators.Test
{
    public class FileConfiguratorRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAsync_DeserializeConfigJsonFilee_ReturnAll()
        {
            // Arrange
            var sut = new FileConfiguratorRepository(PathValue.Factory.CreateResourceRootPath().Value, FileType.Json, EncodingValue.UTF8);

            // Act
            var configTask = sut.UserSettings.GetAsync();
            Task.WhenAll(configTask);
            var configs = configTask.Result.ToArray();

            // Assert
            Assert.That(configs.Length, Is.EqualTo(2));
            Assert.That(configs[0].Category, Is.EqualTo("test"));
        }
    }
}