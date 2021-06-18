namespace ClubMembership.Web.Business
{
  using System;

  public class EmployeeEmailPredicate
  {
    private const string WorkEmail = "@club.com";

    public bool IsEmployee(string email)
    {
      return email.EndsWith(WorkEmail, StringComparison.OrdinalIgnoreCase);
    }
  }
}
