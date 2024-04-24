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

    public partial class IngredientsPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public IngredientsPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.QuantityIngredients.ToList();
            Sushi.ItemsSource = con.Sushi.ToList();
            Ingr.ItemsSource = con.StorageIngredients.ToList();
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
            if (string.IsNullOrWhiteSpace(Quant.Text) || Sushi.SelectedItem == null || Ingr.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            // Проверка ввода только цифр для количества
            if (!Regex.IsMatch(Quant.Text, @"^\d+$"))
            {
                MessageBox.Show("Поле 'Количество' должно содержать только цифры!");
                return;
            }

            long Quantity;
            if (!long.TryParse(Quant.Text, out Quantity))
            {
                MessageBox.Show("Введенное количество слишком большое!");
                return;
            }

            // Проверка на недопустимое значение 0
            if (Quantity == 0)
            {
                MessageBox.Show("Количество не может быть равным нулю!");
                return;
            }

            // Проверка на слишком большое количество
            if (Quantity > int.MaxValue)
            {
                MessageBox.Show("Слишком большое количество! Максимальное значение - " + int.MaxValue + ".");
                return;
            }

            int QuantityInt = (int)Quantity;

            string Sushiname = (Sushi.SelectedItem as Sushi)?.SushiName;
            int Sushi_ID = (Sushi.SelectedItem as Sushi)?.ID_Sushi ?? 0;
            string Ingrename = (Ingr.SelectedItem as StorageIngredients)?.IngredientName;
            int Ingredient_ID = (Ingr.SelectedItem as StorageIngredients)?.ID_Ingredient ?? 0;

            QuantityIngredients a = new QuantityIngredients();
            a.Quantity = QuantityInt;
            a.Sushi_ID = Sushi_ID;
            a.Ingredient_ID = Ingredient_ID;
            con.QuantityIngredients.Add(a);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.QuantityIngredients.ToList();
        }




        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.QuantityIngredients.Remove(SushiBarHarmony.SelectedItem as QuantityIngredients);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.QuantityIngredients.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                // Проверка на пустоту полей
                if (string.IsNullOrWhiteSpace(Quant.Text) || Sushi.SelectedItem == null || Ingr.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                    return;
                }

                // Проверка ввода только цифр для количества
                if (!Regex.IsMatch(Quant.Text, @"^\d+$"))
                {
                    MessageBox.Show("Поле 'Количество' должно содержать только цифры!");
                    return;
                }

                long quantity;
                if (!long.TryParse(Quant.Text, out quantity))
                {
                    MessageBox.Show("Введенное количество слишком большое!");
                    return;
                }

                // Проверка на недопустимое значение 0
                if (quantity == 0)
                {
                    MessageBox.Show("Количество не может быть равным нулю!");
                    return;
                }

                // Проверка на слишком большое количество
                if (quantity > int.MaxValue)
                {
                    MessageBox.Show("Слишком большое количество! Максимальное значение - " + int.MaxValue + ".");
                    return;
                }

                int quantityInt = (int)quantity;

                // Проверка на превышение максимального количества ингредиентов
                int totalIngredientsCount = con.QuantityIngredients.Count();
                if (totalIngredientsCount + quantityInt > 20)
                {
                    MessageBox.Show("Превышено максимальное количество ингредиентов!");
                    return;
                }

                QuantityIngredients selected = SushiBarHarmony.SelectedItem as QuantityIngredients;
                selected.Quantity = quantityInt;

                string sushiName = (Sushi.SelectedItem as Sushi)?.SushiName;
                string ingredientName = (Ingr.SelectedItem as StorageIngredients)?.IngredientName;

                var sus = con.Sushi.FirstOrDefault(r => r.SushiName == sushiName);
                var sto = con.StorageIngredients.FirstOrDefault(r => r.IngredientName == ingredientName);

                if (sus != null)
                    selected.Sushi_ID = sus.ID_Sushi;
                if (sto != null)
                    selected.Ingredient_ID = sto.ID_Ingredient;
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.QuantityIngredients.ToList();
        }





        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                QuantityIngredients selectedIngredient = SushiBarHarmony.SelectedItem as QuantityIngredients;

                Quant.Text = selectedIngredient.Quantity.ToString();

                int Sushi_ID = selectedIngredient.Sushi_ID.GetValueOrDefault();
                int Ingredient_ID = selectedIngredient.Ingredient_ID.GetValueOrDefault();

                Sushi.SelectedItem = con.Sushi.FirstOrDefault(s => s.ID_Sushi == Sushi_ID);
                Ingr.SelectedItem = con.StorageIngredients.FirstOrDefault(s => s.ID_Ingredient == Ingredient_ID);
            }
        }

    }
}
