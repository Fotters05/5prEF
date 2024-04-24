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

    public partial class SushiPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public SushiPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.Sushi.ToList();

        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустоту полей
            if (string.IsNullOrWhiteSpace(nameSUSHI.Text) || string.IsNullOrWhiteSpace(Price.Text) || string.IsNullOrWhiteSpace(Disc.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            string names = nameSUSHI.Text;
            string priceText = Price.Text;
            string des = Disc.Text;

            // Проверка ввода только русских букв и буквы "ё" для названия суши
            if (!Regex.IsMatch(names, @"^[а-яА-ЯёЁ\s]+$"))
            {
                MessageBox.Show("Поле 'Название суши' должно содержать только русские буквы!");
                return;
            }

            // Проверка ввода только цифр для цены
            if (!Regex.IsMatch(priceText, @"^\d+$"))
            {
                MessageBox.Show("Поле 'Цена' должно содержать только цифры!");
                return;
            }

            int price;
            if (!int.TryParse(priceText, out price))
            {
                MessageBox.Show("Введенное значение превышает максимально допустимое для цены!");
                return;
            }

            // Проверка на допустимое значение цены
            if (price <= 0 || price > 2000)
            {
                MessageBox.Show("Цена за один ролл должна быть больше 0 и не превышать 2000!");
                return;
            }

            // Проверка ввода только русских букв, запятых, точек и восклицательных знаков для описания
            if (!Regex.IsMatch(des, @"^[а-яА-ЯёЁ\s,.!]+$"))
            {
                MessageBox.Show("Поле 'Описание' должно содержать только русские буквы, запятые, точки и восклицательные знаки!");
                return;
            }

            Sushi a = new Sushi();
            a.SushiName = names;
            a.PriceForOneRoll = price;
            a.Descriptions = des;
            con.Sushi.Add(a);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.Sushi.ToList();
        }



        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.Sushi.Remove(SushiBarHarmony.SelectedItem as Sushi);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Sushi.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                // Проверка на пустоту полей
                if (string.IsNullOrWhiteSpace(nameSUSHI.Text) || string.IsNullOrWhiteSpace(Price.Text) || string.IsNullOrWhiteSpace(Disc.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                    return;
                }

                string names = nameSUSHI.Text;
                string priceText = Price.Text;
                string des = Disc.Text;

                // Проверка ввода только русских букв и буквы "ё" для названия суши
                if (!Regex.IsMatch(names, @"^[а-яА-ЯёЁ\s]+$"))
                {
                    MessageBox.Show("Поле 'Название суши' должно содержать только русские буквы!");
                    return;
                }

                // Проверка ввода только цифр для цены
                if (!Regex.IsMatch(priceText, @"^\d+$"))
                {
                    MessageBox.Show("Поле 'Цена' должно содержать только цифры!");
                    return;
                }

                int price;
                if (!int.TryParse(priceText, out price))
                {
                    MessageBox.Show("Введенное значение превышает максимальное допустимое для цены!");
                    return;
                }

                // Проверка на допустимое значение цены
                if (price <= 0 || price > 2000)
                {
                    MessageBox.Show("Цена за один ролл должна быть больше 0 и не превышать 2000!");
                    return;
                }

                // Проверка ввода только русских букв, запятых, точек и восклицательных знаков для описания
                if (!Regex.IsMatch(des, @"^[а-яА-ЯёЁ\s,.!]+$"))
                {
                    MessageBox.Show("Поле 'Описание' должно содержать только русские буквы, запятые, точки и восклицательные знаки!");
                    return;
                }

                Sushi selected = SushiBarHarmony.SelectedItem as Sushi;
                selected.SushiName = names;
                selected.PriceForOneRoll = price;
                selected.Descriptions = des;
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Sushi.ToList();
        }




        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Sushi selectedStorage = SushiBarHarmony.SelectedItem as Sushi;
                nameSUSHI.Text = selectedStorage.SushiName;
                Price.Text = selectedStorage.PriceForOneRoll.ToString();
                Disc.Text = selectedStorage.Descriptions;
            }
        }
    }
}
