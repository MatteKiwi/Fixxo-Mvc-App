using Fixxo_Web_Api.Contexts;
using Fixxo_Web_Api.Models.DTO;

namespace Fixxo_Web_Api.Repositories;

public class ProductRepository
{
     private readonly DataContext _context;
     public ProductRepository(DataContext context)
     {
         _context = context;
     }
     /*
     public async Task<IEnumerable<ProductHttpResponse>> GetAllAsync()
     {
         return await _context.Products.ToListAsync();
     }
     
  
     public async Task<Product> GetByArticleNumberAsync(string articleNumber)
     {
         return await _context.Products.FirstOrDefaultAsync(p => p.ArticleNumber == articleNumber);
     }
   
     public async Task<IEnumerable<ProductHttpResponse>> GetByTagAsync(string tagName)
     {
         return await _context.Products.Where(p => p.Tags.Any(t => t.Name == tagName)).ToListAsync();
     }
   
        public async Task<IEnumerable<ProductHttpResponse>> GetByCategoryAsync(string categoryName)
        {
            return await _context.Products.Where(p => p.Category.Name == categoryName).ToListAsync();
        }
       
    
      public async Task<ProductHttpResponse> CreateAsync(ProductHttpRequest product)
      {
       _context.Products.Add(product);
      await _context.SaveChangesAsync();
      return product;
      }
     */
}