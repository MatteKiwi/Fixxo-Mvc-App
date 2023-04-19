using System.ComponentModel.DataAnnotations;

namespace Fixxo_MVC_App.ViewModels;

public class CreateProductViewModel
{
    [Required]
    public string ArticleNumber { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string ImageUrl { get; set; } = null!;
    [Required]
    public string Tag { get; set; } = null!;

    [Required] 
    [RegularExpression(@"^[1-5]{1}$", ErrorMessage = "Star Rating is invalid")]
    public int StarRating { get; set; } 
}