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
    /// Interakční logika pro InnitNewtabPage.xaml
    /// </summary>
    public partial class InnitNewtabPage : UserControl
    {
        public InnitNewtabPage()
        {
            InitializeComponent();
            SetupXAMLItems();
        }

        public void SetupXAMLItems()
        {
            this.Height = (SystemParameters.PrimaryScreenHeight - 40) - 97;
        }
    }
}
