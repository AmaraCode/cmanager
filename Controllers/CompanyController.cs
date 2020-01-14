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
        public IActionResult Important()
        {
            return View(_service.CompanyImportant());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(string returnUrl)
        {
            // create empty object and send to view
            var model = new CompanyCreateViewModel();
            model.ReturnUrl = returnUrl;
            return View(model);
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
                    Website = model.Website,
                    Enabled = model.Enabled,
                    OutOfBusiness = model.OutOfBusiness,
                    Notes = model.Notes
                };

                _service.SaveCompany(company);

                TempData["message"] = "Company Created";
                return Redirect(model.ReturnUrl);
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
        public IActionResult Edit(Guid id, string returnUrl)
        {
            CompanyCreateViewModel model = _service.GetCompany(id);
            model.ReturnUrl = returnUrl; 

            if (model != null)
            {
                return View(model);
            }
            else
            {
                ModelState.AddModelError("Error", "Error getting company.");
                return Redirect(returnUrl);
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
                    Website = model.Website,
                    Enabled = model.Enabled,
                    OutOfBusiness = model.OutOfBusiness,
                    Notes = model.Notes
                };

                _service.EditCompany(company);

                TempData["message"] = "Company Edited";
                return Redirect(model.ReturnUrl);
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
        public IActionResult Delete(Guid id, string returnUrl)
        {
            var model = _service.GetCompany(id);
            model.ReturnUrl = returnUrl;

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return View("Index");
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirmed (Guid id, string returnUrl)
        {
            TempData["message"] = "Company Removed";
            _service.DeleteCompany(id);
            return Redirect(returnUrl);
        }
    }

}