using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models;

public enum ExpenseCategory
{
    Food,
    Transport,
    Rent,
    Entertainment,
    Utilities,
    Healthcare,
    Miscellaneous
}

public class Expense {

    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } // To associate expenses with a user

    [NotMapped]
    public ExpenseCategory CategoryEnum
    {
        get => Enum.TryParse(Category, out ExpenseCategory result) ? result : ExpenseCategory.Miscellaneous;
        set => Category = value.ToString();
    }

    [Required]
    public string Category { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

}