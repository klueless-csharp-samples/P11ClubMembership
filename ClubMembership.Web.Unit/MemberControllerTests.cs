using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ClubMembership.Web.Context;
using ClubMembership.Web.Controllers;
using ClubMembership.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClubMembership.Web.Unit
{
  [TestClass]
  public class MemberControllerTests : BaseTest
  {
    [TestMethod]
    public void IndexTest()
    {
      SetupTest((MemberController controller) => {
        var result = controller.Index();
        Trace.WriteLine(result.Status);
        Assert.IsTrue(result.IsCompleted);
      });
    }

    [TestMethod]
    public void DetailsTest()
    {
      SetupTest((MemberController controller) => {
        var result = controller.Details(1);
        Trace.WriteLine(result.Status);
        Assert.IsTrue(result.IsCompleted);
      });
    }

    [TestMethod]
    public void CreateTest()
    {
      SetupTest((MemberController controller) => {
        var result = controller.Create();

        Assert.IsInstanceOfType(result, typeof(IActionResult));
      });
    }

    [TestMethod]
    public void EditTest()
    {
      SetupTest((MemberController controller) => {
        var result = controller.Edit(1);
        Trace.WriteLine(result.Status);
        Assert.IsTrue(result.IsCompleted);
      });
    }

    public void SetupTest(Action<MemberController> test) {
      var options = new DbContextOptionsBuilder<DomainContext>()
            .UseInMemoryDatabase(databaseName: "ClubMembershipDatabase")
            .Options;

      using (var context = new DomainContext(options))
      {
        // Setup Database
        var david = new Member { Id = 1, FirstName = "David", LastName = "Anderson", Email = "david@xyz.com", Phone = "02 2222 3333", BirthDate = "23/01/1990" };
        var ben = new Member { Id = 2, FirstName = "Ben", LastName = "Smith", Email = "ben@smith.com", Phone = "02 1111 4444", BirthDate = "12/01/1990" };

        context.Members.Add(david);
        context.Members.Add(ben);
        context.SaveChanges();

        var controller = new MemberController(null);
        controller.Context = context;

        test.Invoke(controller);

        // Cleanup Database
        context.Members.Remove(david);
        context.Members.Remove(ben);
        context.SaveChanges();
      }
    }
  }
}
