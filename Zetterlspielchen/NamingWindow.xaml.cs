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

namespace Zetterlspielchen
{
    /// <summary>
    /// Interaction logic for NamingWindow.xaml
    /// </summary>
    public partial class NamingWindow : Window
    {
        public string GivenName { get; set; }
        public NamingWindow()
        {
            InitializeComponent();
            GivenName = "New_File";
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GivenName = GivenName.Replace(' ', '_');
            GivenName = GivenName.Replace('-', '_');
            this.Close();
        }
    }
}
