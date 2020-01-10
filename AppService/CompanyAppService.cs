using System;
using System.Collections.Generic;
using AmaraCode.CManager.Infrastructure;
using AmaraCode.CManager.Models;
using Microsoft.Extensions.DependencyInjection;

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
            var model = new CompanyIndexViewModel
            {
                CompanyCount = _repo.Companies.Count,
                ConversationCount = _repo.Conversations.Count
            };

            return model;
            
        }


        public IList<Company> CompanyList()
        {
            return _repo.Companies;
        }

    }

}