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
using StockTracking.DAL;
using StockTracking.DAL.DTO;

namespace StockTracking
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        UserBLL bll = new UserBLL();
        UserDTO dto = new UserDTO();
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if ( string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("El usuario o la contraseña se encuentran vacías");
            }
            else
            {

                UserDetailDTO detail = new UserDetailDTO();
                detail.UserName = txtUser.Text;
                string passwordHash = General.cifrar(txtPassword.Text);
                detail.UserPassword = passwordHash;

                dto = bll.Select(detail);

            
                if (dto.Users.Count == 0)
                {
                    MessageBox.Show("El usuario o password son incorrectos");
                }
                else
                {
                    UserDetailDTO user = dto.Users[0]; 
                
                    UserStatic.UserID = user.UserID;
                    UserStatic.UserName = user.UserName;
                    UserStatic.PermissionType = user.PermissionType;
                    UserStatic.PermissionName = user.PermissionName;
                    FrmStockAlert frm = new FrmStockAlert();
                    this.Hide();
                    frm.ShowDialog();

                }



            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
