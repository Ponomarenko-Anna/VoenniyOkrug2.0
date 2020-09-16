using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoenniyOkrug.Forms
{
    public partial class Register : Form
    {
        private Control.RegisterControl.RegisterControl control;

        public Register()
        {
            InitializeComponent();
            control = new Control.RegisterControl.RegisterControl();
            tbLogin.MaxLength = 30;
            
        }

        private void butonLogin_Click(object sender, EventArgs e)
        {
            String login = tbLogin.Text;
            String password = tbPassword.Text;
            String repeatedPassword = tbReapeatedPassword.Text;

            if (password == "" || login == "") {
                MessageBox.Show("Заполните поля");
            } else if(password.Length > 30 || login.Length > 30) {
                MessageBox.Show("Слишком длинный логин или пароль");
            } else if (password != repeatedPassword) {
                MessageBox.Show("Пароли не совпадают");
            } else if (!control.IsLoginFree(login)) {
                MessageBox.Show("Этот логин занят,выберете пожалуйста другой");
            } else  {
                try
                {
                    control.CreateUser(login, password);
                    MessageBox.Show("Вы успешно зарегестрировались!");
                    this.Hide();
                    Alter Form = new Alter();
                    Form.Show();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.InnerException.InnerException.ToString());
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (tbPassword.Text.Length > 30)
            {
                e.Handled = false;
            }

        }

        private void tbReapeatedPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (tbReapeatedPassword.Text.Length > 30)
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
