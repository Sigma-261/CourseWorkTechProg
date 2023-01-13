using CourseWorkMain.Models;
using CourseWorkMain.Models.ViewModels;
using MathNet.Numerics.Statistics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CourseWorkMain.Controllers
{
    public class HomeContoller : Controller
    {
        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:7105/";
        public async Task<ActionResult> Index()
        {

            List<BusinessTrip> LocInfo = new List<BusinessTrip>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient
                HttpResponseMessage Res = await client.GetAsync("/api/GetLocalities");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var LocResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Localities list
                    LocInfo = JsonConvert.DeserializeObject<List<BusinessTrip>>(LocResponse);
                }

                
                //returning the Localities list to view
                return View(LocInfo);
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            BusinessTrip LocInfo = null;
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetLocalitiyById?id=" + id.ToString());
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var LocResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Localities list
                    if (LocResponse != "{}")
                        LocInfo = JsonConvert.DeserializeObject<BusinessTrip>(LocResponse);
                }

                if (LocInfo != null)
                {
                    return PartialView("Details", LocInfo);
                }
                return View("Index");
            }
        }

        public async Task<ActionResult> Statistic()
        {
            Stats StInfo = new();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetStatisticBudgets");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var StResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Localities list
                    StInfo = JsonConvert.DeserializeObject<Stats>(StResponse);
                }
                if (StInfo != null)
                {
                    return PartialView("Statistic", StInfo);
                }
                return View("Index");
            }
        }

        public async Task<ActionResult> LocalityByTable()
        {
            List<BusinessTrip> LocInfo = new List<BusinessTrip>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetLocalities");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var LocResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Localities list
                    LocInfo = JsonConvert.DeserializeObject<List<BusinessTrip>>(LocResponse);
                }

                if (LocInfo != null)
                {
                    return PartialView("LocalityByTable", LocInfo);
                }
                return View("Index");
            }
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BusinessTrip loc)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient

                JsonContent content = JsonContent.Create(loc);

                HttpResponseMessage Res = await client.PostAsync("api/CreateLocality", content);
                //Checking the response is successful or not which is sent using HttpClient

                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Update(int id)
        {
            BusinessTrip LocInfo = new();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetLocalitiyById?id=" + id.ToString());
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var LocResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Localities list
                    LocInfo = JsonConvert.DeserializeObject<BusinessTrip>(LocResponse);
                }
            }

            if (LocInfo != null)
            {
                return PartialView("Update", LocInfo);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(BusinessTrip loc)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient

                JsonContent content = JsonContent.Create(loc);

                HttpResponseMessage Res = await client.PostAsync("api/UpdateLocality", content);
                //Checking the response is successful or not which is sent using HttpClient

                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            BusinessTrip LocInfo = new();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/GetLocalitiyById?id=" + id.ToString());
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var LocResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Localities list
                    LocInfo = JsonConvert.DeserializeObject<BusinessTrip>(LocResponse);
                }
            }

            if (LocInfo != null)
            {
                return PartialView("Delete", LocInfo);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteRecord(int id)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetLocalities using HttpClient

                JsonContent content = JsonContent.Create(id);

                HttpResponseMessage Res = await client.PostAsync("api/DeleteLocality", content);
                //Checking the response is successful or not which is sent using HttpClient

                return RedirectToAction("Index");
            }
        }
    }
}
