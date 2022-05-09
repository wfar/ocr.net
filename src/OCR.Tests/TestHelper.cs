using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OCR.Tests;

public static class TestHelper
{
	public static string GetTempDirectoryForTesting()
	{
		string fullTempDirectoryPath = Path.GetFullPath(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", "")));
		Directory.CreateDirectory(fullTempDirectoryPath);
		return fullTempDirectoryPath;
	}

	public static void ExtractResourceFileNameIntoDestinationPathForTesting(string resourceFileName, string resourceDestinationPath)
	{
		Assembly assembly = Assembly.GetExecutingAssembly();
		string resourceFullName = assembly.GetManifestResourceNames().SingleOrDefault(name => name.EndsWith(resourceFileName));
		using Stream resourceStream = assembly.GetManifestResourceStream(resourceFullName);
		using FileStream resourceFileStream = new FileStream(resourceDestinationPath, FileMode.Create, FileAccess.Write);
		resourceStream?.CopyTo(resourceFileStream);
	}
}