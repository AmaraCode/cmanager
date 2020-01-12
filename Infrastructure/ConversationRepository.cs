using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Infrastructure
{
    public class ConversationRepository : IConversationRepository
    {

        

        public ConversationRepository()
        {

        }


        //make the underlying  available for searches
        public IDictionary<Guid, Conversation> Conversations
        {
            get
            { return DataContext.Conversations; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteConversation(Guid id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversation"></param>
        /// <returns></returns>
        public async Task<Conversation> EditConversationAsync(Conversation conversation)
        {

            try
            {
                DataContext.Conversations[conversation.ID] = conversation;
                var x = await SaveConversationFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conversation;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Conversation GetConversation(Guid id)
        {
            return DataContext.Conversations[id];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversation"></param>
        /// <returns></returns>
        public async Task<Conversation> SaveConversationAsync(Conversation conversation)
        {
            conversation.ID = Guid.NewGuid();
            DataContext.Conversations.Add(conversation.ID, conversation);

            var x = await SaveConversationFile();

            return conversation;
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
                var c = new FileIO<Dictionary<Guid, Conversation>, Conversation>(DataContext.Path);
                result = c.SaveData(DataContext.Conversations);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(result);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public IEnumerable<Conversation> GetConversations(Guid? companyID)
        {
            var result = from cv in DataContext.Conversations.Values
                         where cv.CompanyID == companyID
                         select cv;
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Conversation> GetConversations()
        {
            var result = from cv in DataContext.Conversations.Values
                         select cv;
            return result;

        }
    }
}
