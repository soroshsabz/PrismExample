using NUnit.Framework;

namespace PrismExample.ClassLibrary1.Tests
{
	public class Class1Test
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var c = new Class1();

			// Act
			string result = c.Method1(53);

			// Assert
			Assert.AreEqual("53", result);
		}
	}
}