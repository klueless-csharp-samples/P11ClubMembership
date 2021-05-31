namespace ClubMembership.Web.Context
{
  using Microsoft.EntityFrameworkCore;

  // Database context for PostgresSql database
  public class MsDbContext : DomainContext
  {
    public MsDbContext()
    {
    }

    public MsDbContext(DbContextOptions<MsDbContext> options)
    {
    }

    private string Password
    {
      get
      {
        return System.Environment.GetEnvironmentVariable("DEVELOPER_PASSSWORD");
      }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlServer($"Server=localhost,1433; Database=;User=sa; Password={Password}");
  }
}
