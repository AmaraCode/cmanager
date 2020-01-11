using Microsoft.AspNetCore.Mvc;
using AmaraCode.CManager.AppServices;
using Microsoft.Extensions.DependencyInjection;
using AmaraCode.CManager.Models;
using System;

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
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompanyCreateViewModel model)
        {
            if (ModelState.IsValid)
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
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            CompanyCreateViewModel model =_service.GetCompany(id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                ModelState.AddModelError("Error", "Error getting company.");
                return View("List");
            }
            
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(CompanyCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

                //do the save stuff here to the App Service
                var company = new Company
                {
                    ID = model.ID,
                    Address = model.Address,
                    City = model.City,
                    CompanyName = model.CompanyName,
                    Important = model.Important,
                    Phone = model.Phone,
                    State = model.State,
                    Zip = model.Zip,
                    Website = model.Website
                };

                _service.EditCompany(company);

                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

    }

}