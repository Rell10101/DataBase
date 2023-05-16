// автор: Самаев Антон ИВТ-21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

namespace ContactListDB
{
    public partial class MainWindow : Window
    {
        DataBase data;

        public MainWindow()
        {
            InitializeComponent();
            data = new DataBase();

            // связывание данных и табличного предствления (datagrid)
            datagrid.ItemsSource = data.data;
            // названия столбцов в datagrid определятся автоматически, 
            // на основе названий свойств элементов привезанной коллекции данных (Contact)


        }


        /// Добавляет новую строку в таблицу
        private void button_add_row_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_name.Text == "" || TextBox_surname.Text == "" || TextBox_phone.Text == "")
            {
                label_error.Content = "Fill all fields";
                return;
            }

            if (Regex.IsMatch(TextBox_name.Text, @"[0-9]"))
            {
                label_error.Content = "Numbers in name";
                return;
            }

            if (Regex.IsMatch(TextBox_surname.Text, @"[0-9]"))
            {
                label_error.Content = "Numbers in surname";
                return;
            }

            if (Regex.IsMatch(TextBox_phone.Text, @"[a-zA-Z]") || Regex.IsMatch(TextBox_phone.Text, @"[а-яА-Я]"))
            {
                label_error.Content = "Letters in phone number";
                return;
            }

            data.add_data(datagrid.Items.Count, TextBox_name.Text, TextBox_surname.Text, TextBox_phone.Text);
            label_error.Content = "";
        }

        // чтение csv файла
        private void Button_read_csv_Click(object sender, RoutedEventArgs e)
        {
            data.read_csv("DB");
        }

        // загрузка в csv файл
        private void Button_write_csv_Click(object sender, RoutedEventArgs e)
        {
            data.write_csv(datagrid.Items.Count, "DB");
        }

        // изменение полей ввода при выделении строчек
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // var index = datagrid.SelectedIndex;
            // TextBox_name.Text = data.data[index].Name;
            // TextBox_surname.Text = data.data[index].Surname;
            // TextBox_phone.Text = data.data[index].Phone;
        }

        // удаление выделенной строки
        private void Button_del_row_Click(object sender, RoutedEventArgs e)
        {
            data.del_row(datagrid.SelectedIndex, datagrid.Items.Count);
        }

        // закрытие прогаммы при нажатии на пункт меню
        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // справка
        private void MenuItem_Reference_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("База данных хранит информацию о контактах \nРазработчик: Самаев Антон ИВТ-21");
        }
    }
}
