using Microsoft.Win32;
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
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace L2
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebClient myWebClient = new WebClient();
            string myStringWebResource = @"https://bdu.fstec.ru/files/documents/thrlist.xlsx";

            myWebClient.DownloadFile(myStringWebResource, MainWindow.fileName);
            MainWindow.filepath = Path.GetFullPath(MainWindow.fileName);
            File.Move(MainWindow.filepath, textBox1.Text + MainWindow.fileName);
            MainWindow.filepath = Path.GetFullPath(MainWindow.fileName);
            this.Close();
        }
    }
}
