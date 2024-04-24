using System;
using System.Collections.Generic;
using System.Configuration;
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

    public partial class MainWindow : Window
    {
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ForAutorize(object sender, RoutedEventArgs e)
        {
            string enteredLogin = Log.Text;
            string enteredPassword = Pass.Password;

            var auto = con.Autorize.FirstOrDefault(u => u.Logins == enteredLogin && u.Passwords == enteredPassword);


            if (auto != null) 
            {
                switch (auto.Role_ID)
                {
                    case 1:
                        Emp emp = new Emp();
                        emp.Show();
                        break;
                    case 2:
                        Adm admin = new Adm();
                        admin.Show();
                        break;
                    default:
                        MessageBox.Show("Не верная роль");
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль");
            }
        }
    }
}
