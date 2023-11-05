using Force.DeepCloner;

namespace Fueller.Domain.Model.Audit;

public abstract class AuditableEntity<T> : IAuditable where T : class, IAuditable
{
    private T? Snapshot { get; set; }

    private readonly List<AuditRecord<T>> _auditRecords = new();
    public IReadOnlyList<AuditRecord<T>> AuditRecords => _auditRecords.AsReadOnly();

    public void StartAudit()
    {
        Snapshot = this.DeepClone() as T;

        var auditRecord = new AuditRecord<T>(Snapshot, this as T);
        _auditRecords.Add(auditRecord);
    }

    public void AddAuditRecord()
    {
        var auditRecord = new AuditRecord<T>(Snapshot, this as T);
        if (auditRecord.Metadata.Any())
        {
            _auditRecords.Add(auditRecord);
            Snapshot = this.DeepClone() as T;
        }
    }

    public override bool Equals(object? obj)
    {
        return true;
    }
}

/// <remarks>Required for compatibility with Entity Framework.</remarks>>
public abstract class AuditableEntity : AuditableEntity<IAuditable>
{
}