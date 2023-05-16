// автор: Самаев Антон ИВТ-21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListDB
{

    // класс контакт
    class Contact
    {
        private String name;
        private String surname;
        private String phone;
        private String email;

        // конструктор    
        public Contact(string name1, string surname1, string phone1, string email1)
        {
            name = name1;
            surname = surname1;
            phone = phone1;
            email = email1;
        }


        public string Name { get => name; set => name = value; }
        
        public string Surname { get => surname; set => surname = value; }

        public string Phone { get => phone; set => phone = value; }

        public string Email { get => email; set => email = value; }


    }
}
