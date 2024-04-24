using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Praktika5
{

    public partial class DanniePage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public DanniePage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.Autorize.ToList();

            RoleCbx.ItemsSource = con.Roles.ToList();
            RoleCbx.DisplayMemberPath = "RoleName";
            RoleCbx.SelectedValuePath = "ID_Role";
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            Adm adm = new Adm();
            adm.Show();
            Window.GetWindow(this).Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Log.Text))
            {
                MessageBox.Show("Введите логин!");
                return;
            }


            if (string.IsNullOrWhiteSpace(Par.Password))
            {
                MessageBox.Show("Введите пароль!");
                return;
            }


            if (string.IsNullOrWhiteSpace(RoleCbx.Text))
            {
                MessageBox.Show("Выберите роль!");
                return;
            }

            string Logins = Log.Text;
            string Passwords = Par.Password;
            string Sposob = RoleCbx.Text;


            int Role_ID = con.Roles.FirstOrDefault(s => s.RoleName == Sposob)?.ID_Role ?? 0;

            Autorize a = new Autorize();
            a.Logins = Logins;
            a.Passwords = Passwords;
            a.Role_ID = Role_ID;

            con.Autorize.Add(a);
            con.SaveChanges();


            SushiBarHarmony.ItemsSource = con.Autorize.ToList();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.Autorize.Remove(SushiBarHarmony.SelectedItem as Autorize);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Autorize.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {

                Autorize selected = SushiBarHarmony.SelectedItem as Autorize;

                if (string.IsNullOrWhiteSpace(Log.Text))
                {
                    MessageBox.Show("Введите логин!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Par.Password))
                {
                    MessageBox.Show("Введите пароль!");
                    return;
                }


                string selectedRoleName = RoleCbx.Text;


                var selectedRole = con.Roles.FirstOrDefault(r => r.RoleName == selectedRoleName);
                if (selectedRole == null)
                {
                    MessageBox.Show("Выбранная роль не существует.");
                    return;
                }

                selected.Logins = Log.Text;
                selected.Passwords = Par.Password;
                selected.Role_ID = selectedRole.ID_Role;
            }


            con.SaveChanges();


            SushiBarHarmony.ItemsSource = con.Autorize.ToList();
        }



        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Autorize selectedStorage = SushiBarHarmony.SelectedItem as Autorize;
                Log.Text = selectedStorage.Logins;
                Par.Password = selectedStorage.Passwords.ToString();

                int Rol = selectedStorage.Role_ID.GetValueOrDefault();



                RoleCbx.SelectedItem = con.Roles.FirstOrDefault(s => s.ID_Role == Rol);
            }
        }
    }
}
