using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace Praktika5
{

    public partial class OrderPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public OrderPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.Orders.ToList();

            PayMentCbx.ItemsSource = con.PaymentMethods.ToList();
            PayMentCbx.DisplayMemberPath = "MethodName";
            PayMentCbx.SelectedValuePath = "ID_PaymentMethod";

            EmlCbx.ItemsSource = con.Employees.ToList();
            EmlCbx.DisplayMemberPath = "Surname";
            EmlCbx.SelectedValuePath = "ID_Employee";

        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Orders order = new Orders();

            if (string.IsNullOrEmpty(Data.Text))
            {
                MessageBox.Show("Укажите дату заказа!");
                return;
            }

            if (!DateTime.TryParse(Data.Text, out DateTime orderDate))
            {
                MessageBox.Show("Ошибка в формате даты!");
                return;
            }

            order.OrderDateTime = orderDate;

            if (string.IsNullOrEmpty(TotalAm.Text))
            {
                MessageBox.Show("Укажите итоговую цену!");
                return;
            }

            if (!int.TryParse(TotalAm.Text, out int totalAmount))
            {
                MessageBox.Show("Введенное значение слишком большое!");
                return;
            }

            if (totalAmount <= 0 || totalAmount > 100000)
            {
                MessageBox.Show("Итоговая цена должна быть положительным числом, не превышающим 100000!");
                return;
            }

            order.TotalAmount = totalAmount;

            PaymentMethods selectedPaymentMethod = PayMentCbx.SelectedItem as PaymentMethods;
            if (selectedPaymentMethod == null)
            {
                MessageBox.Show("Выберите способ оплаты!");
                return;
            }

            order.PaymentMethod_ID = selectedPaymentMethod.ID_PaymentMethod;

            Employees selectedEmployee = EmlCbx.SelectedItem as Employees;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            order.Employee_ID = selectedEmployee.ID_Employee;

            con.Orders.Add(order);
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Orders.ToList();
        }






        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.Orders.Remove(SushiBarHarmony.SelectedItem as Orders);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Orders.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Orders selected = SushiBarHarmony.SelectedItem as Orders;

                if (!int.TryParse(TotalAm.Text, out int totalAmount))
                {
                    MessageBox.Show("Введенное значение слишком большое!");
                    return;
                }

                if (totalAmount <= 0 || totalAmount > 100000)
                {
                    MessageBox.Show("Итоговая цена должна быть положительным числом, не превышающим 100000!");
                    return;
                }

                selected.TotalAmount = totalAmount;

                if (DateTime.TryParse(Data.Text, out DateTime orderDate))
                {
                    selected.OrderDateTime = orderDate;
                }
                else
                {
                    MessageBox.Show("Ошибка в формате даты!");
                    return;
                }

                PaymentMethods selectedPaymentMethod = PayMentCbx.SelectedItem as PaymentMethods;
                Employees selectedEmployee = EmlCbx.SelectedItem as Employees;

                if (selectedPaymentMethod != null)
                    selected.PaymentMethod_ID = selectedPaymentMethod.ID_PaymentMethod;
                if (selectedEmployee != null)
                    selected.Employee_ID = selectedEmployee.ID_Employee;
            }

            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Orders.ToList();
        }





        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Orders selectedOrder = SushiBarHarmony.SelectedItem as Orders;

                TotalAm.Text = selectedOrder.TotalAmount.ToString();
                Data.Text = selectedOrder.OrderDateTime.ToString();

                PayMentCbx.ItemsSource = con.PaymentMethods.ToList();
                PayMentCbx.DisplayMemberPath = "MethodName";
                PayMentCbx.SelectedValuePath = "ID_PaymentMethod";
                PayMentCbx.SelectedValue = selectedOrder.PaymentMethod_ID;

                EmlCbx.ItemsSource = con.Employees.ToList();
                EmlCbx.DisplayMemberPath = "Surname";
                EmlCbx.SelectedValuePath = "ID_Employee";
                EmlCbx.SelectedValue = selectedOrder.Employee_ID;
            }
        }


    }
}

