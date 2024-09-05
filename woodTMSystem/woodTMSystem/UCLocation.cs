using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace woodTMSystem
{
    public partial class UCLocation : UserControl
    {
        private FormGuest fg { set; get; }
        private Panel al;
        public UCLocation()
        {
            InitializeComponent();
        }

        public UCLocation(Panel a, FormGuest g) : this()
        {
            this.fg = g;
            this.al = a;
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                fg.Visible = true;
                al.Visible = true;
            }
            catch (Exception ae)
            {
                MessageBox.Show("an exception fount in btnback of location"+ae);
            }

        }

    }
}
