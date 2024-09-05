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
    public partial class FormGuest : Form
    {
        private FormLogin fl { get; set; }
        public FormGuest()
        {
            InitializeComponent();
            this.panel2.Visible = true;
        }
        public FormGuest(FormLogin f) : this()
        {
            this.fl = f;
        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            fl.Visible = true;
        }

        private void lblpicture_Click(object sender, EventArgs e)
        {
            try { 
            this.panel4.Visible = true;
            UCAwards up = new UCAwards(this.panel2,this);
            this.panel4.Controls.Add(up);
            up.Show();
            this.panel2.Visible = false;
            }
            catch (Exception ae)
            {
                MessageBox.Show("excetion found in btnpicture of guest" + ae);
            }

        }

        private void lblavailablep_Click(object sender, EventArgs e)
        {
            try { 
            this.panel4.Visible = true;
            UserProductGuest pg = new UserProductGuest(this.panel2, this);
            this.panel4.Controls.Add(pg);
            pg.Show();
            this.panel2.Visible = false;
            }
            catch (Exception ae)
            {
                MessageBox.Show("excetion found in btnavailable product of guest" + ae);
            }
        }

        private void FormGuest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lbllocation_Click(object sender, EventArgs e)
        {
            try { 

            this.panel4.Visible = true;
            UCLocation l = new UCLocation(this.panel2, this);
            this.panel4.Controls.Add(l);
            l.Show();
            this.panel2.Visible = false;
        }
            catch (Exception ae)
            {
                MessageBox.Show("excetion found in btnlocation product of guest" + ae);
            }
}

        private void lblsuggestion_Click(object sender, EventArgs e)
        {
            try { 
            this.panel4.Visible = true;
            UCSuggestion s = new UCSuggestion(this.panel2, this);
            this.panel4.Controls.Add(s);
            s.Show();
            this.panel2.Visible = false;
            }
            catch (Exception ae)
            {
                MessageBox.Show("excetion found in btnsugestion product of guest" + ae);
            }
        }
    }
}
