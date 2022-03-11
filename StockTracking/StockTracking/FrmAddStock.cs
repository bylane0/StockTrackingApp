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
    public partial class FrmAddStock : Form
    {
        public FrmAddStock()
        {
            InitializeComponent();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ProductBLL bll = new ProductBLL();
        public ProductDTO dto = new ProductDTO();
        public ProductDetailDTO detail = new ProductDetailDTO();
        public bool isAlert = false;

        private void FrmAddStock_Load(object sender, EventArgs e)
        {
            if (!isAlert)
            {
                labelAlert.Hide();
                txtAlertStock.Hide();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Products;
                dataGridView1.Columns[0].HeaderText = "Producto";
                dataGridView1.Columns[1].HeaderText = "Categoría";
                dataGridView1.Columns[2].HeaderText = "Cantidad de stock";
                dataGridView1.Columns[3].HeaderText = "Precio";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;

                cmbCategory.DataSource = dto.Categories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "ID";
                cmbCategory.SelectedIndex = -1;
                if (dto.Categories.Count > 0)
                    //Si existen categorías en el sistema(DB) se muestran
                    combofull = true;
            }
            else if (isAlert)
            {
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
                labelAlert.Show();
                txtAlertStock.Text = detail.StockAmount.ToString();
                txtAlertStock.Show();
                panel1.Hide();
            }

        }

        bool combofull = false;
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                dataGridView1.DataSource = list;
                if (list.Count == 0)
                {
                    CleanFilters();
                }
            }

        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            txtStock.Clear();
        }


        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = detail.ProductName;
            detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            txtPrice.Text = detail.Price.ToString();
            detail.StockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isAlert)
            {
                string message = ValidateForm();
                if (!string.IsNullOrEmpty(message))
                    MessageBox.Show(message);
                else
                {
                    int sumStock = detail.StockAmount;
                    sumStock += Convert.ToInt32(txtStock.Text);
                    detail.StockAmount = sumStock;
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("El stock se añadió correctamente!");
                        bll = new ProductBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Products;
                        CleanFilters();
                    }
                }
            }
            else if (isAlert)
            {
                if (string.IsNullOrEmpty(txtStock.Text))
                    MessageBox.Show("Introduce una cantidad de stock");
                else
                {
                    int sumStock = detail.StockAmount;
                    sumStock += Convert.ToInt32(txtStock.Text);
                    detail.StockAmount = sumStock;
                    detail.CategoryID = 0;
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("El stock se añadió correctamente!");
                        bll = new ProductBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Products;
                        this.Close();
                    }
                }

            }



        }

        private string ValidateForm()
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(txtProductName.Text))
                message += "Seleccione un producto de la tabla" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtStock.Text))
                message += "Introduce una cantidad de stock" + Environment.NewLine;
            return message;
        }
    }
}
