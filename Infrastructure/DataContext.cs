using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Infrastructure
{
    public class DataContext
    {
        public Dictionary<Guid, Company> Companies { get; set; }
        public Dictionary<Guid, Conversation> Conversations { get; set; }


        public DataContext()
        {
            Companies = new Dictionary<Guid, Company>();
            Conversations = new Dictionary<Guid, Conversation>();
        }


    }
}
