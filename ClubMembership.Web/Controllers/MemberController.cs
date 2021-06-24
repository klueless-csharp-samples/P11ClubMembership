namespace ClubMembership.Web.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Diagnostics;
  using System.IO;
  using System.Linq;
  using System.Threading.Tasks;
  using ClubMembership.Web.Context;
  using ClubMembership.Web.Data;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.AspNetCore.Mvc.Rendering;
  using Microsoft.EntityFrameworkCore;

  // Member controller has Diagnostics built included
  public class MemberController : Controller
  {
    public MemberController(MsDbContext context)
    {
      Context = context;
    }

    public DomainContext Context { get; set; }
    
    // GET: Member
    public async Task<IActionResult> Index()
    {
      var count = Context.Members.Count();

      // Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
      Debug.WriteLine("--------------------------------------------------------------------------------");
      Debug.WriteLine("Get list of members");
      Debug.WriteLine("--------------------------------------------------------------------------------");
      Debug.WriteLine($"No of members: {count}");
      Debug.WriteLineIf(count < 10, "You don't have many members yet");
      Debug.WriteLine("--------------------------------------------------------------------------------");
      Debug.WriteLine("Member names");
      Debug.WriteLine("--------------------------------------------------------------------------------");

      await Context.Members.ForEachAsync<Member>((m) =>
      {
        Debug.WriteLine($"{m.FirstName} {m.LastName}");
      });

      return View(await Context.Members.ToListAsync());
    }

    // GET: Member/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      Debug.WriteLine("--------------------------------------------------------------------------------");
      Debug.WriteLine("Member Details");
      Debug.WriteLine("--------------------------------------------------------------------------------");

      // Open TraceIt.txt, write log messages, close file
      using (FileStream myFS = new FileStream("TraceIt.txt", FileMode.Append))
      {
        Trace.Listeners.Add(new TextWriterTraceListener(myFS));
        Trace.WriteLine($"About to view user details: {id}");
        Debug.WriteLine($"Debug - View user details: {id}");
      }

      try
      {
        if (id == 69) {
          throw new Exception("User 69 is not valid");
        }
      }
      catch (System.Exception ex)
      {
         Trace.TraceError(ex.Message);
         Trace.TraceError(ex.StackTrace);
      }

      if (id == null)
      {
        return NotFound();
      }

      var member = await Context.Members.FirstOrDefaultAsync(m => m.Id == id);
      if (member == null)
      {
        return NotFound();
      }

      Debug.WriteLine($"View member details: {id}-{member.FirstName} {member.LastName}");

      return View(member);
    }

    // GET: Member/Create
    public IActionResult Create()
    {
      Debug.WriteLine("Create member");

      return View();
    }

    // POST: Member/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    // Id,FirstName,LastName,Phone,BirthDate
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,BirthDate")] Member member)
    {
      if (ModelState.IsValid)
      {
        Context.Add(member);
        await Context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View(member);
    }

    // GET: Member/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var member = await Context.Members.FindAsync(id);
      if (member == null)
      {
        return NotFound();
      }

      Debug.WriteLine($"Edit member: {id}-{member.FirstName} {member.LastName}");

      return View(member);
    }

    // POST: Member/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,BirthDate")] Member member)
    {
      Debug.WriteLine("--------------------------------------------------------------------------------");
      Debug.WriteLine("Save Member Details");
      Debug.WriteLine("--------------------------------------------------------------------------------");

      if (id != member.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          Trace.TraceInformation("Save Member - Started");
          Debug.WriteLine($"Save Member details: {id}-{member.FirstName} {member.LastName}");

          Context.Update(member);

          await Context.SaveChangesAsync();
          Trace.TraceInformation("Save Member - Finished");
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MemberExists(member.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }

      return View(member);
    }

    // GET: Member/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var member = await Context.Members
        .FirstOrDefaultAsync(m => m.Id == id);
      if (member == null)
      {
        return NotFound();
      }

      return View(member);
    }

    // POST: Member/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var member = await Context.Members.FindAsync(id);
      Context.Members.Remove(member);
      await Context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MemberExists(int id)
    {
      return Context.Members.Any(e => e.Id == id);
    }
  }
}
