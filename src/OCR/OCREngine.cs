using Tesseract;

namespace OCR
{
	public class OCREngine : IOCREngine
	{
		private const string _LANGUAGE = "eng";
		private const string _DATA_PATH = @"./tessdata";

		private readonly TesseractEngine _engine;

		public OCREngine()
		{
			_engine = new TesseractEngine(_DATA_PATH, _LANGUAGE, EngineMode.Default);
		}

		public string GetTextFromImage(string pathToImage)
		{
			using Pix? image = Pix.LoadFromFile(pathToImage);
			using Page? page = _engine.Process(image);

			return page.GetText();
		}
	}
}