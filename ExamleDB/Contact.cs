// автор: Самаев Антон ИВТ-21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListDB
{

    // Контакт
    class Contact
    {
        public int id;
        private String name;
        private String surname;
        private String phone;

        // конструктор    
        public Contact(int id1, string name1, string surname1, string phone1)
        {
            id = id1;
            name = name1;
            surname = surname1;
            phone = phone1;
        }

        public int Id { get => id; set => id = value; }

        public string Name { get => name; set => name = value; }
        
        public string Surname { get => surname; set => surname = value; }

        public string Phone { get => phone; set => phone = value; }


    }
}
