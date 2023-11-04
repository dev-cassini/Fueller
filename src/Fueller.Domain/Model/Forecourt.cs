namespace Fueller.Domain.Model;

public class Forecourt
{
    public Guid Id { get; }
    
    private readonly List<Lane> _lanes = new();
    public IEnumerable<Lane> Lanes => _lanes.AsReadOnly();
    
    private readonly List<Transaction> _transactions = new();
    public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();
    
    public Forecourt(Guid id)
    {
        Id = id;
    }
}