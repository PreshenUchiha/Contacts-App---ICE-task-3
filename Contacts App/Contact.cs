using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_App
{
    class Contact
    {
        private string name;
        private string surname;
        private string email;
        private string cellphone;

        public Contact()
        {

        }
        public Contact(string name, string surname, string email, string cellphone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Cellphone = cellphone;
            Name = name;
            Surname = surname;
            Email = email;
            Cellphone = cellphone;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public string Cellphone { get => cellphone; set => cellphone = value; }
    }
}
