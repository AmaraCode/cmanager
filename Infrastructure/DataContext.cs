using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Infrastructure
{
    public static class DataContext
    {
        public static Dictionary<Guid, Company> Companies { get; set; }
        public static Dictionary<Guid, Conversation> Conversations { get; set; }
        public static string Path { get; set; }  //make sure to set this early in the pipeline (startup)




        static DataContext()
        {
            Companies = new Dictionary<Guid, Company>();
            Conversations = new Dictionary<Guid, Conversation>();
        }


    }
}
