using DeveloperPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace DeveloperPortfolio.ViewComponents
{
    public class WeatherWidgetViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly IMemoryCache _cache;
        private const string ApiKey = "c383dddd1817436a82f112926251905"; 
        private const string CacheKey = "CurrentWeather";

        public WeatherWidgetViewComponent(IHttpClientFactory httpFactory, IMemoryCache cache)
        {
            _httpFactory = httpFactory;
            _cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!_cache.TryGetValue(CacheKey, out WeatherViewModel weather))
            {
                var client = _httpFactory.CreateClient();
                client.BaseAddress = new Uri("http://api.weatherapi.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var apiUrl = $"/v1/current.json?key={ApiKey}&q=Stockholm";
                var response = await client.GetAsync(apiUrl);

                weather = new WeatherViewModel();

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var parsed = JsonConvert.DeserializeObject<WeatherApiResult>(json);

                    weather.City = parsed.location.name;
                    weather.TempCelsius = parsed.current.temp_c;
                    weather.Description = parsed.current.condition.text;
                    weather.IconUrl = parsed.current.condition.icon;
                    weather.WindKph = parsed.current.wind_kph;
                    weather.RainMm = parsed.current.precip_mm;

                    _cache.Set(CacheKey, weather, TimeSpan.FromMinutes(20));
                }
                else
                {
                    weather.City = "Unavailable";
                    weather.TempCelsius = 0;
                    weather.Description = "No data";
                }
            }

            return View("Default", weather);
        }
    }
}

