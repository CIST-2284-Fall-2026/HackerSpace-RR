using System.ComponentModel.DataAnnotations;

namespace Common.Models;

public record Evaluator
{
    public Guid Id { get; set; }
    [Required, StringLength(100, MinimumLength = 5)]
    public string Name { get; set; } = "";
    [Required, EmailAddress]
    public string Email { get; set; } = "";
    public string Background { get; set; } = "";
}
