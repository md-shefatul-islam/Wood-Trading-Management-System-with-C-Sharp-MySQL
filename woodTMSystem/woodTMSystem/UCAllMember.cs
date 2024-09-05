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
    public partial class UCAllMember : UserControl
    {
        private FormDashBoardAdmin Dba { set; get; }
        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }
        private DataTable Dt { get; set; }
        private string Sql { set; get; }
        private Panel pl;
        public UCAllMember()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
        }
        private void btnrefresh_Click_1(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void UCAllMember_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        public UCAllMember(Panel p, FormDashBoardAdmin f) : this()
        {
            this.pl = p;
            this.Dba = f;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            pl.Visible = true;
            Dba.Visible = true;
        }

        private void PopulateGridView(string Sql = "select * from Info;")
        {
            this.Ds = this.Da.ExecuteQuery(Sql);
            this.dgvinfo.ClearSelection();
            this.dgvinfo.AutoGenerateColumns = false;
            this.dgvinfo.DataSource = this.Ds.Tables[0];
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            UCAllMemberEdit ame = new UCAllMemberEdit(this.dgvinfo.CurrentRow.Cells[0].Value.ToString(), this);
            Dba.panel2.Controls.Add(ame);
            ame.Show();
            this.Visible = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            UCAllMemberEdit ame = new UCAllMemberEdit(this);
            Dba.panel2.Controls.Add(ame);
            this.Visible = false;
        }
        private void btnaddadmin_Click(object sender, EventArgs e)
        {

            UCAddAdmin ad = new UCAddAdmin(this);
            Dba.panel2.Controls.Add(ad);
            this.Visible = false;
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            string id = this.dgvinfo.CurrentRow.Cells[0].Value.ToString();
            string name = this.dgvinfo.CurrentRow.Cells["name"].Value.ToString();


            this.Sql = @"delete from Info
                where id = '" + id + "'; ";

            int count = this.Da.ExecuteUpdateQuery(this.Sql);
            if (count == 1)
            {
                MessageBox.Show(name + " Data Deleted");
            }
            else
            {
                MessageBox.Show("Data Deleted failed");
            }
            this.PopulateGridView();
        }           
        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text == "Enter ID")
            {
                this.txtsearch.Text = "";
                this.txtsearch.ForeColor = Color.Black;
            }
        }
        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                this.txtsearch.Text = "Enter ID";
                this.txtsearch.ForeColor = Color.DimGray;
            }
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (this.txtsearch.Text == "" || this.txtsearch.Text == "Enter ID")
            {
                MessageBox.Show("please,write the your id");
            }
            else
            {
                this.Sql = "select * from info where id ='" + this.txtsearch.Text + "';";
                this.PopulateGridView(this.Sql);
            }
        }       
    }
}

