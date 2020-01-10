using Microsoft.AspNetCore.Mvc;
using AmaraCode.CManager.AppServices;
using Microsoft.Extensions.DependencyInjection;

namespace AmaraCode.CManager.Controllers
{
    public class CompanyController : Controller
    {
        CompanyAppService _service;

        public CompanyController(CompanyAppService cas)
        {
            _service = cas;
        }

        public IActionResult Index()
        {
            return View(_service.CompanyIndex());
        }

        public IActionResult List()
        {
            return View(_service.CompanyList());
        }

    }

}