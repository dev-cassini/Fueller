using Force.DeepCloner;

namespace Fueller.Domain.Model.Audit;

public class AuditRecord<T> where T : IAuditable
{
    public Guid Id { get; } = Guid.NewGuid();
    public T Auditable { get; }
    public IEnumerable<AuditMetadata<T>> Metadata { get; }
    
    public AuditRecord(T original, T updated)
    {
        var auditMetadata = new List<AuditMetadata<T>>();
        foreach (var property in typeof(T).GetProperties()
                     .Where(x => x.SetMethod is not null))
        {
            if (property.GetType().IsAssignableTo(typeof(IAuditable)))
            {
                var auditableProperty = property.GetValue(updated) as IAuditable;
                auditableProperty!.AddAuditRecord();
            }
            
            var originalValue = property.GetValue(original);
            var updatedValue = property.GetValue(updated);
            if (originalValue is null && updatedValue is null) continue;
            
            if (originalValue is null || 
                updatedValue is null || 
                originalValue.Equals(updatedValue) is false)
            {
                auditMetadata.Add(new AuditMetadata<T>(
                    this,
                    property.Name,
                    originalValue?.ToString(),
                    updatedValue?.ToString()));
            }
        }
        
        Auditable = updated.DeepClone();
        Metadata = auditMetadata;
    }
}