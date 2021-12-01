namespace advent_of_code_2021;

public abstract class BaseExecutor
{
    protected BaseExecutor(string day)
    {
        Console.WriteLine($"~*~*~ {day} ~*~*~");
    }

    public abstract void Execute();
}
