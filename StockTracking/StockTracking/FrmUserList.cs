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
    public partial class FrmUserList : Form
    {
        public FrmUserList()
        {
            InitializeComponent();
        }
        UserBLL bll = new UserBLL();
        UserDTO dto = new UserDTO();

        private void FrmUserList_Load(object sender, EventArgs e)
        {
            FillAllData();

        }

        private void FillAllData()
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Users;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Permiso";
            dataGridView1.Columns[5].HeaderText = "Email";
            dataGridView1.Columns[6].HeaderText = "Número de celular";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<UserDetailDTO> list = dto.Users;
            if (!string.IsNullOrEmpty(txtUser.Text))
                list = list.Where(x => x.UserName.Contains(txtUser.Text)).ToList();
            if (!string.IsNullOrEmpty(txtPermission.Text))
                list = list.Where(x => x.PermissionName.Contains(txtPermission.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();

        }

        private void CleanFilters()
        {
            txtUser.Clear();
            txtPermission.Clear();
            dataGridView1.DataSource = dto.Users;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmUser frm = new FrmUser();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            CleanFilters();
            FillAllData();
        }
        UserDetailDTO detailuser = new UserDetailDTO();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detailuser.UserID == 0)
                MessageBox.Show("Seleccione un usuario de la tabla!");
            else
            {
                FrmUser frm = new FrmUser();
                frm.detail = detailuser;
                frm.isUpdate = true;
                dto = bll.Select();
                frm.dto = dto;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new UserBLL();
                CleanFilters();
                FillAllData();


            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detailuser = new UserDetailDTO();
            detailuser.UserID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detailuser.UserName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string passHash = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detailuser.UserPassword = General.descifrar(passHash);
            detailuser.PermissionType = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detailuser.Email = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            detailuser.PhoneNumber = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();





        }
    }
}
