using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace OCR.Tests
{
	public class OCREngineTests
	{
		private string _testTempDirectory;
		private IOCREngine ocrEngineSUT;

		[SetUp]
		public void Setup()
		{
			_testTempDirectory = TestHelper.GetTempDirectoryForTesting();
			ocrEngineSUT = new OCREngine();
		}

		[TearDown]
		public void TearDown()
		{
			if (Directory.Exists(_testTempDirectory))
			{
				Directory.Delete(_testTempDirectory, true);
			}
		}

		[TestCase("CountOfMonteCristo.png", "CountOfMonteCristo.txt")]
		[TestCase("PowerSupply.png", "PowerSupply.txt")]
		[TestCase("TaleOfTwoCities.png", "TaleOfTwoCities.txt")]
		public void TestGetTextFromImage(string inputImageFileName, string expectedTextFileName)
		{
			// Arrange
			string testImageFilePath = Path.Combine(_testTempDirectory, inputImageFileName);
			TestHelper.ExtractResourceFileNameIntoDestinationPathForTesting(inputImageFileName, testImageFilePath);

			string testTextFilePath = Path.Combine(_testTempDirectory, expectedTextFileName);
			TestHelper.ExtractResourceFileNameIntoDestinationPathForTesting(expectedTextFileName, testTextFilePath);

			// Act
			string extractedTextFromImage = ocrEngineSUT.GetTextFromImage(testImageFilePath);
			
			// Assert
			Assert.That(extractedTextFromImage, Is.Not.Null.And.Not.Empty);
			Assert.That(Regex.Replace(extractedTextFromImage, "(?<!\r)\n", "\r\n"), Is.EqualTo(File.ReadAllText(testTextFilePath)));
		}
	}
}