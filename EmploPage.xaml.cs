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
    public partial class EmploPage : Page
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public EmploPage()
        {
            InitializeComponent();
            SushiBarHarmony.ItemsSource = con.Employees.ToList();

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
            if (string.IsNullOrWhiteSpace(FN.Text) || string.IsNullOrWhiteSpace(SN.Text) || string.IsNullOrWhiteSpace(MN.Text) || string.IsNullOrWhiteSpace(RoleCbx.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            if (!Regex.IsMatch(FN.Text, @"^[а-яА-Я]+$"))
            {
                MessageBox.Show("Поле 'Имя' должно содержать только русские буквы!");
                return;
            }

            if (!Regex.IsMatch(SN.Text, @"^[а-яА-Я]+$"))
            {
                MessageBox.Show("Поле 'Фамилия' должно содержать только русские буквы!");
                return;
            }

            if (!Regex.IsMatch(MN.Text, @"^[а-яА-Я\s'-]+$"))
            {
                MessageBox.Show("Поле 'Отчество' должно содержать только русские буквы!");
                return;
            }


            if (string.IsNullOrWhiteSpace(RoleCbx.Text))
            {
                MessageBox.Show("Выберите роль!");
                return;
            }

            string First_name = FN.Text;
            string Surname = SN.Text;
            string Middlename = MN.Text;
            string Sposob = RoleCbx.Text;


            int Role_ID = con.Roles.FirstOrDefault(s => s.RoleName == Sposob)?.ID_Role ?? 0;

            Employees a = new Employees();
            a.First_name = First_name;
            a.Surname = Surname;
            a.MiddleName = Middlename;
            a.Role_ID = Role_ID;

            con.Employees.Add(a);
            con.SaveChanges();

            SushiBarHarmony.ItemsSource = con.Employees.ToList();
        }




        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                con.Employees.Remove(SushiBarHarmony.SelectedItem as Employees);
            }
            con.SaveChanges();
            SushiBarHarmony.ItemsSource = con.Employees.ToList();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                // Получаем выбранную запись
                Employees selected = SushiBarHarmony.SelectedItem as Employees;

                // Проверка на пустоту полей
                if (string.IsNullOrWhiteSpace(FN.Text) || string.IsNullOrWhiteSpace(SN.Text) || string.IsNullOrWhiteSpace(MN.Text) || string.IsNullOrWhiteSpace(RoleCbx.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                    return;
                }

                // Проверка ввода только русских букв
                if (!Regex.IsMatch(FN.Text, @"^[а-яА-Я]+$"))
                {
                    MessageBox.Show("Поле 'Имя' должно содержать только русские буквы!");
                    return;
                }

                if (!Regex.IsMatch(SN.Text, @"^[а-яА-Я]+$"))
                {
                    MessageBox.Show("Поле 'Фамилия' должно содержать только русские буквы!");
                    return;
                }

                if (!Regex.IsMatch(MN.Text, @"^[а-яА-Я]+$"))
                {
                    MessageBox.Show("Поле 'Отчество' должно содержать только русские буквы!");
                    return;
                }

                // Получение названия выбранной роли
                string selectedRoleName = RoleCbx.Text;

                // Проверка существования выбранной роли в базе данных
                var selectedRole = con.Roles.FirstOrDefault(r => r.RoleName == selectedRoleName);
                if (selectedRole == null)
                {
                    MessageBox.Show("Выбранная роль не существует.");
                    return;
                }

                // Обновление данных выбранной записи
                selected.First_name = FN.Text;
                selected.Surname = SN.Text;
                selected.MiddleName = MN.Text;
                selected.Role_ID = selectedRole.ID_Role;
            }

            // Сохранение изменений в базе данных
            con.SaveChanges();

            // Обновление списка в DataGrid
            SushiBarHarmony.ItemsSource = con.Employees.ToList();
        }



        private void SushiBarHarmony_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                Employees selectedStorage = SushiBarHarmony.SelectedItem as Employees;
                FN.Text = selectedStorage.First_name;
                SN.Text = selectedStorage.Surname;
                MN.Text = selectedStorage.MiddleName;

                int Rol = selectedStorage.Role_ID.GetValueOrDefault();


                RoleCbx.SelectedItem = con.Roles.FirstOrDefault(s => s.ID_Role == Rol);
            }
        }
    }
}
