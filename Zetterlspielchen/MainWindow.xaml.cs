using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Zetterlspielchen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string LastMsg { get; set; }
        public string ThisMsg { get; set; }
        public string CompleteMsg { get; set; }
        public Guid SessionId { get; set; }
        public string FileName { get; set; }
        public int CurNumber { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LastMsg = "Datei hier reinziehen, falls das hier der erste Satz ist, einfach ignorieren";
            ThisMsg = string.Empty;
            Directory.CreateDirectory(@"C:\temp\zetterlSpiel");
            SessionId = Guid.NewGuid();
            FileName = "";
            CurNumber = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChange(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void TextBox_PreviewDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
            e.Handled = true;
        }

        private void TextBox_PreviewDrop(object sender, DragEventArgs e)
        {
            object text = e.Data.GetData(DataFormats.FileDrop);
            CompleteMsg = System.IO.File.ReadAllText(((string[])text)[0]);
            FileName = System.IO.Path.GetFileName(((string[])text)[0]);

            string[] fileParts = FileName.Split('-');
            if(int.TryParse(fileParts[0], out int outnumber))
            {
                outnumber++;
                CurNumber = outnumber;
                FileName = fileParts[1];
            }
            string[] msgs = CompleteMsg.Split((char)1);
            LastMsg = msgs[msgs.Length - 1];
            OnChange("lastMsg");
        }

        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:\temp\zetterlSpiel");
        }

        private void Export(object sender, RoutedEventArgs e)
        {
            if (CompleteMsg != null && !CompleteMsg.Equals(string.Empty) && File.Exists(@"C:\temp\zetterlSpiel\" + SessionId + ".fuck"))
            {
                string[] msgs = CompleteMsg.Split((char)1);
                if (ThisMsg.Equals(msgs[msgs.Length - 1])) return;
            }
            if(CompleteMsg == null || !ThisMsg.Equals(CompleteMsg.Split((char)1)[CompleteMsg.Split((char)1).Length - 1]))
            {
                CompleteMsg += (char)1;
                CompleteMsg += ThisMsg;
            }
            OnChange("lastMsg");
            if (FileName != "")
            {
                if (File.Exists(@"C:\temp\zetterlSpiel\" + CurNumber + "-" + FileName))
                {
                    File.Delete(@"C:\temp\zetterlSpiel\" + CurNumber + "-" + FileName);
                }
                StreamWriter sw = File.CreateText(@"C:\temp\zetterlSpiel\" + CurNumber + "-" + FileName);
                sw.Write(CompleteMsg);
                sw.Close();
            }
            else
            {
                NamingWindow namingWindow = new NamingWindow();
                namingWindow.ShowDialog();
                FileName = namingWindow.GivenName + ".fuck";
                if (File.Exists(@"C:\temp\zetterlSpiel\" + CurNumber + "-" + FileName))
                {
                    File.Delete(@"C:\temp\zetterlSpiel\" + CurNumber + "-" + FileName);
                }
                StreamWriter sw = File.CreateText(@"C:\temp\zetterlSpiel\" + CurNumber + "-" + FileName);
                sw.Write(CompleteMsg);
                sw.Close();
            }
        }

        private void Resolve(object sender, RoutedEventArgs e)
        {
            ResolveWindow resolveWindow = new ResolveWindow(CompleteMsg);
            resolveWindow.Show();
        }
    }
}
