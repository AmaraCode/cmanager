using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Models
{
    public class ConversationEditViewModel
    {


        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Discussion { get; set; }
        public bool CallBack { get; set; } = false;
        public Guid CompanyID { get; set; }
        public DateTime Created { get; set; }
        public string CompanyName { get; set; }
        public string ReturnURL { get; set; }
        
    }
}
