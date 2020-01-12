using AmaraCode.CManager.Infrastructure;
using AmaraCode.CManager.Models;
using System.Linq;

namespace AmaraCode.CManager.AppService
{

    /// <summary>
    /// 
    /// </summary>
    public class HomeAppService
    {
        private CompanyAppService _companyAppService;
        private ConversationAppService _conversationAppService;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyAppService"></param>
        /// <param name="conversationAppService"></param>
        public HomeAppService(CompanyAppService companyAppService, ConversationAppService conversationAppService)
        {
            _companyAppService = companyAppService;
            _conversationAppService = conversationAppService;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HomeIndexViewModel HomeIndex()
        {
            //get last 10 conversations
            var conversations10 = (from c in DataContext.Companies.Values
                          join cv in DataContext.Conversations.Values
                             on c.ID equals cv.CompanyID
                          orderby cv.Created
                          select (new ConversationCompanyViewModel
                          {
                              Company = c,
                              Conversation = cv
                          })).Take(10);


            //get callback conversations
            var conversationsWaitingCallBack = from c in DataContext.Companies.Values
                                                join cv in DataContext.Conversations.Values
                                                   on c.ID equals cv.CompanyID
                                               where cv.CallBack == true
                                                orderby cv.Created
                                                select (new ConversationCompanyViewModel
                                                {
                                                    Company = c,
                                                    Conversation = cv
                                                });


            //create the viewmodel to return from this method
            var model = new HomeIndexViewModel
            {
                CompanyCount = DataContext.Companies.Count,
                ConversationCount = DataContext.Conversations.Count,
                LatestConversations = conversations10,
                WaitingCallBack = conversationsWaitingCallBack
            };

            return model;
        }


    }
}
