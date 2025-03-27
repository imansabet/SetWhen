namespace SetWhen.Domain.ValueObjects;
public record TimeRange(TimeSpan Start, TimeSpan End)
{
    public bool Overlaps(TimeRange other)
    {
        return Start < other.End && End > other.Start;
    }
    public List<TimeRange> ExcludeMany(List<TimeRange> blocked)
    {
        var remaining = new List<TimeRange> { this };

        foreach (var b in blocked)
        {
            remaining = remaining
                .SelectMany(r => r.Exclude(b))
                .ToList();
        }

        return remaining;
    }
    public List<TimeRange> Exclude(TimeRange other)
    {
        var result = new List<TimeRange>();

        if (!this.Overlaps(other))
        {
            result.Add(this);
            return result;
        }

        if (Start < other.Start)
            result.Add(new TimeRange(Start, other.Start));

        if (End > other.End)
            result.Add(new TimeRange(other.End, End));

        return result;
    }
}