using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitRuisseau
{
    public partial class MediathequeCard : UserControl
    {
        public MediathequeCard(string name)
        {
            InitializeComponent();
            this.lbl_name.Text = name;
            if (name == System.Net.Dns.GetHostName())
            {
                this.lbl_name.Text = name + " (Vous)";
                this.BackColor = (Color)new ColorConverter().ConvertFrom("#d6ffe1");
            }
        }
    }
}
