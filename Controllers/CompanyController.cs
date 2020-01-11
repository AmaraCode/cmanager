using Microsoft.AspNetCore.Mvc;
using AmaraCode.CManager.AppServices;
using Microsoft.Extensions.DependencyInjection;
using AmaraCode.CManager.Models;

namespace AmaraCode.CManager.Controllers
{
    public class CompanyController : Controller
    {
        CompanyAppService _service;

        public CompanyController(CompanyAppService cas)
        {
            _service = cas;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.CompanyIndex());
        }

        [HttpGet]
        public IActionResult List()
        {

            return View(_service.CompanyList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            // create empty object and send to view
            return View( new CompanyCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(CompanyCreateViewModel model)
        {
            //do the save stuff here to the App Service
            var company = new Company
            {
                Address = model.Address,
                City = model.City,
                CompanyName = model.CompanyName,
                Important = model.Important,
                Phone = model.Phone,
                State = model.State,
                Zip = model.Zip,
                Website = model.Website
            };

            _service.SaveCompany(company);

            return RedirectToAction("List");
        }

    }

}