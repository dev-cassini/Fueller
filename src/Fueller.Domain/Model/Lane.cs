namespace Fueller.Domain.Model;

public class Lane
{
    public Guid Id { get; }
    
    private readonly List<Pump> _pumps = new();
    public IEnumerable<Pump> Pumps => _pumps.AsReadOnly();
    
    public Guid ForecourtId { get; }
    public Forecourt Forecourt { get; } = null!;

    public Lane(Guid id, Forecourt forecourt)
    {
        Id = id;
        ForecourtId = forecourt.Id;
        Forecourt = forecourt;
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private Lane() { }
    #endregion
}