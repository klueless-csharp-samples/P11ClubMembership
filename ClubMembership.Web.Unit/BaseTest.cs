using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

public class BaseTest
{
  [TestInitialize()]
  public void Startup()
  {
    // dotnet test  --logger:"console;verbosity=detailed"

    // Trace.WriteLine("Starting Unit Tests");
  }
}
