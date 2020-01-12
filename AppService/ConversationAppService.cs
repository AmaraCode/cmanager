using AmaraCode.CManager.Infrastructure;
using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.AppService
{
    /// <summary>
    /// 
    /// </summary>
    public class ConversationAppService
    {

        private IConversationRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public ConversationAppService(IConversationRepository repo)
        {
            _repo = repo;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversationID"></param>
        public void Delete(Guid conversationID)
        {
            _repo.DeleteConversation(conversationID);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="companidID"></param>
        /// <returns></returns>
        public ConversationsViewModel GetConversations(Guid? companidID)
        {
            if(companidID != null)
            {
                var conversations = _repo.GetConversations((Guid)companidID);
                var cvm = new ConversationsViewModel
                {
                    Company = DataContext.Companies.Values.Where(x => x.ID == companidID).FirstOrDefault(),
                    Conversations = conversations
                };

                return cvm;
            }
            else
            {
                var conversations =  _repo.GetConversations();
                var cvm = new ConversationsViewModel
                {
                    Company = null,
                    Conversations = conversations
                };

                return cvm;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversationID"></param>
        /// <returns></returns>
        public ConversationCompanyViewModel GetConversation(Guid conversationID)
        {
            if (conversationID != null)
            {
                var model = new ConversationCompanyViewModel();
                
                var conversation = _repo.GetConversation(conversationID);
                model.Conversation = conversation;

                if (conversation != null)
                {
                    
                    model.Company = DataContext.Companies.Values.Where(x => x.ID == conversation.CompanyID).FirstOrDefault();
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ConversationEditViewModel EditConversation(ConversationEditViewModel model)
        {
            var result = new Conversation
            {
                CallBack = model.CallBack,
                CompanyID = model.CompanyID,
                Created = model.Created,
                Phone = model.Phone,
                Name = model.Name,
                ID = model.ID,
                Email = model.Email,
                Discussion = model.Discussion
            };

            var response = _repo.EditConversationAsync(result).Result;
            return model;
        }


    }
}
