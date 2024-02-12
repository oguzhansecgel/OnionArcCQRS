using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionArcCQRS.Dto.BlogDtos;
using OnionArcCQRS.Dto.TagCloudDtos;

namespace OnionArcCQRS.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsTagCloudComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogsId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7179/api/TagCloud/GetTagCloudByBlogId/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetTagByIdCloudDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
