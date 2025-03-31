namespace SetWhen.Domain.Entities;
public class Business
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Type { get; private set; } //  "Clinic", "Salon", ...
    public string City { get; private set; }
    public string Address { get; private set; }

    public Guid OwnerId { get; private set; }
    public User? Owner { get; private set; }

    public ICollection<User> Staff { get; private set; } = new List<User>();
    public ICollection<Service> Services { get; private set; } = new List<Service>();

    private Business() { }

    public Business(string name, string type, string city, string address, Guid ownerId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        City = city;
        Address = address;
        OwnerId = ownerId;
    }

    public void Update(string name, string type, string city, string address)
    {
        Name = name;
        Type = type;
        City = city;
        Address = address;
    }
}