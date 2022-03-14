﻿using StockTracking.BLL;
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
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = ValidateForm();
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message);
            else
            {
                UserDetailDTO user = new UserDetailDTO();
                user.UserName = txtUser.Text;
                user.UserPassword = txtPassword.Text;
                user.PermissionType = Convert.ToInt32(cmbPermission.SelectedValue);

                if (bll.Insert(user))
                {
                    MessageBox.Show("El usuario se añadió correctamente!");
                    CleanFilters();
                }
            }
        }

        private void CleanFilters()
        {
            txtPassword.Clear();
            txtUser.Clear();
            cmbPermission.SelectedIndex = -1;
            cmbPermission.SelectedValue = 0;
        }

        private string ValidateForm()
        {
            string message = String.Empty;
            
            if (string.IsNullOrEmpty(txtUser.Text))
                message += "El campo de nombre de usuario está vacío" + Environment.NewLine;
            if(string.IsNullOrEmpty(txtPassword.Text))
                message += "El campo de contraseña está vacío" + Environment.NewLine;
            if (cmbPermission.SelectedIndex == -1)
                message += "Seleccione un permiso existente" + Environment.NewLine;
            return message;
        }


        UserBLL bll = new UserBLL();
        public UserDTO dto = new UserDTO();
        UserDetailDTO detail = new UserDetailDTO();
        public bool comboFull = false;
        private void cmbPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            cmbPermission.DataSource = dto.Permissions;
            cmbPermission.DisplayMember = "PermissionName";
            cmbPermission.ValueMember = "ID";
            cmbPermission.SelectedIndex = -1;
            
        }
    }
}