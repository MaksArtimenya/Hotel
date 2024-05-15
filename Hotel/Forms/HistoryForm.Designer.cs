namespace Hotel.Forms
{
    partial class HistoryForm
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
            listBoxShowHistory = new ListBox();
            groupBox1 = new GroupBox();
            label5 = new Label();
            textBoxUser = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonClear = new Button();
            textBoxPaymentAmount = new TextBox();
            textBoxPaymentMethod = new TextBox();
            textBoxFullName = new TextBox();
            textBoxDate = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxShowHistory
            // 
            listBoxShowHistory.FormattingEnabled = true;
            listBoxShowHistory.ItemHeight = 20;
            listBoxShowHistory.Location = new Point(56, 64);
            listBoxShowHistory.Name = "listBoxShowHistory";
            listBoxShowHistory.Size = new Size(424, 424);
            listBoxShowHistory.TabIndex = 0;
            listBoxShowHistory.SelectedIndexChanged += listBoxShowHistory_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBoxUser);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonClear);
            groupBox1.Controls.Add(textBoxPaymentAmount);
            groupBox1.Controls.Add(textBoxPaymentMethod);
            groupBox1.Controls.Add(textBoxFullName);
            groupBox1.Controls.Add(textBoxDate);
            groupBox1.Location = new Point(516, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 424);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Инфо:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 285);
            label5.Name = "label5";
            label5.Size = new Size(218, 20);
            label5.TabIndex = 10;
            label5.Text = "Сотрудник, зарегистр. платеж:";
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(39, 308);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.ReadOnly = true;
            textBoxUser.Size = new Size(344, 27);
            textBoxUser.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 222);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 8;
            label4.Text = "Сумма оплаты:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 160);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 7;
            label3.Text = "Способ оплаты:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 96);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 6;
            label2.Text = "ФИО плательщика:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 32);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 5;
            label1.Text = "Дата платежа:";
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(39, 353);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(344, 42);
            buttonClear.TabIndex = 4;
            buttonClear.Text = "Свернуть";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // textBoxPaymentAmount
            // 
            textBoxPaymentAmount.Location = new Point(39, 245);
            textBoxPaymentAmount.Name = "textBoxPaymentAmount";
            textBoxPaymentAmount.ReadOnly = true;
            textBoxPaymentAmount.Size = new Size(344, 27);
            textBoxPaymentAmount.TabIndex = 3;
            // 
            // textBoxPaymentMethod
            // 
            textBoxPaymentMethod.Location = new Point(39, 183);
            textBoxPaymentMethod.Name = "textBoxPaymentMethod";
            textBoxPaymentMethod.ReadOnly = true;
            textBoxPaymentMethod.Size = new Size(344, 27);
            textBoxPaymentMethod.TabIndex = 2;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(39, 119);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.ReadOnly = true;
            textBoxFullName.Size = new Size(344, 27);
            textBoxFullName.TabIndex = 1;
            // 
            // textBoxDate
            // 
            textBoxDate.Location = new Point(39, 55);
            textBoxDate.Name = "textBoxDate";
            textBoxDate.ReadOnly = true;
            textBoxDate.Size = new Size(344, 27);
            textBoxDate.TabIndex = 0;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(groupBox1);
            Controls.Add(listBoxShowHistory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "HistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "История платежей";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxShowHistory;
        private GroupBox groupBox1;
        private TextBox textBoxDate;
        private Button buttonClear;
        private TextBox textBoxPaymentAmount;
        private TextBox textBoxPaymentMethod;
        private TextBox textBoxFullName;
        private Label label5;
        private TextBox textBoxUser;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}