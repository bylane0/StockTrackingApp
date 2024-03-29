﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using StockTracking.DAL.DAO;
using System.IO;
using System.Configuration;

namespace StockTracking
{
    public partial class FrmCustomerList : Form
    {

        public FrmCustomerList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomer frm = new FrmCustomer();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

            dto = bll.Select();
            dataGridView1.DataSource = dto.Customers;
        }
        CustomerDTO dto = new CustomerDTO();
        CustomerBLL bll = new CustomerBLL();

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Customers;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre del cliente";
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
            dataGridView1.DataSource = list;
        }
        CustomerDetailDTO detail = new CustomerDetailDTO();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Seleccione un cliente de la tabla!");
            else
            {
                FrmCustomer frm = new FrmCustomer();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new CustomerBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Customers;


            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new CustomerDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Seleccione un cliente de la tabla!");
            else
            {
                DialogResult result = MessageBox.Show("¿Estás seguro/a?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("El cliente se borró correctamente!");
                        bll = new CustomerBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Customers;
                        txtCustomerName.Clear();
                    }
                }
            }
        }

        private void btnCsv_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Estás seguro/a?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string filepath = ConfigurationManager.AppSettings["FilePathImportCSV"];
                string filename = "demo.csv";
                string filefullpath = filepath + "/" + filename;
                int contador = 1;
                try
                {
                    string[] lineas = File.ReadAllLines(filefullpath);
                    foreach (var linea in lineas)
                    {
                        var valores = linea.Split(',');

                        if (string.IsNullOrEmpty(valores[0]))
                            MessageBox.Show("El campo 'Nombre del cliente' está vacío!");
                        else
                        {
                            CustomerDetailDTO customer = new CustomerDetailDTO();
                            customer.CustomerName = valores[0];
                            if (bll.Insert(customer))
                            {
                                MessageBox.Show("El cliente " + contador + " se añadió correctamente!");
                                contador++;

                                dto = bll.Select();
                                dataGridView1.DataSource = dto.Customers;
                            }
                        }

                        //MessageBox.Show("El nombre es: " + valores[0] +
                        //    "\n con un valor de: " + valores[1]);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El archivo no existe o la ruta indicada es incorrecta");
                    MessageBox.Show(filefullpath);
                }

            }

        }
    }
}
