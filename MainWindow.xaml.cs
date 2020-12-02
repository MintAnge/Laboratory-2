using Microsoft.Office.Tools.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using Path = System.IO.Path;
using Word = Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using Microsoft.Win32;

namespace L2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// // ++++++
    //@"‪C:\Users\nocay\OneDrive\Рабочий стол\thrlist.xlsx"


    public partial class MainWindow : Window
    {

        public static string fileName = "thrlist.xlsx";
        public static string filepath = $@"D:\{fileName}";
        private readonly PagingCollectionView view;
        public static List<UBI> list = new List<UBI>();
        public MainWindow()
        {

             InitializeComponent();
            Message newForm = new Message();
            if (File.Exists(filepath) == false)
            {
                newForm.Show();
                DisplayMessageBoxText("После загрузки файла необходимо будет перезапустить приложение");
            }
            
              try
              {

                    Hate_you_excel ex = new Hate_you_excel(filepath);
                    list = ex.list();
                    this.view = new PagingCollectionView(list, 20);
                    this.DataContext = this.view;
                    //DisplayMessageBoxText(MainWindow.filepath);
              }
              catch { }
        }
        public static void DisplayMessageBoxText(string e)
        {
            MessageBox.Show(e);

        }
        private void Update_Click(object sender, System.EventArgs e)
        {
            try
            {
            Update update = new Update();
            update.Show();
            }
            catch { 
            }
        }

        public void Data_click(Object sender,EventArgs e)
        {
            UBI ubi = (UBI)DG.SelectedItem;
            DisplayMessageBoxText($"Индефикатор угрозы: \n{ubi.IndefUBI} \n\n Наименование угрозы: \n{ubi.NameUBI} \n\n Описание угрозы: \n{ubi.Description} \n\n Источник угрозы: \n{ubi.SourceOfThreat} \n\n Объект воздействия угрозы:\n {ubi.Object} \n\n Нарушение конфидерециальности: \n{ubi.BreachConf} \n\n Нарушение целостности: \n{ubi.IntegrityViolation} \n\n Нарушение доступности: \n {ubi.AccessibilityViolation}");
        }
        private void OnNextClicked(object sender, RoutedEventArgs e)
        {
            this.view.MoveToNextPage();
        }

        private void OnPreviousClicked(object sender, RoutedEventArgs e)
        {
            this.view.MoveToPreviousPage();
        }
    }
}
