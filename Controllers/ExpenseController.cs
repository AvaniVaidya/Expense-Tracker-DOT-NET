using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTracker.Controllers;

[Authorize]
public class ExpenseController : Controller {

    private readonly ApplicationDbContext _context;

    public ExpenseController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Expense
    public async Task<IActionResult> Index()
    {
        return View(await _context.Expenses.ToListAsync());
        return View();
    }

    // GET: Expense/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Expense/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Category,Amount,Date,Description")] Expense expense)
    {
        //if (ModelState.IsValid)
        {
            //expense.UserId = User.Identity.Name; // Replace with actual user ID logic
            expense.UserId = "Avani";
            expense.Date = DateTime.SpecifyKind(expense.Date, DateTimeKind.Utc);
            _context.Add(expense);
            try{
                await _context.SaveChangesAsync();
            }catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            return RedirectToAction(nameof(Index));
        }
        return View(expense);
    }

    // GET: Expense/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null) return NotFound();

        return View(expense);
    }

    // POST: Expense/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Amount,Date,Description")] Expense expense)
    {
        if (id != expense.Id) return NotFound();

        //if (ModelState.IsValid)
        {
            try
            {
                expense.UserId = "Avani";
                expense.Date = DateTime.SpecifyKind(expense.Date, DateTimeKind.Utc);
                _context.Update(expense);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(expense.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(expense);
    }

    // GET: Expense/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var expense = await _context.Expenses
            .FirstOrDefaultAsync(m => m.Id == id);
        if (expense == null) return NotFound();

        return View(expense);
    }

    // POST: Expense/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
         try{
        var expense = await _context.Expenses.FindAsync(id);
        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        }catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        return RedirectToAction(nameof(Index));
    }

    private bool ExpenseExists(int id)
    {
        return _context.Expenses.Any(e => e.Id == id);
    }

}

