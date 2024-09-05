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
    public partial class UCProductEdit : UserControl
    {
        private UCProduct up { set; get; }
        private DataTable Dt { get; set; }
        private DataSet Ds { get; set; }

        private DataAccess Da { get; set; }
        string Sql { set; get; }
        public UCProductEdit()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.GenerateID();           
        }

        public UCProductEdit(string id, UCProduct p) : this()
        {
            this.txtpcode.Text = id;
            this.up = p;
            this.ShowDetails();
            this.btnsave.Visible = false;
            this.btnsave.Enabled = false;
        }
        public UCProductEdit(UCProduct p) : this()
        {
            this.up = p;
            this.ShowDetails();
            this.GenerateID();
            this.txtpcode.ReadOnly = true;
            this.btnupdate.Visible = false;
            this.btnupdate.Enabled = false;
        }

        public void ShowDetails()
        {
            this.Sql = @"select * from product where code = '" + this.txtpcode.Text + "';";
            this.Dt = Da.ExecuteQueryTable(this.Sql);
            if (this.Dt.Rows.Count == 1)
            {
                this.txtpcode.Text = this.Dt.Rows[0]["code"].ToString();
                this.txtpname.Text = this.Dt.Rows[0]["name"].ToString();
                this.dtpuploaddate.Text = this.Dt.Rows[0]["uploaddate"].ToString();
                this.txtpprice.Text = this.Dt.Rows[0]["price"].ToString();
                this.txtpquantity.Text = this.Dt.Rows[0]["quantity"].ToString();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if ( this.txtpname.Text == "" || this.dtpuploaddate.Text == "" || this.txtpprice.Text == "" || this.txtpquantity.Text == "")
            {
                MessageBox.Show("Please, Fill up all the field");
            }
            else
            {
                this.Sql = @"insert into product
             values('" + this.txtpcode.Text + "', '" + this.txtpname.Text + "', '" + this.dtpuploaddate.Text + "', " + this.txtpprice.Text + ", '" + this.txtpquantity.Text + "'); ";

                int count = Da.ExecuteUpdateQuery(this.Sql);
                if (count == 1)
                {
                    MessageBox.Show("Data Inserted");
                    this.ClearAll();

                }
                else
                {
                    MessageBox.Show("Data Insertion failed");
                }

                this.ShowDetails();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            up.Visible = true;
        }

        public void GenerateID()
        {
            this.Sql = "select * from product order by code desc;";

            this.Dt = this.Da.ExecuteQueryTable(this.Sql);
            string id = Dt.Rows[0]["code"].ToString();

            string[] str = id.Split('p');
            int num = Convert.ToInt32(str[1]);
            string newId = 'p' + (++num).ToString("d3");

            this.txtpcode.Text = newId;
            this.txtpcode.ReadOnly = true;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            this.Sql = @"update product
            set name= '" + this.txtpname.Text + @"',
            uploaddate = '" + this.dtpuploaddate.Text + @"', 
            price = " + this.txtpprice.Text + @",
            quantity='" + this.txtpquantity.Text + @"'
            where code = '" + this.txtpcode.Text + @"';";

            int count = this.Da.ExecuteUpdateQuery(this.Sql);
            if (count == 1)
            {
                MessageBox.Show(" Data updated");
                this.Visible = false;
                up.Show();
            }
            else
            {
                MessageBox.Show("Data updated failed");
            }
        }

        public void ClearAll()
        {
            this.txtpcode.Clear();
            this.txtpname.Clear();
            this.dtpuploaddate.Text = "";
            this.txtpprice.Clear();
            this.txtpquantity.Clear();
            this.GenerateID();
        }
    }
}



