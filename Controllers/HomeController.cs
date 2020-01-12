using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AmaraCode.CManager.Models;
using AmaraCode.CManager.AppService;

namespace cmanager.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HomeAppService _serivce; 



        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="homeAppService"></param>
        public HomeController(ILogger<HomeController> logger, HomeAppService homeAppService)
        {
            _logger = logger;
            _serivce = homeAppService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = _serivce.HomeIndex();
            return View(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
