using StockTracking.BLL;
using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (!isUpdate)
                {
                    UserDetailDTO user = new UserDetailDTO();
                    user.UserName = txtUser.Text;
                    string passwordHash = General.cifrar(txtPassword.Text);
                    user.UserPassword = passwordHash;
                    user.PermissionType = Convert.ToInt32(cmbPermission.SelectedValue);
                    user.Email = txtEmail.Text;
                    user.PhoneNumber = txtPhone.Text;
                    if (bll.Insert(user))
                    {
                        MessageBox.Show("El usuario se añadió correctamente!");
                        CleanFilters();
                    }
                }
                else
                {
                    if (detail.UserName == txtUser.Text &&
                     detail.PermissionType == Convert.ToInt32(cmbPermission.SelectedValue) &&
                     detail.UserPassword == txtPassword.Text && detail.Email == txtEmail.Text && 
                     detail.PhoneNumber == txtPhone.Text)
                    {
                        MessageBox.Show("No existe ningún cambio!");
                    }
                    else
                    {
                        detail.UserName = txtUser.Text;
                        detail.PermissionType = Convert.ToInt32(cmbPermission.SelectedValue);
                        string passwordHash = General.cifrar(txtPassword.Text);
                        detail.UserPassword = passwordHash;
                        detail.Email = txtEmail.Text;
                        detail.PhoneNumber = txtPhone.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("El usuario se actualizó correctamente!");
                            this.Close();

                        }
                    }
                }
               
            }
        }

        private void CleanFilters()
        {
            txtPassword.Clear();
            txtUser.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
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
            else if (!ValidatePassword(txtPassword.Text))
                message += "Password debe ser alfanumerica, contener al menos 1 mayuscula y menos de 10 caracteres totales" + Environment.NewLine;
            if (cmbPermission.SelectedIndex == -1)
                message += "Seleccione un permiso existente" + Environment.NewLine;
            if (!ValidateEmail(txtEmail.Text))
                message += "El email ingresado no es correcto" + Environment.NewLine;
            if (!ValidatePhone(txtPhone.Text))
                message += "El número de celular ingresado no es correcto" + Environment.NewLine;
            return message;
        }
        private bool ValidatePassword(string password)
        {
            /*
           La contraseña debe tener entre 3 y 10 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula.
           NO puede tener otros símbolos.
            */
            var regexPass = @"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{3,10}$";
            var temp = Regex.IsMatch(password, regexPass);
            return temp;
        }

        private bool ValidatePhone(string phoneNumber)
        {
            var regexPhone = @"^(\+)?(\d{1,2})?[( .-]*(\d{3})[) .-]*(\d{3,4})[ .-]?(\d{4})$";
            var temp = Regex.IsMatch(phoneNumber, regexPhone);
            return temp;
        }
        private bool ValidateEmail(string email)
        {
            string regexEmail = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, regexEmail))
            {
                if (Regex.Replace(email, regexEmail, String.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        UserBLL bll = new UserBLL();
        public UserDTO dto = new UserDTO();
        public UserDetailDTO detail = new UserDetailDTO();
        public bool comboFull = false;
        public bool isUpdate = false;

        private void cmbPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            cmbPermission.DataSource = dto.Permissions;
            cmbPermission.DisplayMember = "PermissionName";
            cmbPermission.ValueMember = "ID";
            cmbPermission.SelectedIndex = -1;
            if (isUpdate)
            {
                txtUser.Text = detail.UserName;
                txtPassword.Text = detail.UserPassword;
                cmbPermission.SelectedValue = detail.PermissionType;
                txtPhone.Text = detail.PhoneNumber;
                txtEmail.Text = detail.Email;

            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
    }
}
