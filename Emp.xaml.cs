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
    /// Логика взаимодействия для Emp.xaml
    /// </summary>
    public partial class Emp : Window
    {
        public Emp()
        {
            InitializeComponent();
        }

        private void ShowMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Storage(object sender, RoutedEventArgs e)
        {
            StoragePage page = new StoragePage();
            this.Content = page;
        }

        private void Order(object sender, RoutedEventArgs e)
        {
            OrderPage page = new OrderPage();
            this.Content = page;
        }

        private void QuantIngr(object sender, RoutedEventArgs e)
        {
            IngredientsPage page = new IngredientsPage();
            this.Content = page;
        }

        private void Sushi(object sender, RoutedEventArgs e)
        {
            SushiPage page = new SushiPage();
            this.Content = page;
        }

        private void QuantSushi(object sender, RoutedEventArgs e)
        {
            QuantSushiPage page = new QuantSushiPage();
            this.Content = page;
        }

        private void SushiSets(object sender, RoutedEventArgs e)
        {
            SushiSetsPage page = new SushiSetsPage();
            this.Content = page;
        }

        private void QuantSets(object sender, RoutedEventArgs e)
        {
            QuantSetsPage page = new QuantSetsPage();
            this.Content = page;
        }

        private void Pay(object sender, RoutedEventArgs e)
        {
            PayPage page = new PayPage();
            this.Content = page;
        }
        private void Cassa(object sender, RoutedEventArgs e)
        {
            Cassa page = new Cassa();
            this.Content = page;
        }

    }
}
