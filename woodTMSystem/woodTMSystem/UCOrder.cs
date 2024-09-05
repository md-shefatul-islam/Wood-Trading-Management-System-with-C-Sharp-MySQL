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
    public partial class UCOrder : UserControl
    {
        private FormDashBoardUser du { set; get; }

        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }

        private DataTable Dt { get; set; }
        //private FormLogin fl { set; get; }
        private string Sql { set; get; }
        private string newID { set; get; }
        private string LoginId { set; get; }
        private Panel pl;
        public UCOrder()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.GenerateID();
        }
        public UCOrder(Panel p,FormDashBoardUser du) : this()
        {
            this.du = du;
            this.pl = p;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            pl.Visible = true;
            du.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }      
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        private void PopulateGridView()
        {
            try
            {
                this.Sql = "select * from orderlist where  customerid = '" + FormLogin.ID + "';";
                //this.Ds = this.Da.ExecuteQuery(Sql);
                this.Dt = this.Da.ExecuteQueryTable(Sql);

                this.dgvOrderHistory.AutoGenerateColumns = false;
                //this.dgvinfo.DataSource = this.Ds.Tables[0];
                this.dgvOrderHistory.DataSource = this.Dt;
                this.dgvOrderHistory.ClearSelection();
                this.GenerateID();
            }catch(Exception e)
            {
                MessageBox.Show("An exception occured in"+e);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dt = this.Da.ExecuteQueryTable("select * from product where name = '"+this.cmbproduct.Text+"'");
            this.txtpname.Text = this.cmbproduct.Text;
            this.txtquantity.Text = this.txtquantitycp.Text;
            this.txtpricepunit.Text = this.Dt.Rows[0]["price"].ToString();
            this.dtpdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txttotal.Text= ((Int32.Parse(this.txtpricepunit.Text))*(Int32.Parse(this.txtquantitycp.Text))).ToString();

            }
            catch (Exception ae)
            {
                MessageBox.Show("An exception occured in ok of ucproduct" + ae);
            }
        }

        private void btnrefreshpo_Click(object sender, EventArgs e)
        {
            this.txtpname.Clear();
            this.txtquantity.Clear();
            this.txtpricepunit.Clear();
            this.dtpdate.Text = "";
            this.txttotal.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            this.txtpname.Clear();
            this.txtquantity.Clear();
            this.txtpricepunit.Clear();
            this.txttotal.Clear();
            this.txtquantitycp.Clear();
            this.cmbproduct.SelectedIndex= -1;
            
        }

       

        public void GenerateID()
        {
            try
            {
                this.Sql = "select * from orderlist order by no desc;";

                this.Dt = this.Da.ExecuteQueryTable(this.Sql);
                string id = Dt.Rows[0]["no"].ToString();

                string[] str = id.Split('-');

                int num = Convert.ToInt32(str[1]);

                this.newID = "o-" + (++num).ToString("d3");
            }


            catch (Exception ae)
            {
                MessageBox.Show("An exception occured in generate id of ucorder" + ae);
            }
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            try
            {


                if (this.cmbproduct.Text == "" && this.txtquantitycp.Text == "")
                {
                    MessageBox.Show("Choose the product and fillup the Quantity");

                }
                else
                {
                    this.Dt = this.Da.ExecuteQueryTable("select * from product where name = '" + this.cmbproduct.Text + "';");
                    int ammount = Int32.Parse(this.Dt.Rows[0]["quantity"].ToString());
                    int required = Int32.Parse(this.txtquantity.Text);
                    if (ammount >= required)
                    {
                        string time = DateTime.Now.ToString("hh:mm:ss");
                        this.Sql = @"insert into orderlist
values('" + this.newID + "', '" + FormLogin.ID + "', '" + this.txtpname.Text + "',' " + this.dtpdate.Text + "', '" + time + "','" + this.txtquantity.Text + "', '" + this.txttotal.Text + "'); ";
                        int count = this.Da.ExecuteUpdateQuery(this.Sql);
                        if (count == 1)
                        {
                            MessageBox.Show("Order successfully Placed");
                            ammount -= required;
                            this.Da.ExecuteUpdateQuery(@"update product
                                     set quantity= '" + ammount + @"'
                                     where name = '" + this.txtpname.Text + "';");
                        }
                        else
                        {
                            MessageBox.Show("Order Placed failed, Try again.....");
                        }
                        this.PopulateGridView();
                    }
                    else
                    {
                        MessageBox.Show("Invalid order. Please, choose beyond availability");

                    }
                }
            }
            catch (Exception ae)
            {
                MessageBox.Show("An exception occured in confirm of ucorder" + ae);
            }
        }

       
    }
}
