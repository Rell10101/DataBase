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
            // если поле ввода имени пустое
            if (TextBox_name.Text == "")
            {
                // вывести сообщение об ошибке
                label_name_error.Content = "Fill field";
                return;
            }

            // если поле ввода фамилии пустое
            if (TextBox_surname.Text == "")
            {
                // вывести сообщение об ошибке
                label_surname_error.Content = "Fill field";
                return;
            }

            // если поле ввода телефона пустое
            if (TextBox_phone.Text == "")
            {
                // вывести сообщение об ошибке
                label_phone_error.Content = "Fill field";
                return;
            }

            // если поле ввода почты пустое
            if (TextBox_email.Text == "")
            {
                // вывести сообщение об ошибке
                label_email_error.Content = "Fill field";
                return;
            }

            // если в имени есть цифры
            if (Regex.IsMatch(TextBox_name.Text, @"[0-9]"))
            {
                // вывести сообщение об ошибке
                label_name_error.Content = "Numbers in name";
                return;
            }

            // если в фамилии есть цифры
            if (Regex.IsMatch(TextBox_surname.Text, @"[0-9]"))
            {
                // вывести сообщение об ошибке
                label_surname_error.Content = "Numbers in surname";
                return;
            }

            // если в телефоне есть буквы
            if (Regex.IsMatch(TextBox_phone.Text, @"[a-zA-Z]") || Regex.IsMatch(TextBox_phone.Text, @"[а-яА-Я]"))
            {
                // вывести сообщение об ошибке
                label_phone_error.Content = "Letters in phone number";
                return;
            }

            // если проверка прошла, добавить данные
            data.add_data(TextBox_name.Text, TextBox_surname.Text, TextBox_phone.Text, TextBox_email.Text);
            // убрать сообщение об ошибке, если проверка прошла
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
                // удаление строчки
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

        // пункт меню SaveToFile
        // сохранить данные в csv файл
        private void MenuItem_SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            // SaveFileDialog - диалоговое окно для выбора файла для сохранения
            SaveFileDialog sfd = new SaveFileDialog();
            // выбор типа файла
            sfd.Filter = "Comma-separated values file|*.csv*";
            // ShowDialog() == true, если пользователь выбрал файл и нажал "сохранить"
            if (sfd.ShowDialog() == true)
            {
                // сохранение данных в файл
                data.write_csv(datagrid.Items.Count, sfd.FileName);
            }
        }

        // прочитать csv файл
        private void MenuItem_ReadFile_Click(object sender, RoutedEventArgs e)
        {
            // OpenFileDialog - диалоговое окно для выбора файла для открытия
            OpenFileDialog ofd = new OpenFileDialog();
            // ShowDialog() == true, если пользователь выбрал файл и нажал "открыть"
            if (ofd.ShowDialog() == true)
            {
                // если файл существует
                if (File.Exists(ofd.FileName)) 
                {
                    // прочитать файл
                    data.read_csv(ofd.FileName);
                }
            }
        }
    }
}
