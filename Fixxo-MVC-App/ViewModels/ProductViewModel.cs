namespace Fixxo_MVC_App.ViewModels;

public class ProductViewModel
{
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public string Tag { get; set; } = null!;
    public int StarRating { get; set; }
}