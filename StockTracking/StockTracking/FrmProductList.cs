using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.BLL;
using StockTracking.DAL.DTO;
namespace StockTracking
{
    public partial class FrmProductList : Form
    {
        public FrmProductList()
        {
            InitializeComponent();
        }

        private void rbPriceMore_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
            CleanFilters();
        }
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        private void FrmProductList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Producto";
            dataGridView1.Columns[1].HeaderText = "Categoría";
            dataGridView1.Columns[2].HeaderText = "Cantidad de stock";
            dataGridView1.Columns[3].HeaderText = "Precio";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.Products;
            if (!string.IsNullOrEmpty(txtProductName.Text))
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
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
            if (!string.IsNullOrEmpty(txtStock.Text))
            {
                if (rbStockEqual.Checked)
                    list = list.Where(x => x.StockAmount == Convert.ToInt32(txtStock.Text)).ToList();
                else if (rbStockMore.Checked)
                    list = list.Where(x => x.StockAmount > Convert.ToInt32(txtStock.Text)).ToList();
                else if (rbStockLess.Checked)
                    list = list.Where(x => x.StockAmount < Convert.ToInt32(txtStock.Text)).ToList();
                else
                    MessageBox.Show("Seleccione un criterio del grupo de stock!");
            }
            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            txtStock.Clear();
            cmbCategory.SelectedIndex = -1;
            rbPriceEqual.Checked = false;
            rbPriceMore.Checked = false;
            rbPriceLess.Checked = false;

            rbStockEqual.Checked = false;
            rbStockMore.Checked = false;
            rbStockLess.Checked = false;
            dataGridView1.DataSource = dto.Products;
        }
        ProductDetailDTO detail = new ProductDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ProductDetailDTO();
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Seleccione un producto de la tabla!");
            else
            {
                FrmProduct frm = new FrmProduct();
                frm.isUpdate = true;
                frm.detail = detail;
                frm.dto = dto;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new ProductBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Products;
                CleanFilters();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Seleccione un producto de la tabla!");
            else
            {
                DialogResult result = MessageBox.Show("¿Estás seguro/a?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("El producto se borró correctamente!");
                        bll = new ProductBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Products;
                        cmbCategory.DataSource = dto.Categories;
                        CleanFilters();
                    }
                }
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro/a?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string filepath = ConfigurationManager.AppSettings["FilePathExportCSV"];
                string filename = "export.csv";
                string filefullpath = filepath + "/" + filename;
                string delimiter = ";";
                bll = new ProductBLL();
                dto = bll.Select(1);
                
                try
                {
                    FileStream fs = new FileStream(@filefullpath, FileMode.OpenOrCreate, FileAccess.Write);   // 1er parametro: Path *** 2do parametro: Controlar si el fichero existe o no *** 3er parametro: Acceso 
                    StreamWriter sw = new StreamWriter(fs);
                    //primera linea
                    sw.WriteLine("PRODUCTO"+ delimiter+ "CATEGORIA"+ delimiter + "STOCK" + delimiter + "PRECIO");
                    foreach (var item in dto.Products)
                    {
                        sw.WriteLine(item.ProductName + delimiter + item.CategoryName + delimiter + item.StockAmount + delimiter + item.Price);

                    }
                    MessageBox.Show("Se escribió satisfactoriamente");
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
         
        }
    }
}
