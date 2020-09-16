using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoenniyOkrug
{
    public partial class Login : Form
    {
        private Control.LoginControl.LoginControl control;
        public Login()
        {
            InitializeComponent();
            control = new Control.LoginControl.LoginControl();
            tbLogin.MaxLength = 30;
            
        }

        private void butonLogin_Click(object sender, EventArgs e)
        {
            String login = tbLogin.Text;
            String password = tbPassword.Text;
            int mode = control.tryLogin(login, password);
       
            switch (mode)
            {
                case 0:
                    {
                        MessageBox.Show("Пароль или логин неверные");
                        break;
                    }
                case 1:
                    {
                        this.Hide();
                        Queries queriesForm = new Queries();
                        queriesForm.Show();
                        break;
                    }
                case 2:
                    {
                         this.Hide();
                        Alter alterForm = new Alter();
                        alterForm.Show();
                        break;
                    }
            }
            }

        private void toRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.Register registerForm = new Forms.Register();
            registerForm.Show();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e) {

            char ch = e.KeyChar;

            if (tbPassword.Text.Length > 30)
            {
                e.Handled = false;
            }
        }

        private void tbLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (tbLogin.Text.Length > 30)
            {
                e.Handled = false;
            }
        }
    }
}
