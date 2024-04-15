namespace Hotel
{
    partial class SignInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonSignIn = new Button();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            textBoxPort = new TextBox();
            textBoxIpAddress = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(85, 81);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(301, 27);
            textBoxLogin.TabIndex = 0;
            textBoxLogin.TextChanged += textBoxLogin_TextChanged;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(85, 171);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(301, 27);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.TextChanged += textBoxPassword_TextChanged;
            // 
            // buttonSignIn
            // 
            buttonSignIn.Enabled = false;
            buttonSignIn.Location = new Point(85, 253);
            buttonSignIn.Name = "buttonSignIn";
            buttonSignIn.Size = new Size(301, 61);
            buttonSignIn.TabIndex = 2;
            buttonSignIn.Text = "Войти";
            buttonSignIn.UseVisualStyleBackColor = true;
            buttonSignIn.Click += buttonSignIn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 58);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 3;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 148);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxPort);
            groupBox1.Controls.Add(textBoxIpAddress);
            groupBox1.Location = new Point(439, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(285, 185);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Сервер";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 105);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 3;
            label4.Text = "Порт:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 31);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 2;
            label3.Text = "IP адрес:";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(50, 128);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.PlaceholderText = "1234";
            textBoxPort.Size = new Size(182, 27);
            textBoxPort.TabIndex = 1;
            textBoxPort.TextChanged += textBoxPort_TextChanged;
            // 
            // textBoxIpAddress
            // 
            textBoxIpAddress.Location = new Point(50, 54);
            textBoxIpAddress.Name = "textBoxIpAddress";
            textBoxIpAddress.PlaceholderText = "127.0.0.1";
            textBoxIpAddress.Size = new Size(182, 27);
            textBoxIpAddress.TabIndex = 0;
            textBoxIpAddress.TextChanged += textBoxIpAddress_TextChanged;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 353);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSignIn);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SignInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonSignIn;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox textBoxPort;
        private TextBox textBoxIpAddress;
        private Label label4;
        private Label label3;
    }
}