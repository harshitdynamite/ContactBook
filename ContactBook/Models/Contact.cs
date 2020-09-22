using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBook.Models
{
    public class Contact
    {
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public List<string> Email { get; set; }
        public List<string> PhoneNos { get; set; }
    }
}
