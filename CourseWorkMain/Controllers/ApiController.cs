using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;
using CourseWorkMain.Repositories;

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

        public ApiController(ILogger<ApiController> logger, IConfiguration config, BaseRepository Repo)
        {
            _logger = logger;
            _config = config;
            _repo = Repo;
        }

        //-----------------------------ЗАПРОСЫ-----------------------------
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        [HttpGet("GetLocalities")]
        public IActionResult GetUsers()
        {
            dynamic localities = new JArray();
            dynamic response = new JObject();

            var ForeachLocalities = _repo.GetLocalities();
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

            response.response = localities;

            response.status = "OK";

            string respStr = response.ToString();

            return Content(respStr);
        }
    }
}
