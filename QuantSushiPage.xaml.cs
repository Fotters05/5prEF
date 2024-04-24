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
    
    public partial class QuantSushiPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public QuantSushiPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.SushiQuant.ToList();
            Sushi.ItemsSource = con.Sushi.ToList();
            Ingr.ItemsSource = con.SushiSets.ToList();
            Ingr.DisplayMemberPath = "SushiSetName";
            Ingr.SelectedValuePath = "ID_SushiSets";
        }


        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
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

            int Quantity;
            if (!int.TryParse(Quant.Text, out Quantity))
            {
                MessageBox.Show("Введенное значение превышает максимально допустимое для количества!");
                return;
            }

            // Проверка на допустимое значение количества
            if (Quantity <= 0 || Quantity > 150)
            {
                MessageBox.Show("Количество должно быть больше нуля и не превышать 150!");
                return;
            }

            string Sushiname = (Sushi.SelectedItem as Sushi)?.SushiName;
            int Sushi_ID = (Sushi.SelectedItem as Sushi)?.ID_Sushi ?? 0;
            string ss = (Ingr.SelectedItem as SushiSets)?.SushiSetName;
            int SushiSets_ID = (Ingr.SelectedItem as SushiSets)?.ID_SushiSets ?? 0;

            SushiQuant a = new SushiQuant();
            a.Quantity = Quantity;
            a.Sushi_ID = Sushi_ID;
            a.SushiSets_ID = SushiSets_ID;
            con.SushiQuant.Add(a);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.SushiQuant.ToList();
        }




        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.SushiQuant.Remove(SushiBarHarmony.SelectedItem as SushiQuant);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.SushiQuant.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите элемент для обновления!");
                return;
            }

            if (string.IsNullOrWhiteSpace(Quant.Text))
            {
                MessageBox.Show("Пожалуйста, введите количество!");
                return;
            }

            // Проверка ввода только цифр для количества
            if (!Regex.IsMatch(Quant.Text, @"^\d+$"))
            {
                MessageBox.Show("Поле 'Количество' должно содержать только цифры!");
                return;
            }

            int quantity;
            if (!int.TryParse(Quant.Text, out quantity))
            {
                MessageBox.Show("Введенное количество слишком большое!");
                return;
            }

            // Проверка на недопустимое значение количества
            if (quantity <= 0 || quantity > 150)
            {
                MessageBox.Show("Количество должно быть больше нуля и не превышать 150!");
                return;
            }

            string sushiName = (Sushi.SelectedItem as Sushi)?.SushiName;
            if (string.IsNullOrWhiteSpace(sushiName))
            {
                MessageBox.Show("Пожалуйста, выберите суши!");
                return;
            }

            string ingredientName = (Ingr.SelectedItem as SushiSets)?.SushiSetName;
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                MessageBox.Show("Пожалуйста, выберите комплект суши!");
                return;
            }

            var sus = con.Sushi.FirstOrDefault(r => r.SushiName == sushiName);
            var sto = con.SushiSets.FirstOrDefault(r => r.SushiSetName == ingredientName);

            if (SushiBarHarmony.SelectedItem != null)
            {
                SushiQuant selected = SushiBarHarmony.SelectedItem as SushiQuant;
                selected.Quantity = quantity;

                if (sus != null)
                    selected.Sushi_ID = sus.ID_Sushi;
                if (sto != null)
                    selected.SushiSets_ID = sto.ID_SushiSets;
            }

            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.SushiQuant.ToList();
        }




        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                SushiQuant selectedIngredient = SushiBarHarmony.SelectedItem as SushiQuant;

                Quant.Text = selectedIngredient.Quantity.ToString();

                int Sushi_ID = selectedIngredient.Sushi_ID.GetValueOrDefault();
                int SushiSets_ID = selectedIngredient.SushiSets_ID.GetValueOrDefault();

                string sushiName = con.Sushi.FirstOrDefault(s => s.ID_Sushi == Sushi_ID)?.SushiName;
                string SushiSetsname = con.SushiSets.FirstOrDefault(s => s.ID_SushiSets == SushiSets_ID)?.SushiSetName;


                Sushi.SelectedItem = con.Sushi.FirstOrDefault(s => s.ID_Sushi == Sushi_ID);
                Ingr.SelectedItem = con.SushiSets.FirstOrDefault(s => s.ID_SushiSets == SushiSets_ID);
            }
        }
    }
}
