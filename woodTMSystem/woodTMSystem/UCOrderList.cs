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
    public partial class UCOrderList : UserControl
    {
        private FormDashBoardAdmin Dba { set; get; }
        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }
        private DataTable Dt { get; set; }
        string Sql { set; get; }
        string newID { set; get; }
        string LoginId { set; get; }
        private Panel pl { set; get; }
        public UCOrderList()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
        }

        public UCOrderList(Panel p,FormDashBoardAdmin du) : this()
        {
            this.pl = p;
            this.Dba = du;
        }

        private void PopulateGridView(string Sql = "select * from orderlist;")
        {
            try { 
            
            //this.Ds = this.Da.ExecuteQuery(Sql);
            this.Dt = this.Da.ExecuteQueryTable(Sql);

            this.dgvorderlist.AutoGenerateColumns = false;
            //this.dgvinfo.DataSource = this.Ds.Tables[0];
            this.dgvorderlist.DataSource = this.Dt;
            }
            catch (Exception ae)
            {
                MessageBox.Show("excetion found in PopulateGridView product of ucorder" + ae);
            }

        }
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.pl.Visible = true;
            this.Dba.Visible = true;
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try { 
            string id = this.dgvorderlist.CurrentRow.Cells[0].Value.ToString();
            string name = this.dgvorderlist.CurrentRow.Cells["name"].Value.ToString();


            this.Sql = @"delete from orderlist
                where no = '" + id + "'; ";

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
            catch (Exception ae)
            {
                MessageBox.Show("excetion found in btndelete product of ucorder" + ae);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(this.txtsearch.Text=="" || this.txtsearch.Text == "Enter Customer ID")
            {
                MessageBox.Show("please,write the Customer id");
            }
            else
            {
                this.Sql = "select * from orderlist where customerid ='"+this.txtsearch.Text+"';";
                this.PopulateGridView(this.Sql);
            }
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if(this.txtsearch.Text== "Enter Customer ID")
            {
                this.txtsearch.Text = "";
                this.txtsearch.ForeColor = Color.Black;
            }
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (this.txtsearch.Text == "")
            {
                this.txtsearch.Text = "Enter Customer ID";
                this.txtsearch.ForeColor = Color.DimGray;
            }
        }
    }
    
}
