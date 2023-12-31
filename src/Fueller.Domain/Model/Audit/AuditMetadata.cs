namespace Fueller.Domain.Model.Audit;

public class AuditMetadata<T> where T : IAuditable
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid AuditRecordId { get; }
    public string PropertyName { get; } = null!;
    public string? OriginalValue { get; }
    public string? UpdatedValue { get; }
    
    public AuditMetadata(
        AuditRecord<T> auditRecord, 
        string propertyName, 
        string? originalValue, 
        string? updatedValue)
    {
        AuditRecordId = auditRecord.Id;
        PropertyName = propertyName;
        OriginalValue = originalValue;
        UpdatedValue = updatedValue;
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private AuditMetadata() { }
    #endregion
}