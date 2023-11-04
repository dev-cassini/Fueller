namespace Fueller.Domain.Model;

public class Forecourt
{
    public Guid Id { get; }
    
    public Forecourt(Guid id)
    {
        Id = id;
    }
}