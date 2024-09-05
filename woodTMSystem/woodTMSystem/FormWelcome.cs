using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace woodTMSystem
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            FormLogin f2 = new FormLogin(this);
            f2.Visible = true;

            this.Visible = false;
        }

        private void FormWelcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
