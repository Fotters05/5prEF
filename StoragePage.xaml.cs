using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

    public partial class StoragePage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public StoragePage()
        {
            InitializeComponent();
            SupplierID.ItemsSource = con.Suppliers.Select(r => r.CompanyName).ToList();
            SushiBarHarmony.ItemsSource = con.StorageIngredients.ToList();
            SupplierID.DisplayMemberPath = "CompanyName";
            SupplierID.ItemsSource = con.Suppliers.ToList();
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngrName.Text) || string.IsNullOrWhiteSpace(Price.Text) || string.IsNullOrWhiteSpace(SupplierID.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            string Ingredients = IngrName.Text;
            string priceText = Price.Text;

            // Проверка на ввод только русских букв, включая "ё"
            if (!Regex.IsMatch(Ingredients, @"^[а-яА-ЯёЁ\s]+$"))
            {
                MessageBox.Show("Поле 'Название ингредиента' должно содержать только русские буквы, включая 'ё'!");
                return;
            }

            // Проверка на ввод положительного числа
            if (!IsValidPositiveInt(priceText))
            {
                MessageBox.Show("Поле 'Цена' должно содержать только положительные цифры!");
                return;
            }

            // Проверка на допустимое значение для типа int
            if (!IsValidInt(priceText))
            {
                MessageBox.Show("Введенное значение для цены за 50 грамм превышает максимально допустимое!");
                return;
            }

            int PriceFor50Gram = int.Parse(priceText);

            // Проверка на значение больше 0 и не больше 10000 для цены
            if (PriceFor50Gram == 0)
            {
                MessageBox.Show("Цена за 50 грамм не может быть равной нулю!");
                return;
            }

            if (PriceFor50Gram > 10000)
            {
                MessageBox.Show("Цена за 50 грамм не может превышать 10000!");
                return;
            }

            string companyName = SupplierID.Text;

            if (string.IsNullOrWhiteSpace(companyName))
            {
                MessageBox.Show("Пожалуйста, выберите поставщика!");
                return;
            }

            int Supplier_ID = con.Suppliers.FirstOrDefault(s => s.CompanyName == companyName)?.ID_Supplier ?? 0;

            StorageIngredients a = new StorageIngredients();
            a.IngredientName = Ingredients;
            a.PriceFor50Gram = PriceFor50Gram;
            a.Supplier_ID = Supplier_ID;
            con.StorageIngredients.Add(a);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.StorageIngredients.ToList();
        }

        // Функция для проверки, что введенное значение положительное целое число
        private bool IsValidPositiveInt(string input)
        {
            int result;
            if (!int.TryParse(input, out result))
                return false;

            return result > 0;
        }

        // Функция для проверки, что введенное значение может быть представлено типом int
        private bool IsValidInt(string input)
        {
            long result;
            if (!long.TryParse(input, out result))
                return false;

            return result <= int.MaxValue;
        }





        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.StorageIngredients.Remove(SushiBarHarmony.SelectedItem as StorageIngredients);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.StorageIngredients.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                StorageIngredients selected = SushiBarHarmony.SelectedItem as StorageIngredients;

                if (string.IsNullOrWhiteSpace(IngrName.Text) || string.IsNullOrWhiteSpace(Price.Text) || SupplierID.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                    return;
                }

                string Ingredients = IngrName.Text;
                string priceText = Price.Text;

                // Проверка на ввод только русских букв, включая "ё"
                if (!Regex.IsMatch(Ingredients, @"^[а-яА-ЯёЁ\s]+$"))
                {
                    MessageBox.Show("Поле 'Название ингредиента' должно содержать только русские буквы, включая 'ё'!");
                    return;
                }

                // Проверка, что введенное значение может быть представлено типом int
                if (!IsValidPrice(priceText))
                {
                    MessageBox.Show("Введенное значение для цены за 50 грамм должно быть числом от 1 до 10000!");
                    return;
                }

                int PriceFor50Gram = int.Parse(priceText);

                // Проверка на нулевое значение и значение больше 10000 для цены
                if (PriceFor50Gram == 0)
                {
                    MessageBox.Show("Цена за 50 грамм не может быть равной нулю!");
                    return;
                }

                if (PriceFor50Gram > 10000)
                {
                    MessageBox.Show("Цена за 50 грамм не может превышать 10000!");
                    return;
                }

                string selectedCompanyName = SupplierID.Text;

                // Проверка на существование выбранного поставщика
                var selectedSupplier = con.Suppliers.FirstOrDefault(r => r.CompanyName == selectedCompanyName);
                if (selectedSupplier == null)
                {
                    MessageBox.Show("Выбранный поставщик не существует.");
                    return;
                }

                selected.IngredientName = Ingredients;
                selected.PriceFor50Gram = PriceFor50Gram;
                selected.Supplier_ID = selectedSupplier.ID_Supplier;
            }

            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.StorageIngredients.ToList();
        }

        // Функция для проверки, что введенное значение для цены за 50 грамм находится в диапазоне от 1 до 10000
        private bool IsValidPrice(string input)
        {
            int result;
            if (!int.TryParse(input, out result))
                return false;

            return result >= 1 && result <= 10000;
        }




        private void Inviz (object sender, RoutedEventArgs e)
        {

        }




        private void SupplierID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                StorageIngredients selectedStorage = SushiBarHarmony.SelectedItem as StorageIngredients;
                IngrName.Text = selectedStorage.IngredientName;
                Price.Text = selectedStorage.PriceFor50Gram.ToString();

                int supplierID = selectedStorage.Supplier_ID.GetValueOrDefault();



                SupplierID.SelectedItem = con.Suppliers.FirstOrDefault(s => s.ID_Supplier == supplierID);
            }
        }
    }
}
