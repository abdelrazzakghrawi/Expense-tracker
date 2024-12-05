using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerAPI.Models;

public class Budget
{
    [Key] // Ajoute une annotation de clé primaire
    public int Id { get; set; } // Propriété clé primaire
    public decimal MonthlyBudget { get; set; }
    public decimal TotalExpenses { get; set; }
}
