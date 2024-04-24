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
using System.Windows.Shapes;

namespace Praktika5
{
    /// <summary>
    /// Логика взаимодействия для Adm.xaml
    /// </summary>
    public partial class Adm : Window
    {
        public Adm()
        {
            InitializeComponent();
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close ();
        }

        private void Dannie(object sender, RoutedEventArgs e)
        {
            DanniePage page = new DanniePage();
            this.Content = page;
        }

        private void Rols(object sender, RoutedEventArgs e)
        {
            RolePage page = new RolePage();
            this.Content = page;
        }

        private void Employees(object sender, RoutedEventArgs e)
        {
            EmploPage page = new EmploPage();
            this.Content = page;
        }

        private void Sup(object sender, RoutedEventArgs e)
        {
            SupplierPage page = new SupplierPage();
            this.Content = page;
        }
    }
}
