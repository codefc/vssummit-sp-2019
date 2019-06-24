using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeatureToggle.Models;
using Microsoft.AspNetCore.Hosting;
using FeatureToggle.Service;
using ConfigCat.Client;
using FeatureToggle.Util;

namespace FeatureToggle.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGithubAPIService _service;
        private readonly IHostingEnvironment _environment;
        private readonly IConfigCatClient _client;

        public HomeController(IGithubAPIService service, IHostingEnvironment env, IConfigCatClient client)
        {
            _service = service;
            _environment = env;
            _client = client;
        }

        public IActionResult Index()
        {
            ViewBag.Env = _environment.EnvironmentName;
            ViewBag.PesquisarRepo = _client.GetValue(ApplicationConstants.FeatureToggle.PESQUISAR_REPOSITORIOS, false);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FindRepositories(string name)
        {
            ViewBag.Env = _environment.EnvironmentName;

            if (_client.GetValue(ApplicationConstants.FeatureToggle.PESQUISAR_REPOSITORIOS, false))
            {
                ViewBag.Repositories = await _service.GetRepositories(name);

                ViewBag.PesquisarRepo = _client.GetValue(ApplicationConstants.FeatureToggle.PESQUISAR_REPOSITORIOS, false);
            }
             
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
