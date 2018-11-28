using RhApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhApp
{
    public partial class Login : Form
    {
        private RhDataService _rhDataService;
        private UserCredential _user;

        public Login(RhDataService rhDataService)
        {
            InitializeComponent();
            _rhDataService = rhDataService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _user = _rhDataService.GetAll<UserCredential>().FirstOrDefault(i => i.PassWord == txtPassWord.Text && i.UserName == txtUserName.Text);

            if(_user == null)
            {
                MessageBox.Show("El usuario no fue encontrado, favor revisar su contraseña o su nombre de usuario");
            }
            else
            {
                var frm = new Main(_rhDataService, _user, this);
                frm.Show();
                this.Visible = false;

                txtUserName.Text = "";
                txtPassWord.Text = "";
            }

            //var frm = new Main(_rhDataService, _user, this);
            //frm.Show();
            //this.Visible = false;
        }
    }
}
