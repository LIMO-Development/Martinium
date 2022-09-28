using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartiniumForm
{
    public partial class HeaderLabel : System.Windows.Forms.Label
    {
        public HeaderLabel(string text)
        {
            this.Text = text;
            this.Font = new System.Drawing.Font("Sans-Serif", 20);
            InitializeComponent();
        }

        public HeaderLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
