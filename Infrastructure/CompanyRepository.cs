using System;
using System.Linq;
using System.Collections.Generic;
using AmaraCode.CManager.Models;
using Microsoft.AspNetCore.Hosting;

namespace AmaraCode.CManager.Infrastructure
{
    public class CompanyRepository : ICompanyRepository
    {

        private string _path;
        private static DataContext _context;

        //make the underlying  available for searches
        public IList<Company> Companies
        { get
            { return _context.Companies; }
        }

        //make the underlying  available for searches
        public IList<Conversation> Conversations
        { get
            { return _context.Conversations; }
        }


        public CompanyRepository(IWebHostEnvironment environment)
        {
            _path = $@"{environment.ContentRootPath}\data";
            _context = new DataContext();
            LoadData();
        }


        public Company GetCompany(Guid id)
        {
            return _context.Companies.Where(x => x.ID == id).FirstOrDefault();
        }

        public Company GetCompany(string name)
        {
            return _context.Companies.Where(x => x.CompanyName.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public Company SaveCompany(Company company)
        {
            company.ID = Guid.NewGuid();
            _context.Companies.Add(company);

            return company;
        }

        public Conversation GetConversation(Guid id)
        {
            return _context.Conversations.Where(x => x.ID == id).FirstOrDefault();
        }

        public Conversation SaveConversation(Conversation conversation)
        {
            conversation.ID = Guid.NewGuid();
            _context.Conversations.Add(conversation);
            return conversation;

        }


        private void LoadData()
        {
            try
            {
                var c = new FileIO<List<Company>, Company>(_path);
                _context.Companies = c.GetData(_context.Companies);
            }
            catch
            {
            }


            try
            {
                var cv = new FileIO<List<Conversation>, Conversation>(_path);
                _context.Conversations = cv.GetData(_context.Conversations);
            }
            catch
            {
            }

        }



    }

}