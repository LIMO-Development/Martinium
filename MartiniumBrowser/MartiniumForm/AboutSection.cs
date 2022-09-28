using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartiniumForm
{
    public partial class AboutSection : System.Windows.Forms.Label
    {
        public AboutSection(string text)
        {
            this.Text = text;
            this.Font = new System.Drawing.Font("Sans-Serif", 15);
            InitializeComponent();
        }

        public AboutSection(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
