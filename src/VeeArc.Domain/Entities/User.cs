using VeeArc.Domain.Common;

namespace VeeArc.Domain.Entities;

public class User : BaseAuditableEntity
{
    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public List<Role> Roles { get; set; }

    public List<Article> Articles { get; set; }
}
