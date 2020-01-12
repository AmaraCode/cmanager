using Microsoft.AspNetCore.Mvc;
using AmaraCode.CManager.AppService;
using Microsoft.Extensions.DependencyInjection;
using AmaraCode.CManager.Models;
using System;

namespace AmaraCode.CManager.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CompanyController : Controller
    {
        CompanyAppService _service;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cas"></param>
        public CompanyController(CompanyAppService cas)
        {
            _service = cas;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.CompanyIndex());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List()
        {
            return View(_service.CompanyIndex());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            // create empty object and send to view
            return View(new CompanyCreateViewModel());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

                TempData["message"] = "Company Created";
                return RedirectToAction("List");
            }
            else
            {
                TempData["message"] = "Error Creating Company";
                return View(model);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            CompanyCreateViewModel model = _service.GetCompany(id);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

                TempData["message"] = "Company Edited";
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = _service.GetCompany(id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return View("List");
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirmed (Guid id)
        {
            TempData["message"] = "Company Removed";
            _service.DeleteCompany(id);
            return RedirectToAction("List");
        }
    }

}