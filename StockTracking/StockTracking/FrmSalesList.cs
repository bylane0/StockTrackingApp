using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.BLL;
using StockTracking.DAL.DTO;
namespace StockTracking
{
    public partial class FrmSalesList : Form
    {
        public FrmSalesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
        SalesBLL bll = new SalesBLL();
        SalesDTO dto = new SalesDTO(); 
        SalesDetailDTO detail = new SalesDetailDTO();
        private void FrmSalesList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            dataGridView1.Columns[0].HeaderText = "Cliente";
            dataGridView1.Columns[1].HeaderText = "Producto";
            dataGridView1.Columns[2].HeaderText = "Categoría";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Cantidad de ventas";
            dataGridView1.Columns[7].HeaderText = "Precio";
            dataGridView1.Columns[8].HeaderText = "Fecha de venta";
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            CleanFilters();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.Sales;
            if (!string.IsNullOrEmpty(txtProductName.Text))
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            if (!string.IsNullOrEmpty(txtCustomerName.Text))
                list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
            if (cmbCategory.SelectedIndex != -1)
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();

            if (!string.IsNullOrEmpty(txtPrice.Text))
            {
                if (rbPriceEqual.Checked)
                    list = list.Where(x => x.Price == Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbPriceMore.Checked)
                    list = list.Where(x => x.Price > Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbPriceLess.Checked)
                    list = list.Where(x => x.Price < Convert.ToInt32(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Seleccione un criterio del grupo de precios!");
            }
            if (!string.IsNullOrEmpty(txtSalesAmount.Text))
            {
                if (rbSalesEqual.Checked)
                    list = list.Where(x => x.SalesAmount == Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (rbSalesMore.Checked)
                    list = list.Where(x => x.SalesAmount > Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (rbSalesLess.Checked)
                    list = list.Where(x => x.SalesAmount < Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else
                    MessageBox.Show("Seleccione un criterio del grupo de cantidad de ventas!");
            }
            if(chDate.Checked)
                list = list.Where( x => x.SalesDate >= dpStart.Value && x.SalesDate <= dpEnd.Value).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtCustomerName.Clear();
            txtProductName.Clear();
            txtSalesAmount.Clear();
            rbPriceEqual.Checked = false;
            rbPriceMore.Checked = false;
            rbPriceLess.Checked = false;
            rbSalesEqual.Checked = false;
            rbSalesMore.Checked = false;
            rbSalesLess.Checked = false;
            dpStart.Value = DateTime.Today;
            dpEnd.Value = DateTime.Today;
            chDate.Checked = false;
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Sales;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new SalesDetailDTO();
            detail.SalesID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detail.SalesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.SalesID == 0)
                MessageBox.Show("Seleccione una venta de la tabla!");
            else
            {
                FrmSales frm = new FrmSales();
                frm.isUpdate = true;
                frm.detail = detail;
                frm.dto = dto;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new SalesBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Sales;
                CleanFilters();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(detail.SalesID == 0)
                MessageBox.Show("Seleccione una venta de la tabla!");
            else
            {
                DialogResult result = MessageBox.Show("¿Estás seguro/a?", "Advertencia", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("La venta se borró correctamente!");
                        bll = new SalesBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Sales;
                        CleanFilters();
                    }
                }
            }
        }
    }
}
