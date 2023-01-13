using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;
using CourseWorkMain.Repositories;
using CourseWorkMain.Models;
using MathNet.Numerics.Statistics;

namespace CourseWorkMain.Controllers
{
    [Route("api")]
    [Produces("application/json")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private BaseRepository _repo;
        private readonly ILogger<ApiController> _logger;
        private readonly IConfiguration _config;

        public ApiController(BaseRepository Repo, ILogger<ApiController> logger = null, IConfiguration config = null)
        {
            _logger = logger;
            _config = config;
            _repo = Repo;
        }

        //-----------------------------ЗАПРОСЫ-----------------------------
        /// <summary>
        /// Получить все локации
        /// </summary>
        [HttpGet("GetBusinessTrips")]
        public IActionResult GetBusinessTrips()
        {
            dynamic businessTrips = new JArray();

            var ForeachLocalities = _repo.GetBusinessTrips();
            foreach (var l in ForeachLocalities)
            {
                businessTrips.Add(new JObject(
                    new JProperty("id", l.id),
                    new JProperty("employee", l.Employee),
                    new JProperty("days", l.Days),
                    new JProperty("wage", l.Wage),
                    new JProperty("city", l.City)
                    ));
            }

            string respStr = businessTrips.ToString();

            return Content(respStr);
        }

        /// <summary>
        /// Получить статистику по бюджетам
        /// </summary>
        [HttpGet("GetStatistic")]
        public IActionResult GetStatisticWage()
        {
            var StatisticFromResult = _repo.GetLStatisticBudgets(_repo.GetBudgets());
            var statistic = new JObject(
                new JProperty("Median", StatisticFromResult.Median),
                new JProperty("Mean", StatisticFromResult.Mean),
                new JProperty("Max", StatisticFromResult.Max),
                new JProperty("Min", StatisticFromResult.Min)
                );

            string respStr = statistic.ToString();

            return Content(respStr);
        }

        /// <summary>
        /// Получить все командировки
        /// </summary>
        [HttpGet("GetBusinessTripById")]
        public IActionResult GetBusinessTripById([FromQuery(Name = "id")] int id)
        {
            dynamic resp = new JObject();

            var l = _repo.GetBusinessTripById(id);
            if (l != null)
            {
                resp = new JObject(
                    new JProperty("id", l.id),
                    new JProperty("employee", l.Employee),
                    new JProperty("days", l.Days),
                    new JProperty("wage", l.Wage),
                    new JProperty("city", l.City)
                    );
            }

            string respStr = resp.ToString();

            return Content(respStr);
        }

        /// <summary>
        /// Создать командировку
        /// </summary>
        [HttpPost("CreateBusinessTrip")]
        public IActionResult CreateLocality([FromBody] BusinessTrip locality)
        {
            string employee = locality.Employee;
            int days = locality.Days;
            int wage = locality.Wage;
            string city = locality.City;

            BusinessTrip loc = new BusinessTrip();

            loc.Employee = employee;
            loc.Days = days;
            loc.Wage = wage;
            loc.City = city;

            bool res = _repo.CreateBusinessTrip(loc);

            string respStr = res.ToString();

            return Content(respStr);
        }

        /// <summary>
        /// Редактировать командировку
        /// </summary>
        [HttpPost("UpdateBusinessTrip")]
        public IActionResult UpdateLocality([FromBody] BusinessTrip locality)
        {

            bool res = _repo.UpdateBusinessTrip(locality);

            string respStr = res.ToString();

            return Content(respStr);
        }

        /// <summary>
        /// Удалить командировку по айди
        /// </summary>
        [HttpPost("DeleteBusinessTrip")]
        public IActionResult DeleteLocality([FromBody] int id)
        {
            try
            {
                bool res = _repo.DeleteBusinessTrip(id);

                string respStr = res.ToString();

                return Content(respStr);
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Получить все 
        /// </summary>
        [HttpGet("GetBusinessTripsByEmployee")]
        public IActionResult GetBusinessTripsByEmployee([FromQuery(Name = "employee")] string employee)
        {
            dynamic localities = new JArray();

            var ForeachLocalities = _repo.GetBusinessTripsByEmployee(employee);
            foreach (var l in ForeachLocalities)
            {
                localities.Add(new JObject(
                    new JProperty("id", l.id),
                    new JProperty("employee", l.Employee),
                    new JProperty("days", l.Days),
                    new JProperty("wage", l.Wage),
                    new JProperty("city", l.City)
                    ));
            }

            string respStr = localities.ToString();

            return Content(respStr);
        }

        /// <summary>
        /// Получить медиану бюджета
        /// </summary>
        [HttpGet("GetMedianBudget")]
        public IActionResult GetMedianBudget()
        {
            var ForeachLocalities = _repo.GetBudgets();

            var str = Statistics.Median(ForeachLocalities);

            string respStr = str.ToString();

            return Content(respStr);
        }

        // <summary>
        /// Получить среднее бюджета
        /// </summary>
        [HttpGet("GetMeanBudget")]
        public IActionResult GetMeanBudget()
        {
            var ForeachLocalities = _repo.GetBudgets();

            var str = Statistics.Mean(ForeachLocalities);

            string respStr = str.ToString();

            return Content(respStr);
        }

        // <summary>
        /// Получить Максимальный бюджета
        /// </summary>
        [HttpGet("GetMaxBudget")]
        public IActionResult GetMaxBudget()
        {
            var ForeachLocalities = _repo.GetBudgets();

            var str = Statistics.Maximum(ForeachLocalities);

            string respStr = str.ToString();

            return Content(respStr);
        }

        // <summary>
        /// Получить минимум бюджета
        /// </summary>
        [HttpGet("GetMinBudget")]
        public IActionResult GetMinBudget()
        {
            var ForeachLocalities = _repo.GetBudgets();

            var str = Statistics.Minimum(ForeachLocalities);

            string respStr = str.ToString();

            return Content(respStr);
        }
    }
}
