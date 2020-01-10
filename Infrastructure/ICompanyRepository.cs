using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;

namespace AmaraCode.CManager.Infrastructure
{
    public interface ICompanyRepository
    {
        IList<Company> Companies { get; }
        IList<Conversation> Conversations { get; }
        Company GetCompany(Guid id);
        Company GetCompany(string name);
        Conversation GetConversation(Guid id);
        Company SaveCompany(Company company);
        Conversation SaveConversation(Conversation conversation);
    }
}