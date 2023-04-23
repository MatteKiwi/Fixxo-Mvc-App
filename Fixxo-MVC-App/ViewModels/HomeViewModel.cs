using Fixxo_MVC_App.Models;

namespace Fixxo_MVC_App.ViewModels;

public class HomeViewModel
{
   // public List<CollectionItemModel> CollectionList = new List<CollectionItemModel>();
   public IEnumerable<CollectionItemModel> NewProducts { get; set; } = new List<CollectionItemModel>();
    public IEnumerable<CollectionItemModel> FeaturedProducts { get; set; } = new List<CollectionItemModel>();
    public IEnumerable<CollectionItemModel> PopularProducts { get; set; } = new List<CollectionItemModel>();
}