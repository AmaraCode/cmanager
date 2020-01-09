using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AmaraCode.CManager.Models;
using AmaraCode.CManager.AppServices;

namespace AmaraCode.CManager.Controllers
{
    public class CompanyController : Controller
    {
        CompanyAppService _service;

        public CompanyController()
        {
            _service = new CompanyAppService();
        }

        public IActionResult Index()
        {
            return View();
        }



    }

}