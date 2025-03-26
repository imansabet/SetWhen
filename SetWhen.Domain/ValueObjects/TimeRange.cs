namespace SetWhen.Domain.ValueObjects;
public record TimeRange(TimeSpan Start, TimeSpan End)
{
    public bool Overlaps(TimeRange other)
    {
        return Start < other.End && End > other.Start;
    }
}