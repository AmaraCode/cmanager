using AmaraCode.CManager.Infrastructure;
using AmaraCode.CManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaraCode.CManager.AppService
{
    public class PersonAppService
    {

        public IEnumerable<PersonIndexViewModel> GetPersons()
        {
            //first get the grouped people
            var result = from p in DataContext.Conversations.Values
                         join c in DataContext.Companies.Values
                            on p.CompanyID equals c.ID
                         group p by new { c.ID, p.Name, c.CompanyName, p.Phone, p.Email }
                         into grp
                         select new PersonIndexViewModel
                         {
                             CompanyName = grp.Key.CompanyName,
                             Email = grp.Key.Email,
                             Phone = grp.Key.Phone,
                             Name = grp.Key.Name,
                             CompanyID = grp.Key.ID
                         };

            return result;
        }

    }
}
