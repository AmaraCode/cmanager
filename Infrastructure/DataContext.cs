using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Infrastructure
{
    public class DataContext
    {
        public List<Company> Companies { get; set; }
        public List<Conversation> Conversations { get; set; }


        public DataContext()
        {
            Companies = new List<Company>();
            Conversations = new List<Conversation>();
        }


    }
}
