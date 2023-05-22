// автор: Самаев Антон ИВТ-21

using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

// controller
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
            if (TextBox_name.Text == "")
            {
                label_name_error.Content = "Fill field";
                
                return;
            }

            if (TextBox_surname.Text == "")
            {
                label_surname_error.Content = "Fill field";
                return;
            }

            if (TextBox_phone.Text == "")
            {
                label_phone_error.Content = "Fill field";
                return;
            }

            if (TextBox_email.Text == "")
            {
                label_email_error.Content = "Fill field";
                return;
            }

            if (Regex.IsMatch(TextBox_name.Text, @"[0-9]"))
            {
                label_name_error.Content = "Numbers in name";
                return;
            }

            if (Regex.IsMatch(TextBox_surname.Text, @"[0-9]"))
            {
                label_surname_error.Content = "Numbers in surname";
                return;
            }

            if (Regex.IsMatch(TextBox_phone.Text, @"[a-zA-Z]") || Regex.IsMatch(TextBox_phone.Text, @"[а-яА-Я]"))
            {
                label_phone_error.Content = "Letters in phone number";
                return;
            }

            data.add_data(TextBox_name.Text, TextBox_surname.Text, TextBox_phone.Text, TextBox_email.Text);
            label_phone_error.Content = "";
        }

        // изменение полей ввода при выделении строчек
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // удаление выделенной строки
        private void Button_del_row_Click(object sender, RoutedEventArgs e)
        {
            // в index записывается номер выделенной строки
            if (datagrid.SelectedIndex <= datagrid.Items.Count && datagrid.SelectedIndex >= 0)
            {
                data.del_row(datagrid.SelectedIndex, datagrid.Items.Count);
            }
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

        private void MenuItem_SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Comma-separated values file|*.csv*";

            if (sfd.ShowDialog() == true)
            {
                data.write_csv(datagrid.Items.Count, sfd.FileName);
            }
        }

        private void MenuItem_ReadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == true)
            {
                if (File.Exists(ofd.FileName)) 
                { 
                    data.read_csv(ofd.FileName);
                }
            }
        }
    }
}
