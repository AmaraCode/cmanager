using System;
using System.Collections.Generic;
using AmaraCode.CManager.Infrastructure;
using AmaraCode.CManager.Models;
using System.Linq;

namespace AmaraCode.CManager.AppServices
{

    public class CompanyAppService
    {
        private ICompanyRepository _repo;

        public CompanyAppService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        public CompanyIndexViewModel CompanyIndex()
        {
            //get conversations
            var result = (from c in _repo.Companies.Values
                         join cv in _repo.Conversations.Values
                            on c.ID equals cv.CompanyID
                        orderby cv.Created
                         select (new ConversationCompanyViewModel
                         {
                             Company = c,
                             Conversation = cv
                         })).Take(15);


             var model = new CompanyIndexViewModel
            {
                CompanyCount = _repo.Companies.Count,
                ConversationCount = _repo.Conversations.Count,
                LatestConversations = result
                
            };

            return model;
            
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Company> CompanyList()
        {
            var result = from c in _repo.Companies.Values
                         orderby c.City, c.Phone
                         select c;

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
                    Address = company.Address,
                    City = company.City,
                    CompanyName = company.CompanyName,
                    Important = company.Important,
                    Phone = company.Phone,
                    State = company.State,
                    Website = company.Website,
                    Zip = company.Zip
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