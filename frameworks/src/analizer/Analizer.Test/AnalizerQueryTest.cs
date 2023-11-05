using Mov.Analizer.Repository;
using Mov.Analizer.Service.Stores;
using Mov.Core.Accessors.Models;
using Mov.Framework.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Analizer.Test
{
	public class AnalizerQueryTest
	{
		#region constants

		private const string TEST_NAME = nameof(AnalizerQueryTest);

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
			var query = new AnalizerQuery(repository);
			var result = query.TableLines.Reader.ReadAll();
			Assert.That(result.Any(), Is.EqualTo(true));
		}

		#endregion test
	}
}
