using StockTracking.BLL;
using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FrmAutocomplete : Form
    {
        public FrmAutocomplete()
        {
            InitializeComponent();
        }
        AutocompleteBLL bll = new AutocompleteBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = ValidateForm();
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message);
            else
            {
                AutocompleteDetailDTO detail = new AutocompleteDetailDTO();
                detail.customerName = txtCustomerName.Text;
                detail.categoryName = txtCategoryName.Text;
                detail.productName = txtProductName.Text;
                detail.stockAmount = Convert.ToInt32(txtStockAmount.Text);
                detail.price = Convert.ToInt32(txtPrice.Text);
                if (bll.Insert(detail))
                {
                    MessageBox.Show("La información se añadió correctamente!");
                    
                }
            }
        }

        private string ValidateForm()
        {
            string message = String.Empty;

            if (string.IsNullOrEmpty(txtCustomerName.Text))
                message += "El campo nombre de usuario está vacío" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtCategoryName.Text))
                message += "El campo nombre de categoría está vacío" + Environment.NewLine;
            else if (string.IsNullOrEmpty(txtProductName.Text))
                message += "El campo nombre de producto está vacío" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtStockAmount.Text))
                message += "El campo cantidad de stock está vacío" + Environment.NewLine;
            else if (Convert.ToInt32(txtStockAmount.Text) < 0)
                message += "El campo cantidad de stock debe ser mayor a 0" + Environment.NewLine;
            if (string.IsNullOrEmpty(txtPrice.Text))
                message += "El campo precio está vacío" + Environment.NewLine;
            return message;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}