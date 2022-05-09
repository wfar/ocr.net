using NUnit.Framework;

namespace OCR.Tests
{
	public class OCREngineTests
	{
		private IOCREngine ocrEnginerSUT;

		[SetUp]
		public void Setup()
		{
			ocrEnginerSUT = new OCREngine();
		}

		[Test]
		public void TestGetTextFromImage()
		{
			string extractedTextFromImage = ocrEnginerSUT.GetTextFromImage("");
			
			Assert.That(extractedTextFromImage, Is.Not.Null.And.Not.Empty);
			//Assert.That(extractedTextFromImage, Is.EqualTo(""));
		}
	}
}