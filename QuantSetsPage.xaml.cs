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

    public partial class QuantSetsPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public QuantSetsPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.OrderSushiSets.ToList();

            Sushis.ItemsSource = con.SushiSets.ToList();
            Sushis.DisplayMemberPath = "SushiSetName";
            Sushis.SelectedValuePath = "ID_SushiSets";

            QS.ItemsSource = con.Orders.ToList();
            QS.DisplayMemberPath = "TotalAmount";
            QS.SelectedValuePath = "ID_Order";
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на пустоту поля Quant
            if (string.IsNullOrWhiteSpace(Quant.Text))
            {
                MessageBox.Show("Пожалуйста, введите количество заказываемых комплектов суши!");
                return;
            }

            // Проверка ввода только цифр для количества заказываемых комплектов суши
            if (!Regex.IsMatch(Quant.Text, @"^\d+$"))
            {
                MessageBox.Show("Поле 'Количество' должно содержать только цифры!");
                return;
            }

            int Quantity;
            if (!int.TryParse(Quant.Text, out Quantity))
            {
                MessageBox.Show("Введенное значение слишком большое!");
                return;
            }

            // Проверка на отрицательное число или число больше 10
            if (Quantity <= 0 || Quantity > 10)
            {
                MessageBox.Show("Поле 'Количество' должно быть положительным числом, не превышающим 10!");
                return;
            }

            // Проверка на пустоту комбобоксов
            if (Sushis.SelectedItem == null || QS.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите продукт и заказ!");
                return;
            }

            OrderSushiSets sets = new OrderSushiSets();

            SushiSets selectedProduct = Sushis.SelectedItem as SushiSets;

            if (selectedProduct != null)
            {
                sets.SushiSets_ID = selectedProduct.ID_SushiSets;
            }

            Orders selectedOrder = QS.SelectedItem as Orders;

            if (selectedOrder != null)
            {
                sets.Order_ID = selectedOrder.ID_Order;
            }

            sets.Quantity = Quantity;

            con.OrderSushiSets.Add(sets);
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.OrderSushiSets.ToList();
        }






        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.OrderSushiSets.Remove(SushiBarHarmony.SelectedItem as OrderSushiSets);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.OrderSushiSets.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                // Проверка на пустоту поля Quant
                if (string.IsNullOrWhiteSpace(Quant.Text))
                {
                    MessageBox.Show("Пожалуйста, введите количество заказываемых комплектов суши!");
                    return;
                }

                // Проверка ввода только цифр для количества заказываемых комплектов суши
                if (!Regex.IsMatch(Quant.Text, @"^\d+$"))
                {
                    MessageBox.Show("Поле 'Количество' должно содержать только цифры!");
                    return;
                }

                int Quantity;
                if (!int.TryParse(Quant.Text, out Quantity))
                {
                    MessageBox.Show("Введенное значение слишком большое!");
                    return;
                }

                // Проверка на отрицательное число
                if (Quantity <= 0)
                {
                    MessageBox.Show("Поле 'Количество' должно содержать положительное число!");
                    return;
                }

                OrderSushiSets selected = SushiBarHarmony.SelectedItem as OrderSushiSets;

                string Setname = (Sushis.SelectedItem as SushiSets)?.SushiSetName;
                string tt = (QS.SelectedItem as Orders)?.TotalAmount.ToString();

                var sus = con.SushiSets.FirstOrDefault(r => r.SushiSetName == Setname);
                var sto = con.Orders.FirstOrDefault(r => r.TotalAmount.ToString() == tt);

                // Проверка на максимальное значение количества заказываемых комплектов суши
                if (Quantity > 10)
                {
                    MessageBox.Show("Поле 'Количество' не может превышать 10!");
                    return;
                }

                selected.Quantity = Quantity;

                if (sus != null)
                    selected.SushiSets_ID = sus.ID_SushiSets;
                if (sto != null)
                    selected.Order_ID = sto.ID_Order;
            }

            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.OrderSushiSets.ToList();
        }



        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                OrderSushiSets selectedIngredient = SushiBarHarmony.SelectedItem as OrderSushiSets;

                Quant.Text = selectedIngredient.Quantity.ToString();

                int Orders_ID = selectedIngredient.Order_ID.GetValueOrDefault();
                int SushiSets_ID = selectedIngredient.SushiSets_ID.GetValueOrDefault();


                Sushis.SelectedItem = con.SushiSets.FirstOrDefault(s => s.ID_SushiSets == SushiSets_ID);


                QS.SelectedItem = con.Orders.FirstOrDefault(s => s.ID_Order == Orders_ID);
            }
        }


    }
}

