﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                InternalData.GetUserFromServer(textBoxLogin.Text, textBoxPassword.Text, textBoxIpAddress.Text, textBoxPort.Text);
                if (!InternalData.User.Equals(new User(string.Empty, -1)))
                {
                    InternalData.Initialization();
                    new MainForm().ShowDialog();
                    textBoxLogin.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            CheckingTextBoxes();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckingTextBoxes();
        }

        private void CheckingTextBoxes()
        {
            try
            {
                IPAddress.Parse(textBoxIpAddress.Text);
                int.Parse(textBoxPort.Text);
                if (textBoxLogin.Text != string.Empty && textBoxPassword.Text != string.Empty && textBoxPort.Text.Length == 4)
                {
                    buttonSignIn.Enabled = true;
                }
                else
                {
                    buttonSignIn.Enabled = false;
                }
            }
            catch
            {
                buttonSignIn.Enabled = false;
            }
        }

        private void textBoxIpAddress_TextChanged(object sender, EventArgs e)
        {
            CheckingTextBoxes();
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            CheckingTextBoxes();
        }
    }
}
