using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.Models
{
    public class CompanyCreateViewModel
    {

        public Guid ID { get; set; }
        
        [Required]
        public string CompanyName { get; set; }

        public string Address { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public bool Important { get; set; }
        public bool Enabled { get; set; }
        public bool OutOfBusiness { get; set; }
        public string Notes { get; set; }
        public string ReturnUrl { get; set; }


    }
}
