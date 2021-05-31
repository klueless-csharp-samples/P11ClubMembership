namespace ClubMembership.Web.Context
{
  using ClubMembership.Web.Data;
  using Microsoft.EntityFrameworkCore;

  public partial class DomainContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Member> Members { get; set; }
  }
}
