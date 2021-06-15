namespace ClubMembership.Web.Context
{
  using ClubMembership.Web.Data;
  using Microsoft.EntityFrameworkCore;

  public partial interface IDomainContext
  {
    DbSet<User> Users { get; set; }
    DbSet<Member> Members { get; set; }
  }

  public partial class DomainContext : DbContext, IDomainContext
  {
    public DomainContext()
    {
    }

    public DomainContext(DbContextOptions<DomainContext> options)
      : base(options)
      {
      }

    public DbSet<User> Users { get; set; }
    public DbSet<Member> Members { get; set; }
  }
}
