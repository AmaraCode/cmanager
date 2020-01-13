using System;
using System.Linq;
using System.Collections.Generic;
using AmaraCode.CManager.Models;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Threading;

namespace AmaraCode.CManager.Infrastructure
{
    public class CompanyRepository : ICompanyRepository
    {


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="environment"></param>
        public CompanyRepository()
        {
            
        }


        //make the underlying  available for searches
        public IDictionary<Guid, Company> Companies
        { get
            { return DataContext.Companies; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public IEnumerable<Company> GetCompanies(bool enabled = true)
        {
            return from c in DataContext.Companies.Values
                         where c.Enabled == enabled
                         orderby c.City, c.CompanyName
                         select c;
        }




        public Company GetCompany(Guid id)
        {
            return DataContext.Companies[id];
        }

        public Company GetCompany(string name)
        {
            var x = DataContext.Companies.Where(x => x.Value.CompanyName.ToLower() == name.ToLower()).FirstOrDefault();
            return x.Value;
        }

        public void DeleteCompany(Guid id)
        {
            DataContext.Companies[id].Enabled = false;
            SaveCompanyFile();
        }

        public async Task<Company> SaveCompanyAsync(Company company)
        {
            company.ID = Guid.NewGuid();
            company.Created = DateTime.Now;
            DataContext.Companies.Add(company.ID, company);

            var x = await SaveCompanyFile();

            return company;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<Company> EditCompanyAsync(Company company)
        {
            try
            {
                DataContext.Companies[company.ID] = company;
                var x = await SaveCompanyFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return company;
        }


      

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Task<bool> SaveCompanyFile()
        {
            bool result = false;
            try
            {
                var c = new FileIO<Dictionary<Guid, Company>, Company>(DataContext.Path);
                result = c.SaveData(DataContext.Companies);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(result); 
        }


       

       
    }

}