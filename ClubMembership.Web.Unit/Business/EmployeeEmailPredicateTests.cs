using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClubMembership.Web.Business;

namespace ClubMembership.Web.Unit.Busines
{
  // EmployeeEmailPredicate
  [TestClass]
  public class EmployeeEmailPredicateTests
  {
    [TestMethod]
    public void EmployeeWithUppercaseEmail()
    {
      var predicate = new EmployeeEmailPredicate();

      var is_valid = predicate.IsEmployee("david@CLUB.COM");

      Assert.IsTrue(is_valid);
    }

    [TestMethod]
    public void EmployeeWithLowercaseEmail()
    {
      var predicate = new EmployeeEmailPredicate();

      var is_valid = predicate.IsEmployee("david@club.com");

      Assert.IsTrue(is_valid);
    }


    [TestMethod]
    public void NonEmployeeWithEmail()
    {
      var predicate = new EmployeeEmailPredicate();

      var is_valid = predicate.IsEmployee("david@personal.com");

      Assert.IsFalse(is_valid);
    }
  }
}
