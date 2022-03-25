using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FrmSalesList frm = new FrmSalesList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FrmProductList frm = new FrmProductList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            FrmCustomerList frm = new FrmCustomerList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            FrmAddStock frm = new FrmAddStock();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategoryList frm = new FrmCategoryList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            FrmDeleted frm = new FrmDeleted();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

  

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
           
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
       

            if(UserStatic.PermissionName.Equals("Vendedor"))
            {
                btnAddStock.Hide();
                btnCategory.Hide();
                btnProducts.Hide();
                btnCustomers.Hide();
                btnDeleted.Hide();
                btnAddUser.Hide();
      
                btnSales.Location = new Point(12, 12);
                btnSales.Size = new Size(405, 238);
                btnExit.Location = new Point(12, 256);
                btnExit.Size = new Size(405, 116);
            }
            else if (UserStatic.PermissionName.Equals("Reponedor"))
            {
                btnProducts.Size = new Size(408, 116);
                btnProducts.Location = new Point(12, 12);
                btnCategory.Location = new Point(81, 134);
                btnAddStock.Location = new Point(218, 134);
                btnSales.Hide();
                btnCustomers.Hide();
                btnDeleted.Hide();
                btnAddUser.Hide();
                btnExit.Location = new Point(12, 256);
                btnExit.Size = new Size(405, 116);
            }
            else if(UserStatic.PermissionName.Equals("Comercial"))
            {
                btnProducts.Size = new Size(408, 116);
                btnProducts.Location = new Point(12, 12);
                btnCustomers.Location = new Point(12, 134);
                btnCustomers.Size = new Size(408, 116);
                btnExit.Location = new Point(149, 256);
                btnSales.Hide();
                btnCategory.Hide();
                btnDeleted.Hide();
                btnAddUser.Hide();
                btnAddStock.Hide();
                btnExit.Location = new Point(12, 256);
                btnExit.Size = new Size(408, 116);
            }
            else if(UserStatic.PermissionName.Equals("RR HH"))
            {
                btnAddUser.Location = new Point(12, 12);
                btnAddUser.Size = new Size(405, 238);
                btnExit.Location = new Point(12, 256);
                btnExit.Size = new Size(408, 116);
                btnAddStock.Hide();
                btnCategory.Hide();
                btnProducts.Hide();
                btnCustomers.Hide();
                btnDeleted.Hide();
              
                btnSales.Hide();

            }
            
          
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmUserList frm = new FrmUserList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
