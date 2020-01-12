using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Models
{
    public class HomeIndexViewModel
    {
        public int CompanyCount { get; set; }
        public int ConversationCount { get; set; }
        public IEnumerable<ConversationCompanyViewModel> LatestConversations { get; set; }
        public IEnumerable<ConversationCompanyViewModel> WaitingCallBack { get; set; }

    }
}
