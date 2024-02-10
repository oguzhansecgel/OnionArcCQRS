using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionArcCQRS.Dto.FooterAddressDtos;
using OnionArcCQRS.Dto.TestimonialDtos;
using OnionArcCQRS.WebUI.ViewComponents.FooterAddressComponents;

namespace OnionArcCQRS.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7179/api/FooterAddress/FooterAddressList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(values);
            }



            return View();
        }
    }
}
//_FooterAddressComponentsPartial