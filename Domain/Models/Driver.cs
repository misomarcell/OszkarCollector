using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Driver
    {
        public string Username { get; set; }
        public Uri UserPage { get; set; }

        public Driver() { }

        public Driver(string userName, Uri userPage)
        {
            Username = userName;
            UserPage = userPage;
        }
    }
}
