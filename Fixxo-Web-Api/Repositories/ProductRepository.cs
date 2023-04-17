using Fixxo_Web_Api.Contexts;
using Fixxo_Web_Api.Models.DTO;
using Fixxo_Web_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fixxo_Web_Api.Repositories;

public class ProductRepository
{
     private readonly DataContext _context;
     public ProductRepository(DataContext context)
     {
         _context = context;
     }
     
     public async Task<IEnumerable<ProductHttpResponse>> GetAllAsync()
     {
        var items = await _context.Products.ToListAsync();
        var products = new List<ProductHttpResponse>();
        
        foreach (var item in items)
        {
            products.Add(item);
        }
        return products;
     }

     public async Task<ProductEntity> GetByArticleNumberAsync(string articleNumber)
     {
        var item = await _context.Products.FindAsync(articleNumber);
        return item!;
     }
   
     public async Task<IEnumerable<ProductHttpResponse>> GetByTagAsync(string tagName)
     {
         var items = await _context.Products.Where(p => p.Tag == tagName).ToListAsync();
         var products = new List<ProductHttpResponse>();
         
         foreach (var item in items)
         {
             products.Add(item);
         }
         
         return products;
     }
     
        
      public async Task<ProductHttpResponse> CreateAsync(ProductEntity product)
      {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
      }
     
}