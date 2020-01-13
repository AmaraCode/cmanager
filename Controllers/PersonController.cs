using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmaraCode.CManager.AppService;
using Microsoft.AspNetCore.Mvc;

namespace AmaraCode.CManager.Controllers
{
    public class PersonController : Controller
    {
        private PersonAppService _service;

        public PersonController(PersonAppService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var result = _service.GetPersons();
            return View(result);
        }
    }
}