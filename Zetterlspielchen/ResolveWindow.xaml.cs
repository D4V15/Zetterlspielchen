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
    /// Interaction logic for ResolveWindow.xaml
    /// </summary>
    public partial class ResolveWindow : Window
    {
        public string completeMsg { get; set; }
        public ResolveWindow(string completeText)
        {
            InitializeComponent();
            completeMsg = completeText.Replace((char)1, '\n');
            DataContext = this;
        }
    }
}
