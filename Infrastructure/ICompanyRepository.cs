using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Infrastructure
{
    public interface ICompanyRepository
    {
        IDictionary<Guid, Company> Companies { get; }
        IDictionary<Guid, Conversation> Conversations { get; }
        Company GetCompany(Guid id);
        Company GetCompany(string name);
        Conversation GetConversation(Guid id);
        Task<Company> SaveCompanyAsync(Company company);
        Task<Conversation> SaveConversationAsync(Conversation conversation);
        Task<Company> EditCompanyAsync(Company company);
    }
}