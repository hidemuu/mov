﻿using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services.Clients;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Accessors.Test.Models;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Test
{
    [TestFixture]
    public class AccessClientTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAsync_JsonFile_ReturnSchema()
        {
            // Arrange
            var sut = new ClientFactory(PathValue.Factory.CreateResourceRootPath()).Create(AccessType.Json);

            // Act
            var results = Task.WhenAll(sut.GetAsync<SerializeSchema>("test.json")).Result[0].ToArray();

            // Assert
            Assert.That(results != null);
            Assert.That(results[0].Id.Equals(1));
            Assert.That(results[0].Content.Equals("test"));
            Assert.That(results[1].Id.Equals(2));
            Assert.That(results[1].Content.Equals("test2"));
        }

        [Test]
        public void GetAsync_XmlFile_ReturnSchema()
        {
            // Arrange
            var sut = new ClientFactory(PathValue.Factory.CreateResourceRootPath()).Create(AccessType.Xml);

            // Act
            var results = Task.WhenAll(sut.GetAsync<SerializeSchemaCollection>("test.xml")).Result[0].ToArray();

            // Assert
            Assert.That(results != null);
            Assert.That(results[0].Schemas[0].Id.Equals(1));
            Assert.That(results[0].Schemas[0].Content.Equals("test"));
            Assert.That(results[0].Schemas[1].Id.Equals(2));
            Assert.That(results[0].Schemas[1].Content.Equals("test2"));
        }

        [Test]
        public void GetAsync_CsvFile_ReturnSchema()
        {
            // Arrange
            var sut = new ClientFactory(PathValue.Factory.CreateResourceRootPath()).Create(AccessType.Csv);

            // Act
            var results = Task.WhenAll(sut.GetAsync<SerializeSchema>("test.csv")).Result[0].ToArray();

            // Assert
            Assert.That(results != null);
            Assert.That(results[0].Id.Equals(0));
            Assert.That(results[0].Content.Equals("test"));
            Assert.That(results[1].Id.Equals(1));
            Assert.That(results[1].Content.Equals("test2"));
        }
    }
}