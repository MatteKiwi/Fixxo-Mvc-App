namespace Fixxo_MVC_App.ViewModels;

public class CreateProductViewModel
{
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Tag { get; set; } = null!;
}