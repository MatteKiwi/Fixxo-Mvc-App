using Fixxo_Web_Api.Models.Entities;

namespace Fixxo_Web_Api.Models.DTO;

public class ProductHttpRequest
{
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public string Tag { get; set; } = null!;
    public int StarRating { get; set; }

    public static implicit operator ProductEntity(ProductHttpRequest request)
    {
        return new ProductEntity
        {
            ArticleNumber = request.ArticleNumber,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            ImageUrl = request.ImageUrl,
            Tag = request.Tag,
            StarRating = request.StarRating
        };
    }
}