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
            var result = (from c in _repo.Companies
                         join cv in _repo.Conversations
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


        public IEnumerable<Company> CompanyList()
        {
            var result = from c in _repo.Companies
                         orderby c.City, c.Phone
                         select c;

            return result;

                         
        }

    }

}