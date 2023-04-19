using Fixxo_MVC_App.Models;

namespace Fixxo_MVC_App.Services;

public class ProductService
{
    public async Task<IEnumerable<ProductModel>> GetByTagAsync(string tagName)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");

        var response = await httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>($"https://localhost:7084/api/Products/tags/{tagName}");

        return response!;
    }

    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");

        var response = await httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>($"https://localhost:7084/api/Products/");

        return response!;
        
    }

    public async Task<IEnumerable<ProductModel>> GetByArticleNumberAsync(string articleNumber)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-key", "3be6546d-21bf-4102-92b1");

        var response = await httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>($"https://localhost:7084/api/Products/{articleNumber}");

        return response!;
    }

}