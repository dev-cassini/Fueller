namespace Fueller.Domain.Model.Audit;

public interface IAuditable
{
    public void AddAuditRecord();
}