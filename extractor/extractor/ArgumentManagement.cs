namespace extractor;

public static class ArgumentManagement
{
  
  public static string SourceDirectory;
  public static string DestinationDirectory;
  
  public static string ParseSourceDirectory(string sourceDirectory)
  {
    switch (sourceDirectory.ToUpper())
    {
      case "PARENT":
        if (!Directory.GetParent(sourceDirectory).Exists) break;
        sourceDirectory = Directory.GetParent(sourceDirectory).FullName;
        break;
      case "THIS":
        sourceDirectory = Directory.GetCurrentDirectory();
        break;
    }

    return sourceDirectory;
  }

  public static string ParseDestinationDirectory(string sourceDirectory, string destinationDirectory)
  {
    switch (destinationDirectory.ToUpper())
    {
      case "SAME":
        destinationDirectory = sourceDirectory;
        break;
      case "PARENT":
        if (!Directory.GetParent(sourceDirectory).Exists) break;
        destinationDirectory = Directory.GetParent(sourceDirectory).FullName;
        break;
      case "THIS":
        destinationDirectory = Directory.GetCurrentDirectory();
        break;
    }

    return destinationDirectory;
  }

  public static Func<string[], (byte[], string)> ParseOperation(string operationString)
  {
    Func<string[], (byte[], string)> suspendedOperation = null;
    switch (operationString.ToUpper())
    {
      case "MERGE":
        suspendedOperation =  (x) => Operations.Merge(x);
        break;
      default:
        Console.Error.WriteLine("Unknown Operation");
        Environment.Exit(1);
        break;
    }

    return suspendedOperation;
  }
}