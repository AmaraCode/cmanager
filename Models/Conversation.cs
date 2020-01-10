using System;
using System.Collections;
using System.Collections.Generic;

namespace AmaraCode.CManager.Models
{
    public class Conversation
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public string Discussion { get; set; }
        public bool CallBack { get; set; } = false;
        public int CompanyID { get; set; }
        public DateTime Created { get; set; }

        public Conversation()
        {
            Created = DateTime.Now;
        }
    }
}