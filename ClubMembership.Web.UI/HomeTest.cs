using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
namespace ClubMembership.Web.UI
{
    [TestClass]
    public class HomeTest
    {
      [TestMethod]
      public void HomePage()
      {
        TestHelpers.RunTestInChrome("/", test: (ChromeDriver driver) => {
          Assert.IsTrue(driver.Title.Contains("Home"));
        });
      }

      [TestMethod]
      public void PrivacyPage()
      {
        TestHelpers.RunTestInChrome("/Home/Privacy", test: (ChromeDriver driver) => {
          Assert.IsTrue(driver.Title.Contains("Privacy Policy"));
        });
      }
    }
}
