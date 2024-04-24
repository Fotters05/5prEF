using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Praktika5
{
    public partial class SupplierPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public SupplierPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.Suppliers.ToList();
        }
        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Adm adm = new Adm();
            adm.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string CompanyName = nam.Text;
            string Phone = ph.Text;
            string Address = adr.Text;

            // Проверка ввода только русских букв для названия компании
            if (!Regex.IsMatch(CompanyName, @"^[а-яА-Я\s]+$"))
            {
                MessageBox.Show("Поле 'Название компании' должно содержать только русские буквы!");
                return;
            }

            // Проверка валидности номера телефона
            if (!Regex.IsMatch(Phone, @"^\d{11}$"))
            {
                MessageBox.Show("Номер телефона должен состоять из 11 цифр!");
                return;
            }

            int maxIntValue = int.MaxValue.ToString().Length;

            // Проверка, что количество цифр в номере телефона не превышает максимальное значение int
            if (Phone.Length > maxIntValue)
            {
                MessageBox.Show($"Количество цифр в номере телефона не должно превышать {maxIntValue}!");
                return;
            }

            // Проверка ввода русских букв, точки и цифр для адреса
            if (!Regex.IsMatch(Address, @"^[а-яА-Я\s\d.]+$"))
            {
                MessageBox.Show("Поле 'Адрес' должно содержать только русские буквы, точку и цифры!");
                return;
            }

            Suppliers z = new Suppliers();
            z.CompanyName = CompanyName;
            z.Phone = Phone;
            z.Address_Suppliers = Address;
            con.Suppliers.Add(z);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.Suppliers.ToList();
        }



        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.Suppliers.Remove(SushiBarHarmony.SelectedItem as Suppliers);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Suppliers.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Suppliers selected = SushiBarHarmony.SelectedItem as Suppliers;

                string CompanyName = nam.Text;
                string Phone = ph.Text;
                string Address = adr.Text;

                // Проверка ввода только русских букв для названия компании
                if (!Regex.IsMatch(CompanyName, @"^[а-яА-Я\s]+$"))
                {
                    MessageBox.Show("Поле 'Название компании' должно содержать только русские буквы!");
                    return;
                }

                // Проверка валидности номера телефона
                if (!Regex.IsMatch(Phone, @"^\d{11}$"))
                {
                    MessageBox.Show("Номер телефона должен состоять из 11 цифр!");
                    return;
                }

                int maxIntValue = int.MaxValue.ToString().Length;

                // Проверка, что количество цифр в номере телефона не превышает максимальное значение int
                if (Phone.Length > maxIntValue)
                {
                    MessageBox.Show($"Количество цифр в номере телефона не должно превышать {maxIntValue}!");
                    return;
                }

                // Проверка ввода русских букв, точки и цифр для адреса
                if (!Regex.IsMatch(Address, @"^[а-яА-Я\s\d.]+$"))
                {
                    MessageBox.Show("Поле 'Адрес' должно содержать только русские буквы, точку и цифры!");
                    return;
                }

                selected.CompanyName = CompanyName;
                selected.Phone = Phone;
                selected.Address_Suppliers = Address;
            }

            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Suppliers.ToList();
        }




        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Suppliers selectedset = SushiBarHarmony.SelectedItem as Suppliers;
                nam.Text = selectedset.CompanyName;
                ph.Text = selectedset.Phone;
                adr.Text = selectedset.Address_Suppliers;
            }
        }
    }
}
