using System;

namespace ClubMembership.Web.Business
{
  public class EmployeeEmailPredicate
  {
    private const string WORK_EMAIL = "@club.com";

    public bool is_employee(string email) {
      return email.Contains(WORK_EMAIL, StringComparison.OrdinalIgnoreCase);
    }
  }
}
