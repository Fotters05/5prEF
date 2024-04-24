using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class SushiOrderSummary
    {
        // Добавляем свойство для хранения номера чека
        public int CheckNumber { get; set; }

        // Переопределяем метод ToString()
        public override string ToString()
        {
            return $"{SushiSetName}, {SushiSetPrice}";
        }
    }

    public partial class Cassa : Page
    {
        private string filePath = "checks.txt";
        private SUSHIBARSEntities con = new SUSHIBARSEntities();
        private int currentCheckNumber = 1;

        // Создаем коллекцию для хранения чеков
        private List<SushiOrderSummary> checks = new List<SushiOrderSummary>();

        public Cassa()
        {
            InitializeComponent();
            SushiBarHarmony.SelectionChanged += SushiBarHarmony_SelectionChanged;
            listbox.SelectionChanged += ListBox_SelectionChanged;
            All.MouseDoubleClick += All_MouseDoubleClick;
            Spos.ItemsSource = con.PaymentMethods.Select(r => r.MethodName).ToList();
            LoadChecks();

            using (var context = new SUSHIBARSEntities())
            {
                var summaryData = context.SushiOrderSummary.ToList();
                SushiBarHarmony.ItemsSource = summaryData;
            }
        }



        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение чеков при закрытии приложения
            SaveChecks();

            Emp emp = new Emp();
            emp.Show();
            Window.GetWindow(this).Close();
        }

        private string folderPath = @"C:\Users\Fotters\Desktop\.cheks";

        private void SaveChecks()
        {
            // Создание списка строк для сохранения
            List<string> checksToSave = new List<string>();
            foreach (var check in All.Items)
            {
                checksToSave.Add(check.ToString());
            }

            // Сохранение списка строк в файлы в указанной папке
            for (int i = 0; i < checksToSave.Count; i++)
            {
                string filePath = System.IO.Path.Combine(folderPath, $"Чек_{i + 1}.txt");
                File.WriteAllText(filePath, checksToSave[i]);
            }
        }

        private void LoadChecks()
        {
            // Проверка наличия папки
            if (Directory.Exists(folderPath))
            {
                // Получаем все текстовые файлы из папки
                string[] checkFiles = Directory.GetFiles(folderPath, "Чек_*.txt");

                foreach (string filePath in checkFiles)
                {
                    // Загрузка строк из файла
                    string check = File.ReadAllText(filePath);
                    All.Items.Add(check);
                }
            }
        }


        private void Add(object sender, RoutedEventArgs e)
        {
            if (SushiBarHarmony.SelectedItem != null)
            {
                var selectedItem = SushiBarHarmony.SelectedItem as SushiOrderSummary;
                selectedItem.CheckNumber = currentCheckNumber; // Устанавливаем номер чека
                checks.Add(selectedItem); // Добавляем объект SushiOrderSummary в список чеков
                listbox.Items.Add(selectedItem); // Добавляем объект SushiOrderSummary в listbox
            }
        }




        private void Minus(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItem != null)
            {
                listbox.Items.Remove(listbox.SelectedItem);
            }
        }




        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SushiBarHarmony.SelectedIndex = -1;
        }

        private void SushiBarHarmony_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listbox.SelectedIndex = -1;
        }

        // Метод для получения номера следующего чека
        private string GetNextCheckNumber()
        {
            // Увеличиваем текущий номер чека на 1 и возвращаем его
            return (currentCheckNumber++).ToString();
        }

        private void Chek_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что внесена сумма и указан способ оплаты
            if (!string.IsNullOrEmpty(Vneseno.Text) && !string.IsNullOrEmpty(Spos.Text))
            {
                // Вычисляем общую сумму заказа
                decimal totalAmount = 0;
                StringBuilder purchaseInfo = new StringBuilder();

                foreach (var item in listbox.Items)
                {
                    // Проверяем, что объект не является null и приводим его к типу SushiOrderSummary
                    if (item is SushiOrderSummary summaryItem)
                    {
                        purchaseInfo.AppendLine($"{summaryItem.SushiSetName}\t- {summaryItem.SushiSetPrice}");
                        totalAmount += summaryItem.SushiSetPrice;
                    }
                }

                // Получаем номер следующего чека
                string nextCheckNumber = GetNextCheckNumber();

                // Проверяем, что внесенная сумма больше или равна общей сумме заказа
                if (decimal.TryParse(Vneseno.Text, out decimal vnesenoAmount) && vnesenoAmount >= totalAmount)
                {
                    // Формируем строку для записи в файл
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<Сушибар Harmony>");
                    sb.AppendLine($"Кассовый чек №{nextCheckNumber}");
                    sb.AppendLine();
                    sb.Append(purchaseInfo.ToString());
                    sb.AppendLine();
                    sb.AppendLine($"Итого к оплате: {totalAmount}");
                    sb.AppendLine($"Внесено: {vnesenoAmount}");
                    sb.AppendLine($"Сдача: {vnesenoAmount - totalAmount}");

                    // Открываем диалоговое окно сохранения файла
                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                    saveFileDialog.FileName = $"Чек_{nextCheckNumber}.txt"; // Устанавливаем начальное имя файла
                    saveFileDialog.DefaultExt = ".txt"; // Устанавливаем расширение по умолчанию
                    saveFileDialog.Filter = "Text documents (.txt)|*.txt"; // Устанавливаем фильтр для файлов

                    // Показываем диалоговое окно
                    bool? result = saveFileDialog.ShowDialog();

                    // Если пользователь нажал "Сохранить"
                    if (result == true)
                    {
                        // Получаем путь к файлу из диалогового окна
                        string filePath = saveFileDialog.FileName;

                        // Записываем строку в выбранный файл
                        File.WriteAllText(filePath, sb.ToString());

                        MessageBox.Show("Чек успешно сохранен.");

                        // Добавляем созданный чек в ListBox
                        listbox.Items.Add(sb.ToString());

                        // Добавляем созданный чек в ComboBox All
                        All.Items.Add(sb.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Внесенная сумма должна быть больше или равна общей сумме заказа.");
                }
            }
            else
            {
                MessageBox.Show("Введите сумму внесения и способ оплаты.");
            }
        }
        private void All_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Проверяем, что был выбран элемент в листбоксе
            if (All.SelectedItem != null)
            {
                // Получаем выбранный чек
                string selectedCheck = All.SelectedItem.ToString();

                // Открываем диалоговое окно сохранения файла
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.FileName = "Чек.txt"; // Устанавливаем начальное имя файла
                saveFileDialog.DefaultExt = ".txt"; // Устанавливаем расширение по умолчанию
                saveFileDialog.Filter = "Text documents (.txt)|*.txt"; // Устанавливаем фильтр для файлов

                // Показываем диалоговое окно
                bool? result = saveFileDialog.ShowDialog();

                // Если пользователь нажал "Сохранить"
                if (result == true)
                {
                    // Получаем путь к файлу из диалогового окна
                    string filePath = saveFileDialog.FileName;

                    // Записываем строку в выбранный файл
                    File.WriteAllText(filePath, selectedCheck);

                    MessageBox.Show("Чек успешно сохранен.");
                }
            }

        }
        private void Vneseno_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Проверяем, можно ли преобразовать текст введенный в текстбокс в число типа int
            if (!int.TryParse(Vneseno.Text, out int value))
            {
                // Если нельзя, выводим сообщение о том, что число слишком большое
                MessageBox.Show("Число слишком большое.");
            }
        }
    }
}


