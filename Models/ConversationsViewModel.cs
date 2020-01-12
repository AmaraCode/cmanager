using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Models
{
    public class ConversationsViewModel
    {
        public Company Company { get; set; }
        public IEnumerable<Conversation> Conversations { get; set; }
    }
}
