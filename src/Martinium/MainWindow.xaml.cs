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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Martinium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddTabToTabspace(object sender, RoutedEventArgs e)
        {
            TabItem newtab = new TabItem();
            InnitNewtab tab = new InnitNewtab();
            newtab.Content = tab;
            newtab.Style = (Style)FindResource("tabStyle");
            tabs.Items.Add(newtab);
        }

        public void RemoveTabFromTabspace(object sender, RoutedEventArgs e)
        {
            switch (tabs.SelectedIndex == 0)
            {
                case true:
                    break;

                case false:
                    switch (tabs.SelectedIndex == 1)
                    {
                        case true:
                            break;

                        case false:
                            tabs.Items.RemoveAt(tabs.SelectedIndex);
                            break;
                    }
                    break;
            }
            
        }
    }
}
