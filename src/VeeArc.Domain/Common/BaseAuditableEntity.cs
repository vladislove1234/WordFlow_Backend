namespace VeeArc.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime? LastChanged { get; set; }
    
    public DateTime CreatedAt { get; set; }
}
