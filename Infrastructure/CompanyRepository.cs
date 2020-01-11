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

        public async Task<Company> SaveCompanyAsync(Company company)
        {
            company.ID = Guid.NewGuid();
            _context.Companies.Add(company);

            var x = await SaveCompanyFile();

            return company;
        }

        public Conversation GetConversation(Guid id)
        {
            return _context.Conversations.Where(x => x.ID == id).FirstOrDefault();
        }

        public async Task<Conversation> SaveConversationAsync(Conversation conversation)
        {
            conversation.ID = Guid.NewGuid();
            _context.Conversations.Add(conversation);

            var x = await SaveConversationFile();

            return conversation;

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
                var c = new FileIO<List<Company>, Company>(_path);
                result = c.SaveData(_context.Companies);
            }
            catch
            {
            }

            return Task.FromResult(result); 
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Task<bool> SaveConversationFile()
        {
            bool result = false;
            try
            {
                var c = new FileIO<List<Conversation>, Conversation>(_path);
                result = c.SaveData(_context.Conversations);
            }
            catch
            {
            }

            return Task.FromResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
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