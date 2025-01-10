using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models;

public class Expense {

    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } // To associate expenses with a user

    [Required]
    [StringLength(50)]
    public string Category { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

}