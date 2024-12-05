using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetController : ControllerBase
{
    private readonly AppDbContext _context;

    public BudgetController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Budget>> GetBudget()
    {
        return await _context.Budgets.FirstOrDefaultAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Budget>> SetBudget(Budget budget)
    {
        _context.Budgets.Add(budget);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBudget), budget);
    }
}
