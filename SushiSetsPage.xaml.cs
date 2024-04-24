using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public partial class SushiSetsPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public SushiSetsPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.SushiSets.ToList();
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустоту поля nameset
            if (string.IsNullOrWhiteSpace(nameset.Text))
            {
                MessageBox.Show("Пожалуйста, введите название комплекта суши!");
                return;
            }

            // Проверка на пустоту поля priceset
            if (string.IsNullOrWhiteSpace(Priceset.Text))
            {
                MessageBox.Show("Пожалуйста, введите цену комплекта суши!");
                return;
            }

            string names = nameset.Text;
            string priceText = Priceset.Text;

            // Проверка ввода только русских букв и буквы "ё" для названия комплекта суши
            if (!Regex.IsMatch(names, @"^[а-яА-ЯёЁ\s]+$"))
            {
                MessageBox.Show("Поле 'Название комплекта суши' должно содержать только русские буквы и букву 'ё'!");
                return;
            }

            // Проверка ввода только цифр для цены комплекта суши
            if (!Regex.IsMatch(priceText, @"^\d+$"))
            {
                MessageBox.Show("Поле 'Цена комплекта суши' должно содержать только цифры!");
                return;
            }

            int price;
            if (!int.TryParse(priceText, out price))
            {
                MessageBox.Show("Введенное значение слишком большое!");
                return;
            }

            // Проверка на допустимое значение цены комплекта суши
            if (price <= 0 || price >= 100000)
            {
                MessageBox.Show("Цена комплекта суши должна быть больше нуля и не превышать 100 000!");
                return;
            }

            SushiSets a = new SushiSets();
            a.SushiSetName = names;
            a.SushiSetPrice = price;
            con.SushiSets.Add(a);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.SushiSets.ToList();
        }



        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.SushiSets.Remove(SushiBarHarmony.SelectedItem as SushiSets);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.SushiSets.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                // Проверка на пустоту поля nameset
                if (string.IsNullOrWhiteSpace(nameset.Text))
                {
                    MessageBox.Show("Пожалуйста, введите название комплекта суши!");
                    return;
                }

                // Проверка на пустоту поля Priceset
                if (string.IsNullOrWhiteSpace(Priceset.Text))
                {
                    MessageBox.Show("Пожалуйста, введите цену комплекта суши!");
                    return;
                }

                SushiSets selected = SushiBarHarmony.SelectedItem as SushiSets;
                selected.SushiSetName = nameset.Text;

                string priceText = Priceset.Text;

                // Проверка ввода только цифр и точки для цены комплекта суши
                if (!Regex.IsMatch(priceText, @"^[\d.]+$"))
                {
                    MessageBox.Show("Поле 'Цена комплекта суши' должно содержать только цифры и точку!");
                    return;
                }

                // Преобразование строки в число типа decimal
                decimal price;
                if (!decimal.TryParse(priceText, out price))
                {
                    MessageBox.Show("Введенное значение слишком большое!");
                    return;
                }

                // Проверка на допустимое значение цены комплекта суши
                if (price <= 0 || price >= 100000)
                {
                    MessageBox.Show("Цена комплекта суши должна быть больше нуля и не превышать 100000!");
                    return;
                }

                // Проверка на максимальное значение типа int
                if (price > int.MaxValue)
                {
                    MessageBox.Show("Введенное значение слишком большое!");
                    return;
                }

                selected.SushiSetPrice = price;
            }

            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.SushiSets.ToList();
        }



        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                SushiSets selectedset = SushiBarHarmony.SelectedItem as SushiSets;
                nameset.Text = selectedset.SushiSetName;
                Priceset.Text = selectedset.SushiSetPrice.ToString();
            }
        }
    }
}
