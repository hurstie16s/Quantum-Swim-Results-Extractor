// See https://aka.ms/new-console-template for more information

using System;
using UglyToad.PdfPig;

namespace extractor
{
internal static class ExtractorMain
{
  public static void Main(string[] args)
  {
    // Check right number of arguments
    if (args.Length != 2)
    {
      Console.Error.WriteLine("Incorrect Number of Arguments: Press Enter to Exit");
      Console.Read();
      Environment.Exit(1);
    }
    var sourceDirectory = args[0];
    var destinationDirectory = args[1];
    
    ExtractFiles(sourceDirectory);
  }

  private static void ExtractFiles(string fileDirectory)
  {
    var files = Directory.GetFiles($"{fileDirectory}\\");
  }
}
}