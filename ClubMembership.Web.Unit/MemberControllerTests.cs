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
  // EmployeeEmailPredicate
  [TestClass]
  public class MemberControllerTests : BaseTest
  {
     private TestContext testContextInstance;

    /// <summary>
    /// Gets or sets the test context which provides
    /// information about and functionality for the current test run.
    /// </summary>
    public TestContext TestContext
    {
        get { return testContextInstance; }
        set { testContextInstance = value; }
    }

    [TestMethod]
    public async Task IndexTest()
    {
      var a = await MemberIndex();
      // var b = a as ViewResult;
      // // var c = a as OkObjectResult;

      // Assert.IsNotNull(b);
      // // Assert.IsNotNull(c);

      // var index = 1;
      Trace.WriteLine(a.GetType().Name);
      Trace.WriteLine(a.GetType().Namespace);
      // Trace.WriteLine(index++);
      // Trace.WriteLine(b.ContentType);
      // Trace.WriteLine(index++);
      // Trace.WriteLine(b.Model);
      // Trace.WriteLine(index++);
      // Trace.WriteLine(b.StatusCode);
      // Trace.WriteLine(index++);
      // Trace.WriteLine(b.TempData);
      // Trace.WriteLine(index++);
      // Trace.WriteLine(b.ToString());
      // Trace.WriteLine(index++);
      // Trace.WriteLine(b.ViewName);
      // Trace.WriteLine(index++);
      // Trace.WriteLine(b.ViewData);
      // Trace.WriteLine(index++);
      // Trace.WriteLine(a.Content());
      // Trace.WriteLine(b.Content());
      // a.ExecuteResultAsync
      // Trace.WriteLine(a.ViewName());
      
      // Trace.WriteLine(MemberIndex().ViewData["Title"])
    }

    // private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
    // {
    //     var elementsAsQueryable = elements.AsQueryable();
    //     var dbSetMock = new Mock<DbSet<T>>();

    //     dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
    //     dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
    //     dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
    //     dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

    //     return dbSetMock;
    // }

    private async Task<IActionResult> MemberIndex() {
      var options = new DbContextOptionsBuilder<DomainContext>()
            .UseInMemoryDatabase(databaseName: "ClubMembershipDatabase")
            .Options;

      using (var context = new DomainContext(options))
      {
        context.Members.Add(new Member { Id = 1, FirstName = "David", LastName = "Anderson", Email = "david@xyz.com", Phone = "02 2222 3333", BirthDate = "23/01/1990" });
        context.Members.Add(new Member { Id = 2, FirstName = "Ben", LastName = "Smith", Email = "ben@smith.com", Phone = "02 1111 4444", BirthDate = "12/01/1990" });
        context.SaveChanges();

        var controller = new MemberController(null);
        controller.Context = context;

      }
    }
  }
}
