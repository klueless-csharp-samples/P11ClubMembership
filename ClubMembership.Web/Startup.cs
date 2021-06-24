namespace ClubMembership.Web
{
  using System;
  using System.Diagnostics;
  using ClubMembership.Web.Context;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;

  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      // StartProfiler();

      var consoleLog = new TextWriterTraceListener(Console.Out);
      consoleLog.TraceOutputOptions = System.Diagnostics.TraceOptions.Timestamp;
      Trace.Listeners.Add(consoleLog);

      Trace.TraceInformation("Application Startup");

      Configuration = configuration;
    }

    // public void StartProfiler() {
    //   JetBrains.Profiler.SelfApi.DotMemory.EnsurePrerequisite();
      
    //   var config = new JetBrains.Profiler.SelfApi.DotMemory.Config();
    //   config.SaveToDir("ProfileLogs");
    //   JetBrains.Profiler.SelfApi.DotMemory.GetSnapshotOnce(config);

    //   JetBrains.Profiler.SelfApi.DotMemory.Attach();
    // }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      Trace.TraceWarning("Configure Services");

      string connectionString = "Server=localhost,1433; Database=P11;User=sa; Password=Password3";

      Trace.WriteLine("Setup DB Context");
      services.AddDbContext<MsDbContext>(options => options.UseSqlServer(connectionString));

      Trace.WriteLine("Add Controller Routes");
      services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      Trace.WriteLine("Setup Routing");
      app.UseRouting();

      Trace.WriteLine("Setup Authorization");

      Trace.WriteLine($"Environment Name: {Environment.UserName}");

      Trace.WriteLineIf(Environment.UserName == "davidcruwys", "Note: This application is running from David's development machine");

      Trace.TraceError("Do not run this application in production");

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
