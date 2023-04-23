namespace Fixxo_MVC_App.Models;

public class ProductModel
{
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Tag { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int StarRating { get; set; }

    public static implicit operator CollectionItemModel(ProductModel model)
    {
        return new CollectionItemModel
        {
            ArticleNumber = model.ArticleNumber,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Tag = model.Tag,
            ImageUrl = model.ImageUrl,
            StarRating = model.StarRating
        };
    }
}