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
        public IDictionary<Guid, Company> Companies
        { get
            { return _context.Companies; }
        }

        //make the underlying  available for searches
        public IDictionary<Guid, Conversation> Conversations
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
            return _context.Companies[id];
        }

        public Company GetCompany(string name)
        {
            var x = _context.Companies.Where(x => x.Value.CompanyName.ToLower() == name.ToLower()).FirstOrDefault();
            return x.Value;
        }

        public void DeleteCompany(Guid id)
        {
            _context.Companies[id].Enabled = false;
            SaveCompanyFile();
        }

        public async Task<Company> SaveCompanyAsync(Company company)
        {
            company.ID = Guid.NewGuid();
            _context.Companies.Add(company.ID, company);

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

                _context.Companies[company.ID] = company;
                

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
        /// <param name="id"></param>
        /// <returns></returns>
        public Conversation GetConversation(Guid id)
        {
            return _context.Conversations[id];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversation"></param>
        /// <returns></returns>
        public async Task<Conversation> SaveConversationAsync(Conversation conversation)
        {
            conversation.ID = Guid.NewGuid();
            _context.Conversations.Add(conversation.ID, conversation);

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
                var c = new FileIO<Dictionary<Guid, Company>, Company>(_path);
                result = c.SaveData(_context.Companies);
            }
            catch(Exception ex)
            {
                throw ex;
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
                var c = new FileIO<Dictionary<Guid, Conversation>, Conversation>(_path);
                result = c.SaveData(_context.Conversations);
            }
            catch(Exception ex)
            {
                throw ex;
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
                var c = new FileIO<Dictionary<Guid, Company>, Company>(_path);
                _context.Companies = c.GetData(_context.Companies);
            }
            catch
            {
            }


            try
            {
                var cv = new FileIO<Dictionary<Guid, Conversation>, Conversation>(_path);
                _context.Conversations = cv.GetData(_context.Conversations);
            }
            catch
            {
            }

        }



    }

}