using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
namespace ClubMembership.Web.UI
{
    [TestClass]
    public class MemberTest
    {
      [TestMethod]
      public void IndexPageIsShown()
      {
        TestHelpers.RunTestInChrome("/Member", test: (ChromeDriver driver) => {
          Assert.IsTrue(driver.Title.Contains("List of Members"));
        });
      }

      [TestMethod]
      public void CreatePageIsShown()
      {
        TestHelpers.RunTestInChrome("/Member/Create", test: (ChromeDriver driver) => {
          Assert.IsTrue(driver.Title.Contains("Create Member"));
        });
      }

      [TestMethod]
      public void EditPageIsShown()
      {
        TestHelpers.RunTestInChrome("/Member/Edit/1", test: (ChromeDriver driver) => {
          Assert.IsTrue(driver.Title.Contains("Edit Member"));
        });
      }

      [TestMethod]
      public void DeletePageIsShown()
      {
        TestHelpers.RunTestInChrome("/Member/Delete/1", test: (ChromeDriver driver) => {
          Assert.IsTrue(driver.Title.Contains("Delete Member"));
        });
      }

      [TestMethod]
      public void DetailsPageIsShown()
      {
        TestHelpers.RunTestInChrome("/Member/Details/1", test: (ChromeDriver driver) => {
          Assert.IsTrue(driver.Title.Contains("Member Details"));
        });
      }
    }
}
