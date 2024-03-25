namespace ContainersProgram;

public class OverfillException : Exception
{
    public OverfillException(string message) : base("\nMaximum container capacity exceeded!")
    {
    }
}