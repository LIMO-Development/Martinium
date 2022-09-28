using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartiniumForm
{
    public partial class CButton : System.Windows.Forms.Button
    {
        public CButton(string text)
        {
            Text = text;
            Font = new Font("Sans-Serif", 15);
            BackColor = Color.FromArgb(1, 255, 255, 255);
            Click += new EventHandler((object s, EventArgs e) =>
            {
                BackColor = Color.FromArgb(1, 255, 0, 0);
            });
            InitializeComponent();
        }

        public CButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
