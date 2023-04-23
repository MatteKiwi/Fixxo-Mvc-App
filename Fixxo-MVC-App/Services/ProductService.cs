using Fixxo_MVC_App.Models;

namespace Fixxo_MVC_App.Services;

public class ProductService
{
    public async Task<IEnumerable<CollectionItemModel>> GetByTagAsync(string tagName)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");

        var response = await httpClient.GetFromJsonAsync<IEnumerable<CollectionItemModel>>($"https://localhost:7084/api/Products/tags/{tagName}");

        List<CollectionItemModel> products = new List<CollectionItemModel>();
        foreach (var product in response)
        {
            CollectionItemModel prod = new CollectionItemModel
            {
                ArticleNumber = product.ArticleNumber,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Tag = product.Tag,
                ImageUrl = product.ImageUrl,
                StarRating = product.StarRating
            };
            products.Add(prod);
        }
        response = products;
        return response;
    }

    public async Task<IEnumerable<CollectionItemModel>> GetAll()
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");

        var response = await httpClient.GetFromJsonAsync<IEnumerable<CollectionItemModel>>($"https://localhost:7084/api/Products/");

        return response!;
        
    }

    public async Task<ProductModel> GetByArticleNumberAsync(string articleNumber)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");

        var response = await httpClient.GetFromJsonAsync<ProductModel>($"https://localhost:7084/api/Products/{articleNumber}");

        return response!;
    }

}