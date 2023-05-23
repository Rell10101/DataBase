// автор: Самаев Антон ИВТ-21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListDB
{

    // класс контакт
    public class Contact
    {
        private String name; // имя
        private String surname; // фамилия
        private String phone; // телефон
        private String email; // почта

        public Contact()
        {
            name = "";
            surname = "";
            phone = "";
            email = "";
        }

        // конструктор    
        public Contact(string name1, string surname1, string phone1, string email1)
        {
            name = name1;
            surname = surname1;
            phone = phone1;
            email = email1;
        }

        public void name_set(string name1)
        {
            name = name1;
        }

        public string name_get() 
        {
            return name;
        }

        public void surname_set(string surname1)
        {
            surname = surname1;
        }
        
        public string surname_get() 
        {
            return surname;
        }

        public void phone_set(string phone1)
        {
            phone = phone1;
        }

        public string phone_get()
        {
            return phone;
        }

        public void email_set(string email1)
        {
            email = email1;
        }

        public string email_get()
        {
            return email;
        }
                        

        public string Name { get => name; set => name = value; }
        
        public string Surname { get => surname; set => surname = value; }

        public string Phone { get => phone; set => phone = value; }

        public string Email { get => email; set => email = value; }


    }
}
