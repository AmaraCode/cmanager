using System;
using System.Collections.Generic;
using AmaraCode.CManager.Models;
using Microsoft.AspNetCore.Hosting;

namespace AmaraCode.CManager.Infrastructure
{
    class CompanyRepository
    {

        private List<Company> _companies;
        private List<Conversation> _conversations;
        private string _path;


        public CompanyRepository(IWebHostEnvironment environment)
        {
            _companies = new List<Company>();
            _conversations = new List<Conversation>();
            _path = environment.ContentRootPath;
        }


        public Company GetCompany(int id)
        {
            throw new NotImplementedException();

        }

        public Company GetCompany(string name)
        {
            throw new NotImplementedException();
        }

        public Company SaveCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Conversation GetConversation(int id)
        {
            throw new NotImplementedException();
        }

        public Conversation SaveConversation(Conversation conversation)
        {
            throw new NotImplementedException();
        }

    }

}