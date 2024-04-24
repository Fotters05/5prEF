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

    public partial class PayPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public PayPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.PaymentMethods.ToList();
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SO.Text))
            {
                MessageBox.Show("Пожалуйста, введите способ оплаты!");
                return;
            }

            string spos = SO.Text;

            if (spos.Length > 30)
            {
                MessageBox.Show("Название способа оплаты не должно превышать 30 символов!");
                return;
            }

            if (!Regex.IsMatch(spos, @"^[a-zA-Zа-яА-Я0-9]+$"))
            {
                MessageBox.Show("Название способа оплаты должно содержать только буквы, цифры и русские буквы!");
                return;
            }

            PaymentMethods a = new PaymentMethods();
            a.MethodName = spos;
            con.PaymentMethods.Add(a);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.PaymentMethods.ToList();
        }



        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.PaymentMethods.Remove(SushiBarHarmony.SelectedItem as PaymentMethods);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.PaymentMethods.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(SO.Text))
                {
                    MessageBox.Show("Пожалуйста, введите способ оплаты!");
                    return;
                }

                string spos = SO.Text;

                // Проверка на длину строки
                if (spos.Length > 30)
                {
                    MessageBox.Show("Название способа оплаты не должно превышать 30 символов!");
                    return;
                }

                // Проверка на использование только буквенно-цифровых символов, а также русских букв
                if (!Regex.IsMatch(spos, @"^[a-zA-Zа-яА-Я0-9]+$"))
                {
                    MessageBox.Show("Название способа оплаты должно содержать только буквы, цифры и русские буквы!");
                    return;
                }

                PaymentMethods selected = SushiBarHarmony.SelectedItem as PaymentMethods;
                selected.MethodName = spos;
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.PaymentMethods.ToList();
        }


        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                PaymentMethods selectedset = SushiBarHarmony.SelectedItem as PaymentMethods;
                SO.Text = selectedset.MethodName;
            }
        }

        private void Imp_Click(object sender, RoutedEventArgs e)
        {
            List<PaymentMethods> paymentMethods = Convert.DeserializeObject<List<PaymentMethods>>();
            foreach (var paymentMethod in paymentMethods)
            {
                con.PaymentMethods.Add(paymentMethod);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = null;
            SushiBarHarmony.ItemsSource = con.PaymentMethods.ToList();
        }
    }
}
