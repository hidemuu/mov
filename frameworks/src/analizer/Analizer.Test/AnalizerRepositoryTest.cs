using Mov.Analizer.Repository;
using Mov.Core.Accessors.Models;
using Mov.Framework.Services;
using System.Diagnostics;

namespace Mov.Analizer.Test
{
	public class AnalizerRepositoryTest
	{
		#region constants

		private const string TEST_NAME = nameof(AnalizerRepositoryTest);

		#endregion constants

		#region field

		#endregion field

		#region setup

		[OneTimeSetUp]
		public void ClassInitialize()
		{
			Trace.WriteLine($"{TEST_NAME} ClassInitialize");
		}

		[SetUp]
		public void Setup()
		{
			Trace.WriteLine($"{TEST_NAME} TestInitialize");
		}

		[TearDown]
		public void TestCleanup()
		{
			Trace.WriteLine($"{TEST_NAME} TestCleanup");
		}

		[OneTimeTearDown]
		public static void ClassCleanup()
		{
			Trace.WriteLine($"{TEST_NAME} ClassCleanup");
		}

		#endregion setup

		#region test

		[Test]
		public void GetsTableLineAsync_ResourceFile_Returns()
		{
			var resourcePath = PathValue.Factory.CreateResourcePath("").Value;
			var repository = new FileAnalizerRepository(resourcePath);
			var result = Task.WhenAll(repository.TableLines.GetsAsync()).Result[0];
			Assert.That(result.Any(), Is.EqualTo(true));
		}

		#endregion test
	}
}