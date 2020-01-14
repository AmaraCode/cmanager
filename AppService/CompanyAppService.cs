using System;
using System.Collections.Generic;
using AmaraCode.CManager.Infrastructure;
using AmaraCode.CManager.Models;
using System.Linq;

namespace AmaraCode.CManager.AppService
{

    public class CompanyAppService
    {
        private ICompanyRepository _repo;

        public CompanyAppService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Company> CompanyIndex()
        {
            //Get all companyes that are Enabled
            var result = _repo.GetCompanies(true);
            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Company> CompanyImportant()
        {
            //Get all companyes that are Enabled
            var result = _repo.GetImportantCompanies();
            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Company SaveCompany(Company model)
        {
            return _repo.SaveCompanyAsync(model).Result;
        }


        public void DeleteCompany(Guid id)
        {
            _repo.DeleteCompany(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyCreateViewModel GetCompany(Guid id)
        {
            
            var company = _repo.GetCompany(id);
            if (company != null)
            {
                var model = new CompanyCreateViewModel
                {
                    ID = company.ID,
                    Address = company.Address,
                    City = company.City,
                    CompanyName = company.CompanyName,
                    Important = company.Important,
                    Phone = company.Phone,
                    State = company.State,
                    Website = company.Website,
                    Zip = company.Zip,
                    Enabled = company.Enabled,
                    OutOfBusiness = company.OutOfBusiness,
                    Notes = company.Notes

                };

                return model;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Company EditCompany(Company model)
        {
            return _repo.EditCompanyAsync(model).Result;
        }

    }

}