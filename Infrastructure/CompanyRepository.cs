using System;
using AmaraCode.CManager.Models;

namespace AmaraCode.CManager.Infrastructure
{
    class CompanyRepository
    {

        private AppDbContext _db;

        public CompanyRepository(AppDbContext dbcontext)
        {
            _db = dbcontext;

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