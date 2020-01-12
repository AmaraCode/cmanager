using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Infrastructure
{
    public interface IConversationRepository
    {
        IDictionary<Guid, Conversation> Conversations { get; }
        Conversation GetConversation(Guid conversationID);
        Task<Conversation> SaveConversationAsync(Conversation conversation);
        Task<Conversation> EditConversationAsync(Conversation conversation);
        void DeleteConversation(Guid conversationID);

        IEnumerable<Conversation> GetConversations(Guid? companyID);
        IEnumerable<Conversation> GetConversations();


    }
}
