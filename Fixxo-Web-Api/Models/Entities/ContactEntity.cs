using System.ComponentModel.DataAnnotations;
using Fixxo_Web_Api.Models.DTO;

namespace Fixxo_Web_Api.Models.Entities;

public class ContactEntity
{
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Message { get; set; } = null!;

    public static implicit operator ContactModel(ContactEntity entity)
    {
        return new ContactModel
        {
            Name = entity.Name,
            Email = entity.Email,
            Message = entity.Message
        };
    }
}