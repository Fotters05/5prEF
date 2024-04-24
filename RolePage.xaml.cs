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

    public partial class RolePage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public RolePage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.Roles.ToList();
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Adm adm = new Adm();
            adm.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string roleName = RO.Text;

            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Введите название роли!");
                return;
            }

            if (roleName.Length > 30)
            {
                MessageBox.Show("Название роли не должно превышать 30 символов!");
                return;
            }

            if (!Regex.IsMatch(roleName, @"^[a-zA-Zа-яА-Я]+$"))
            {
                MessageBox.Show("Название роли должно содержать только буквы русского и английского алфавитов!");
                return;
            }

            Roles role = new Roles();
            role.RoleName = roleName;
            con.Roles.Add(role);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.Roles.ToList();
        }


        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.Roles.Remove(SushiBarHarmony.SelectedItem as Roles);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Roles.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Roles selected = SushiBarHarmony.SelectedItem as Roles;

                string roleName = RO.Text;

                if (string.IsNullOrWhiteSpace(roleName))
                {
                    MessageBox.Show("Введите название роли!");
                    return;
                }

                if (roleName.Length > 30)
                {
                    MessageBox.Show("Название роли не должно превышать 30 символов!");
                    return;
                }

                if (!Regex.IsMatch(roleName, @"^[a-zA-Zа-яА-Я]+$"))
                {
                    MessageBox.Show("Название роли должно содержать только буквы русского и английского алфавитов!");
                    return;
                }

                selected.RoleName = roleName;
                con.SaveChanges();
                SushiBarHarmony.ItemsSource = con.Roles.ToList();
            }
        }



        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Roles selectedset = SushiBarHarmony.SelectedItem as Roles;
                RO.Text = selectedset.RoleName;
            }
        }

        private void Imt_Click(object sender, RoutedEventArgs e)
        {
            List<Roles> paymentMethods = Convert.DeserializeObject<List<Roles>>();
            foreach (var paymentMethod in paymentMethods)
            {
                con.Roles.Add(paymentMethod);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = null;
            SushiBarHarmony.ItemsSource = con.Roles.ToList();
        }
    }
}
