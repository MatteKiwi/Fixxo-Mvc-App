using System.ComponentModel.DataAnnotations;

namespace Fixxo_Web_Api.Models.Entities;

public class ContactEntity
{
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Message { get; set; } = null!;
}