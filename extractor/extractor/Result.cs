using Timer = System.Timers.Timer;

namespace extractor;

public record Result(DateTime DateTimeStamp, string SwimEvent, List<(string, int, string, int)> SwimResult, List<(int, string)> SwimSplits);