namespace advent_of_code_2021.Day1;

public class Day1 : BaseExecutor
{
    public Day1() : base("Day 1") { }

    public override void Execute()
    {
        using var sr = new StreamReader("input.txt");
        string? previousValue = null;
        var numberOfLargerMeasurements = 0;
        var measurements = new List<int>();

        while (!sr.EndOfStream)
        {
            var currentValue = sr.ReadLine();
            measurements.Add(int.Parse(currentValue));
            if (previousValue is not null && int.Parse(currentValue) > int.Parse(previousValue))
                numberOfLargerMeasurements++;
            previousValue = currentValue;
        }

        sr.Close();
        Console.WriteLine($"[Challenge 1] Total number of larger measurements: {numberOfLargerMeasurements}");

        var measurementsTruple = new List<(int, int, int)>();
        var strartingPoint = 0;
        var hasEnoughtElements = true;
        while (hasEnoughtElements)
        {
            measurementsTruple.Add(new ValueTuple<int, int, int>(measurements.ElementAt(strartingPoint),
                measurements.ElementAt(strartingPoint + 1),
                measurements.ElementAt(strartingPoint + 2)));
            strartingPoint++;
            if (measurements.Count - strartingPoint < 3)
                hasEnoughtElements = false;
        }

        int? previousSum = null;
        numberOfLargerMeasurements = 0;
        foreach (var currentSum in
                 measurementsTruple.Select(valueTuple => valueTuple.Item1 + valueTuple.Item2 + valueTuple.Item3))
        {
            if (previousSum is not null && currentSum > previousSum)
                numberOfLargerMeasurements++;

            previousSum = currentSum;
        }

        Console.WriteLine($"[Challenge 2] Total number of large sum measurements: {numberOfLargerMeasurements}");
    }
}
