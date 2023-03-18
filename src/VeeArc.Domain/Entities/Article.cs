using VeeArc.Domain.Common;
using VeeArc.Domain.Enums;

namespace VeeArc.Domain.Entities;

public class Article : BaseAuditableEntity
{
    public string Title { get; set; }
    
    public string FileLink { get; set; }
    
    public ArticleState State { get; set; }
    
    public int AuthorId { get; set; }
}
