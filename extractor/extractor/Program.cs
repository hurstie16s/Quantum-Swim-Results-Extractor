// See https://aka.ms/new-console-template for more information

using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using UglyToad.PdfPig.Writer;

namespace extractor
{
internal static class ExtractorMain
{

  public static void Main(string[] args)
  {
    // Check right number of arguments
    if (args.Length < 3)
    {
      Console.Error.WriteLine("Incorrect Number of Arguments");
      Environment.Exit(1);
    }
    ArgumentManagement.SourceDirectory = ArgumentManagement.ParseSourceDirectory(args[0]);

    ArgumentManagement.DestinationDirectory = ArgumentManagement.ParseDestinationDirectory(args[0], args[1]);

    List<string> files = Directory.GetFiles($"{ArgumentManagement.SourceDirectory}\\").ToList();
    string[] sortedFiles = files.OrderBy(x => int.Parse(x.Split("\\").Last().Split(".")[0])).ToArray();


    (byte[],string) operationResults = ArgumentManagement.ParseOperation(args[2])(sortedFiles);
    byte[] resultBytes = operationResults.Item1;
    string destinationFileName = operationResults.Item2;
    File.WriteAllBytes(destinationFileName, resultBytes);
  }
}
}