using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Controllers;

[Route("api/expenses")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExpenseController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
    {
        return await _context.Expenses.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> AddExpense(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return NotFound();
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
