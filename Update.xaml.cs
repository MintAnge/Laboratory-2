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
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public static string fileName1 = "thrlist.xlsx";
        public static string filepath1;
        public Update()
        {
            InitializeComponent();
            WebClient myWebClient = new WebClient();
            string myStringWebResource = @"https://bdu.fstec.ru/files/documents/thrlist.xlsx";
            List<string> li = new List<string>();

            myWebClient.DownloadFile(myStringWebResource, fileName1);
                filepath1 = Path.GetFullPath(fileName1);

                Hate_you_excel ex = new Hate_you_excel(filepath1);
                List<UBI> list = ex.list();
                int count = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    string s = "Индекс угрозы: ";
                    s += list[i].IndefUBI + "\n Наименование угрозы: " + list[i].NameUBI;
                    if (list[i].AccessibilityViolation != MainWindow.list[i].AccessibilityViolation || list[i].IntegrityViolation != MainWindow.list[i].IntegrityViolation || list[i].BreachConf != MainWindow.list[i].BreachConf || list[i].Description != MainWindow.list[i].Description || list[i].SourceOfThreat != MainWindow.list[i].SourceOfThreat || list[i].Object != MainWindow.list[i].Object )
                    {
                        if (list[i].Description != MainWindow.list[i].Description)
                        {
                            s += "\n\nБыло: \n" + MainWindow.list[i].Description + "\n\nСтало: \n" + list[i].Description;
                        }
                        if (list[i].SourceOfThreat != MainWindow.list[i].SourceOfThreat)
                        {
                            s += "\n\nБыло: \n" + MainWindow.list[i].SourceOfThreat + "\n\nСтало: \n" + list[i].SourceOfThreat;
                        }
                        if (list[i].Object != MainWindow.list[i].Object)
                        {
                            s += "\n\nБыло: \n" + MainWindow.list[i].Object + "\n\nСтало: \n" + list[i].Object;
                        }
                        if (list[i].BreachConf != MainWindow.list[i].BreachConf)
                        {
                            s += "\n\nБыло: \n" + MainWindow.list[i].BreachConf + "\n\nСтало: \n" + list[i].BreachConf;
                        }
                        if (list[i].IntegrityViolation != MainWindow.list[i].IntegrityViolation)
                        {
                            s += "\n\nБыло: \n" + MainWindow.list[i].IntegrityViolation + "\n\nСтало: \n" + list[i].IntegrityViolation;
                        }
                        if (list[i].AccessibilityViolation != MainWindow.list[i].AccessibilityViolation)
                        {
                            s += "\n\nБыло: \n" + MainWindow.list[i].AccessibilityViolation + "\n\nСтало: \n" + list[i].AccessibilityViolation;
                        }
                        count++;
                    }
                    else s += "\nБез изменений";
                    li.Add(s);
                }
                MainWindow.DisplayMessageBoxText("Количество изменений: "+count);
                L.ItemsSource = li;
                File.Delete(MainWindow.filepath);
                File.Move(filepath1, MainWindow.filepath);
            

            
        }
    }
}
