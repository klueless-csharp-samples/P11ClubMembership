using ClubMembership.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClubMembership.Web.Unit
{
  // EmployeeEmailPredicate
  [TestClass]
  public class HomeControllerTests
  {
    [TestMethod]
    public void IndexTest()
    {
      Assert.IsNotNull(HomeIndex());
    }

    [TestMethod]
    public void IndexTitleNotNullTest()
    {
      Assert.IsNotNull(HomeIndex().ViewData["Title"]);
    }

    [TestMethod]
    public void IndexTitleIsStringTest()
    {
      Assert.IsInstanceOfType(HomeIndex().ViewData["Title"], typeof(string));
    }

    [TestMethod]
    public void IndexTitleIsHomeTest()
    {
      Assert.IsTrue(HomeIndex().ViewData["Title"].ToString().Contains("Home"));
    }

    private ViewResult HomeIndex() {
      var controller = new HomeController(null);

      return (ViewResult)controller.Index();
    }
  }
}
