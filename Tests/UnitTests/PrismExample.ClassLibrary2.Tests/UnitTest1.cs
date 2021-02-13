using NUnit.Framework;

using PrismExample.ClassLibrary2;

namespace PrismExample.ClassLibrary2.Tests
{
	public class Tests
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