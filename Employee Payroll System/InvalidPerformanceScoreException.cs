[Serializable]
internal class InvalidPerformanceScoreException : Exception
{
    public InvalidPerformanceScoreException()
    {
    }

    public InvalidPerformanceScoreException(string? message) : base(message)
    {
    }

    public InvalidPerformanceScoreException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}