namespace ClubMembership.Web.UI
{
    using System;
    using OpenQA.Selenium.Chrome;

    public class TestHelpers
    {
      const string APP_URL = "https://localhost:5001";

      public static void RunTestInChrome(string relative_url, Action<ChromeDriver> test) {

        var options =  new ChromeOptions();
        
        // Turn of SSL checking in local environment so that
        // you don't need to use real certificates.
        options.AddArgument("ignore-ssl-errors=yes");
        options.AddArgument("ignore-certificate-errors");

        var url = $"{APP_URL}{relative_url}";
        
        using (var driver = new ChromeDriver(options))
        {
          driver.Navigate().GoToUrl(url);

          // Run the test provided by the lambda
          test.Invoke(driver);
        }
      }
    }
}
