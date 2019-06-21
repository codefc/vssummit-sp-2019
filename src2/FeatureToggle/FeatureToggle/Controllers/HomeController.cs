using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeatureToggle.Models;
using Microsoft.AspNetCore.Hosting;
using FeatureToggle.Service;

namespace FeatureToggle.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGithubAPIService _service;
        private readonly IHostingEnvironment _environment;

        public HomeController(IGithubAPIService service, IHostingEnvironment env)
        {
            _service = service;
            _environment = env;
        }

        public IActionResult Index()
        {
            ViewBag.Env = _environment.EnvironmentName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FindRepositories(string name)
        {
            ViewBag.Repositories = await _service.GetRepositories(name);


            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
