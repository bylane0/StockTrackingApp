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
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
        public ProductDTO dto = new ProductDTO();
        public ProductDetailDTO detail = new ProductDetailDTO();
        public bool isUpdate = false;
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (isUpdate)
            {
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
                cmbCategory.SelectedValue = detail.CategoryID;

            }
        }
        ProductBLL bll = new ProductBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = ValidateForm();
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message);
            else
            {
                if (!isUpdate)
                {
                    ProductDetailDTO product = new ProductDetailDTO();
                    product.ProductName = txtProductName.Text;
                    product.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                    product.Price = Convert.ToInt32(txtPrice.Text);
                    if (bll.Insert(product))
                    {
                        MessageBox.Show("El producto se añadió correctamente!");
                        CleanFilters();
                    }
                }
                else
                {
                    if (detail.ProductName == txtProductName.Text &&
                        detail.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue) &&
                        detail.Price == Convert.ToInt32(txtPrice.Text))
                    {
                        MessageBox.Show("No existe ningún cambio!");
                    }
                    else
                    {
                        detail.ProductName = txtProductName.Text;
                        detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                        detail.Price = Convert.ToInt32(txtPrice.Text);
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("El producto se actualizó correctamente!");
                            this.Close();

                        }
                    }


                }

            }
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            cmbCategory.SelectedIndex = -1;
        }

        private string ValidateForm()
        {
            string message = string.Empty;
            if (string.IsNullOrEmpty(txtProductName.Text))
                message += "El campo 'Nombre del producto' está vacío" + Environment.NewLine;
            if (cmbCategory.SelectedIndex == -1)
                message += "Seleccione una categoría" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtPrice.Text))
                message += "El campo 'Precio' está vacío" + Environment.NewLine;
            return message;
        }
    }
}
