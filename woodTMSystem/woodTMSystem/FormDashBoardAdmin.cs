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
    public partial class FormDashBoardAdmin : Form
    {
        public FormDashBoardAdmin()
        {
            InitializeComponent();
            this.panel3.Visible = true;
        }

        private void FormDashBoardAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btncprofile_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            USProfileInfo p = new USProfileInfo(panel3,this);
            this.panel2.Controls.Add(p);
            p.Visible=true;
            this.panel3.Visible = false;

        }

        private void btnallmember_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;           
            UCAllMember am = new UCAllMember(panel3,this);
            this.panel2.Controls.Add(am);
            am.Visible = true; ;
            this.panel3.Visible = false;
        }

        private void btnproductdetails_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = false;
            UCProduct up = new UCProduct(panel3, this);
            this.panel2.Controls.Add(up);
            up.Visible=true;
            this.panel2.Visible = true;
        }

        private void btnorderlist_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            UCOrderList ol = new UCOrderList(panel3, this);
            this.panel2.Controls.Add(ol);
            ol.Visible=true;
            this.panel3.Visible = false;

        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            FormLogin fl = new FormLogin();
            fl.Visible = true;
            this.Visible = false;
        }
    }
}
