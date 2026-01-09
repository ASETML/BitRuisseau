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
    /// <summary>
    /// Display a mediatheque
    /// </summary>
    public partial class MediathequeCard : UserControl
    {
        private string _name;
        public event EventHandler MediathequeSelected;

        public MediathequeCard(string name)
        {
            InitializeComponent();
            this.lbl_name.Text = name;
            this._name = name;

            //The control is green if it is us
            if (name == System.Net.Dns.GetHostName())
            {
                this.lbl_name.Text = name + " (Vous)";
                this.BackColor = (Color)new ColorConverter().ConvertFrom("#d6ffe1");
            }
        }

        /// <summary>
        /// Send an event when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediathequeCard_Click(object sender, EventArgs e)
        {
            MediathequeSelected.Invoke(this, new AskCatalogEventArgs(this._name));
        }
    }
}
