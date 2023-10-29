using Microsoft.AspNetCore.Mvc;
using ASP.NET_section_8.Models;
using Microsoft.VisualBasic;
using System.Globalization;

namespace ASP.NET_section_8.Controllers
{
    public class WeatherController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            List<CityWeather> cityWeathers = new List<CityWeather>()
            {
                new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = new DateTime(2030, 01, 01, 8, 00, 00), TemperatureFahrenheit = 33 },
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = new DateTime(2030, 01, 01, 3, 00, 00),  TemperatureFahrenheit = 60 },
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = new DateTime(2030, 01, 01, 9, 00, 00),  TemperatureFahrenheit = 82}
            };

            return View(cityWeathers);
        }

        [HttpGet]
        [Route("/weather/{cityuniq}")]
        public IActionResult Weather(string? cityuniq)
        {
            List<CityWeather> cityWeathers = new List<CityWeather>()
            {
                new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = new DateTime(2030, 01, 01, 8, 00, 00), TemperatureFahrenheit = 33 },
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = new DateTime(2030, 01, 01, 3, 00, 00),  TemperatureFahrenheit = 60 },
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = new DateTime(2030, 01, 01, 9, 00, 00),  TemperatureFahrenheit = 82}
            };

            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }

            CityWeather? cityWeather = cityWeathers.Where(n => n.CityUniqueCode == cityuniq).FirstOrDefault();
            return View(cityWeather);
        }
    }
}
