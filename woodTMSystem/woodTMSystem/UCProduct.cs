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
    public partial class UCProduct : UserControl
    {
        private FormDashBoardUser Fd { set; get; }
        private FormDashBoardAdmin Fa { set; get; }

        
        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }
        private DataTable Dt { get; set; }
        string Sql { set; get; }
        private Panel pl;
        public UCProduct()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();

        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void UCProduct_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        public UCProduct(Panel p,FormDashBoardUser f) : this()
        {
            this.pl = p;
            this.Fd = f;
        }
        public UCProduct(Panel p,FormDashBoardAdmin f) : this()
        {
            this.pl = p;
            this.Fa = f;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            
            if (FormLogin.ID.Contains("a"))
            {
                this.Visible = false;
                this.pl.Visible = true;
                this.Fa.Visible=true;
            }
            else
            {
                this.Visible = false;
                this.pl.Visible = true;
                this.Fd.Visible=true;
            }
        }

        private void PopulateGridView(string Sql = "select * from product;")
        {
            this.Ds = this.Da.ExecuteQuery(Sql);
            this.dgvproduct.ClearSelection();
            this.dgvproduct.AutoGenerateColumns = false;
            this.dgvproduct.DataSource = this.Ds.Tables[0];
            if (FormLogin.ID.Contains("c"))
            {
                this.dgvproduct.Columns["uploaddate"].Visible = false;
                this.btnEdit.Visible = false;
                this.btnEdit.Enabled = false;
                this.btnrefresh.Visible = false;
                this.btnrefresh.Enabled = false;
                this.btndelete.Visible = false;
                this.btndelete.Enabled = false;
                this.btnadd.Visible = false;
                this.btnadd.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UCProductEdit p = new UCProductEdit(this.dgvproduct.CurrentRow.Cells[0].Value.ToString(), this);
            Fa.panel2.Controls.Add(p);
            p.Show();
            this.Visible = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            UCProductEdit p = new UCProductEdit(this);
            Fa.panel2.Controls.Add(p);
            this.Visible = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string id = this.dgvproduct.CurrentRow.Cells[0].Value.ToString();
            string name = this.dgvproduct.CurrentRow.Cells["name"].Value.ToString();


            this.Sql = @"delete from product
                where code = '" + id + "'; ";

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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (this.txtsearch.Text == "" || this.txtsearch.Text == "Enter Name")
            {
                MessageBox.Show("please,write the Product Name");
            }
            else
            {
                this.Sql = "select * from product where name ='" + this.txtsearch.Text + "';";
                this.PopulateGridView(this.Sql);
            }
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text == "Enter Name")
            {
                this.txtsearch.Text = "";
                this.txtsearch.ForeColor = Color.Black;
            }
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                this.txtsearch.Text = "Enter Name";
                this.txtsearch.ForeColor = Color.DimGray;
            }
        }
    }
}



    

