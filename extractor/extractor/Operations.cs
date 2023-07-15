using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using UglyToad.PdfPig.Writer;

namespace extractor;

public static class Operations
{
  public static (byte[], string) Merge(string[] files)
  {
    byte[] resultBytes = PdfMerger.Merge(files);
    string destFilename = $"{ArgumentManagement.DestinationDirectory}\\Results.pdf";
    return (resultBytes, destFilename);
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
  }
}