using System.Diagnostics;

namespace Mov.Analizer.Test
{
	public class Tests
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
		public void Test1()
		{
			Assert.Pass();
		}

		#endregion test
	}
}