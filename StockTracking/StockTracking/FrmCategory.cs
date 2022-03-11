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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("El campo categoría está vacío");
            }
            else
            {
                if (!isUpdate) // Añadir categoría
                {
                    CategoryDetailDTO category = new CategoryDetailDTO();
                    category.CategoryName = txtCategoryName.Text;
                    if (bll.Insert(category))
                    {
                        MessageBox.Show("La categoría se añadió correctamente!");
                        txtCategoryName.Clear();
                    }
                }
                else if (isUpdate)
                {
                    if (detail.CategoryName == txtCategoryName.Text.Trim())
                        MessageBox.Show("No existe ningún cambio");
                    else
                    {
                        detail.CategoryName = txtCategoryName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("La categoría se actualizó correctamente!");
                            this.Close();
                        }
                    }
                   
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        CategoryBLL bll = new CategoryBLL();
        public CategoryDetailDTO detail = new CategoryDetailDTO();
        public bool isUpdate = false;
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtCategoryName.Text = detail.CategoryName;
        }
    }
}
