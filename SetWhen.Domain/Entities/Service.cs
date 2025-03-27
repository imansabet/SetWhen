namespace SetWhen.Domain.Entities;
public class Service
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public TimeSpan Duration { get; private set; }
    public decimal Price { get; private set; }

    private Service() { }

    public Service(string title, TimeSpan duration, decimal price)
    {
        Id = Guid.NewGuid();
        Title = title;
        Duration = duration;
        Price = price;
    }
    public void Update(string title, TimeSpan duration, decimal price)
    {
        Title = title;
        Duration = duration;
        Price = price;
    }
}