﻿// See https://aka.ms/new-console-template for more information

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
    if (args.Length != 3)
    {
      Console.Error.WriteLine("Incorrect Number of Arguments: Press Enter to Exit");
      Console.Read();
      Environment.Exit(1);
    }
    string sourceDirectory = args[0];
    string destinationDirectory = args[1];
    if (destinationDirectory.ToUpper().Equals("THIS")) destinationDirectory = sourceDirectory;
    string operation = args[2];

    List<string> files = Directory.GetFiles($"{sourceDirectory}\\").ToList();
    string[] sortedFiles = files.OrderBy(x => int.Parse(x.Split("\\").Last().Split(".")[0])).ToArray();

    switch (operation.ToUpper())
    {
      case "MERGE":
        Merge(sortedFiles, destinationDirectory);
        break;
      default:
        Console.Error.WriteLine("Unknown Operation: Press Enter to Exit");
        Console.Read();
        break;
    }
  }

  private static void Merge(string[] files,string dest)
  {
    byte[] resultBytes = PdfMerger.Merge(files);
    string destFilename = $"{dest}\\ResultsMerged.pdf";
    File.WriteAllBytes(destFilename, resultBytes);
  }

  
  
  private static void ExtractFile(string filename)
  {
    var pdf = PdfDocument.Open(filename);

    foreach (var page in pdf.GetPages())
    {
      string text = ContentOrderTextExtractor.GetText(page);
      var lines = text.Split("\n");

      string dateTimeString = lines[1];
      Console.WriteLine(dateTimeString);
      var dateTime = DateTime.Parse(dateTimeString);
      
      string swimEvent = lines[2];
      // Determine number of splits
      int legs;
      if (swimEvent.ToUpper().Contains("RELAY"))
      {
        legs = int.Parse(swimEvent[0].ToString()); 
      }
      else
      {
        legs = (int.Parse(swimEvent.Split(" ")[0])) / 50;
      }

      foreach (var VARIABLE in lines)
      {
        Console.WriteLine(VARIABLE);
      }

      int swimmerIndex = 5;
      List<string> swimEventsTemp = new List<string>();

      while (!lines[swimmerIndex].Split(" ")[0].Equals("Dist"))
      {
        swimEventsTemp.Add(lines[swimmerIndex]);
        swimmerIndex++;
      }

    }
    {
      
    }
  }
}
}