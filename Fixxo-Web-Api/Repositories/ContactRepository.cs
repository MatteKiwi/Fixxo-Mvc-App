using Fixxo_Web_Api.Contexts;
using Fixxo_Web_Api.Models.DTO;
using Fixxo_Web_Api.Models.Entities;

namespace Fixxo_Web_Api.Repositories;

public class ContactRepository
{
    private readonly DataContext _context;
    
    public ContactRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ContactModel> CreateAsync(ContactEntity entity)
    {
        _context.Contacts.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
  
}