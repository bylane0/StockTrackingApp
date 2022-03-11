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
    public partial class FrmDeleted : Form
    {
        public FrmDeleted()
        {
            InitializeComponent();
        }
        SalesDTO dto = new SalesDTO();
        SalesBLL bll = new SalesBLL();
        private void FrmDeleted_Load(object sender, EventArgs e)
        {
            cmbDeletedData.Items.Add("Categorías");
            cmbDeletedData.Items.Add("Clientes");
            cmbDeletedData.Items.Add("Productos");
            cmbDeletedData.Items.Add("Ventas");
            dto = bll.Select(true);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SalesDetailDTO salesdetail = new SalesDetailDTO();
        ProductDetailDTO productdetail = new ProductDetailDTO();
        CategoryDetailDTO categorydetail = new CategoryDetailDTO();
        CustomerDetailDTO customerdetail = new CustomerDetailDTO();

        ProductBLL productBLL = new ProductBLL();
        CategoryBLL categoryBLL = new CategoryBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        SalesBLL salesBLL = new SalesBLL();
        private void cmbDeletedData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDeletedData.SelectedIndex ==0) // CATEGORIAS
            {
                dataGridView1.DataSource = dto.Categories;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nombre de la categoría";
            } 
            else if(cmbDeletedData.SelectedIndex ==1) // CLIENTES
            {
                dataGridView1.DataSource = dto.Customers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nombre del cliente";
            }
            else if(cmbDeletedData.SelectedIndex ==2) // PRODUCTOS
            {
                dataGridView1.DataSource = dto.Products;
                dataGridView1.Columns[0].HeaderText = "Producto";
                dataGridView1.Columns[1].HeaderText = "Categoría";
                dataGridView1.Columns[2].HeaderText = "Cantidad de stock";
                dataGridView1.Columns[3].HeaderText = "Precio";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
            else if(cmbDeletedData.SelectedIndex ==3) // VENTAS
            {
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

            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(cmbDeletedData.SelectedIndex== 0) // CATEGORIAS
            {
                categorydetail = new CategoryDetailDTO();
                categorydetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                categorydetail.CategoryName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeletedData.SelectedIndex == 1) // CLIENTES
            {
                customerdetail = new CustomerDetailDTO();
                customerdetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                customerdetail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeletedData.SelectedIndex == 2) // PRODUCTOS
            {
                productdetail = new ProductDetailDTO();
                productdetail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                productdetail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                productdetail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                productdetail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                productdetail.isCategoryDeleted=Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            }
            else if (cmbDeletedData.SelectedIndex == 3) // VENTAS
            {
                salesdetail = new SalesDetailDTO();
                salesdetail.SalesID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                salesdetail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                salesdetail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                salesdetail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                salesdetail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                salesdetail.SalesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                salesdetail.isCategoryDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
                salesdetail.isCustomerDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
                salesdetail.isProductDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            }
        }

        private void btnGetBack_Click(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0) // CATEGORIAS
            {
                if (categoryBLL.GetBack(categorydetail))
                {
                    MessageBox.Show("La categoría se recuperó correctamente!");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Categories;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 1) // CLIENTES
            {
                if (customerBLL.GetBack(customerdetail))
                {
                    MessageBox.Show("El cliente se recuperó correctamente!");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Customers;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 2) // PRODUCTOS
            {
                if (productdetail.isCategoryDeleted)
                    MessageBox.Show("La CATEGORÍA de este producto está eliminada, es necesario que la recuperes antes");
                else if (productBLL.GetBack(productdetail))
                {
                    MessageBox.Show("El producto se recuperó correctamente!");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Products;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 3) // VENTAS
            {
                if (salesdetail.isCategoryDeleted || salesdetail.isCustomerDeleted || salesdetail.isProductDeleted)
                {
                    string message = "";
                    if(salesdetail.isCategoryDeleted)
                        message += "La CATEGORÍA de esta venta está eliminada, es necesario que la recuperes antes" + Environment.NewLine;
                    if(salesdetail.isCustomerDeleted)
                        message += "El CLIENTE de esta venta está eliminado, es necesario que lo recuperes antes" + Environment.NewLine;
                    if(salesdetail.isProductDeleted)
                        message += "El PRODUCTO de esta venta está eliminado, es necesario que lo recuperes antes" + Environment.NewLine;
                    MessageBox.Show(message);
                }
                else if (salesBLL.GetBack(salesdetail))
                {
                    MessageBox.Show("La venta se recuperó correctamente!");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Sales;
                }
            }
            
        }
    }
}
