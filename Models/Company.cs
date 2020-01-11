using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmaraCode.CManager.Models
{
    public class Company
    {
        public Guid ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public bool Important { get; set; } = false;
        public DateTime Created { get; set; }

        public bool Enabled = true;


        public Company()
        {
            Created = DateTime.Now;
        }
    }


}