using Fixxo_Web_Api.Models.Entities;

namespace Fixxo_Web_Api.Models.DTO;

public class ContactModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Message { get; set; } = null!;

    public static implicit operator ContactEntity(ContactModel model)
    {
        return new ContactEntity
        {
            Name = model.Name,
            Email = model.Email,
            Message = model.Message
        };
    }
}