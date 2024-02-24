using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionArcCQRS.Dto.StatisticsDtos;

namespace OnionArcCQRS.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7179/api/Statistic/GetCarCount");
            if(responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0,101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.CarCount;
                ViewBag.v1 = v1;

            }
            var responseMessage2 = await client.GetAsync("https://localhost:7179/api/Statistic/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int v2 = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locaitonCount = values2.LocationCount;
                ViewBag.locationCountRandom = v2;

            }
            var responseMessage3 = await client.GetAsync("https://localhost:7179/api/Statistic/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int v3 = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.locaitonCount = values3.LocationCount;
                ViewBag.locationCountRandom = v3;

            }
            return View();
        }
    }
}
