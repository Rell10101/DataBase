// автор: Самаев Антон ИВТ-21

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;// для ObservableCollection
// ObservableCollection -- коллекция, которую можно использовать совместно с DataGrid
// Эта коллекция можеть оповещать о своём изменении DataGrid
// DataGrid, в свою очередь, автоматически поддерживает сортировки и т.п.
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.FileIO;
using System.IO;



namespace ContactListDB
{
    // todo: не проводить тут проверку данных!!!
    // класс для хранения и обработки данных
    class DataBase
    {
        public ObservableCollection<Contact> data;

        public DataBase()
        {
            data = new ObservableCollection<Contact>();
        }


        // Добавление случайной записи в таблицу
        public void add_random_data()
        {
            Random rnd = new Random();
            List<String> names = new List<string> { "Антон", "Андрей", "Денис", "Дима" };
            List<String> surnames = new List<string> { "Самаев", "Петров", "Шишкин", "Булков" };

            //data.Add(new Customer(++Customer.id, names[rnd.Next(names.Count)], surnames[rnd.Next(names.Count)], rnd.Next()));
        }

        // метод для добавления данных
        public void add_data( string name, string surname, string phone, string email)
        {
            data.Add(new Contact(name, surname, phone, email));
        }

        // метод для чтения csv файла
        public void read_csv(string filename)
        {
            string path = filename + @".csv";

            if (File.Exists(path))
            { 
                using (TextFieldParser tfp = new TextFieldParser( filename + @".csv"))
            {
                tfp.TextFieldType = FieldType.Delimited;
                // обозначим знак разделения
                tfp.SetDelimiters(",");

                while (!tfp.EndOfData)
                {
                    // делим первую строчку на поля, которые разделяюся запятой
                    string[] fields = tfp.ReadFields();
                    data.Add(new Contact(fields[0], fields[1], fields[2], fields[3]));
                }
            }
            }
        }

        // запись в csv файл
        public void write_csv(int count, string filename)
        {
            string path = filename + @".csv";

            //if (File.Exists(path))
            //{
                int n = count;

                StringBuilder scv = new StringBuilder();
                for (int i = 0; i < n; ++i)
                {
                    scv.AppendLine(data[i].Name + "," + data[i].Surname + "," + data[i].Phone + "," + data[i].Email);
                    // Encoding нужен для правильной записи символов
                    File.WriteAllText(path, scv.ToString(),Encoding.GetEncoding(1251));
                }
                
            //}
        }

        // метод для удаления выделенной строки
        public void del_row(int SelInd, int count)
        {
            // в index записывается номер выделенной строки
            if (SelInd <= count)
            {
                data.RemoveAt(SelInd);
            }
        }
    }
}
