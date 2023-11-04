namespace Fueller.Domain.Model;

public class Lane
{
    public Guid Id { get; }
    public Guid ForecourtId { get; }
    public Forecourt Forecourt { get; }
    
    public Lane(Guid id, Forecourt forecourt)
    {
        Id = id;
        ForecourtId = forecourt.Id;
        Forecourt = forecourt;
    }
}