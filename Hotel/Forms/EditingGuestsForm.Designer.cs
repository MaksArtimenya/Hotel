namespace Hotel
{
    partial class EditingGuestsForm
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
            listBoxShowGuests = new ListBox();
            groupBox1 = new GroupBox();
            buttonRoomInfo = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonCancel = new Button();
            buttonRemoveGuest = new Button();
            buttonSaveNewGuest = new Button();
            listBoxShowAvaibleRooms = new ListBox();
            textBoxLengthOfStay = new TextBox();
            textBoxArrivalDate = new TextBox();
            textBoxPassportID = new TextBox();
            textBoxGender = new TextBox();
            textBoxFullName = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxShowGuests
            // 
            listBoxShowGuests.FormattingEnabled = true;
            listBoxShowGuests.ItemHeight = 20;
            listBoxShowGuests.Location = new Point(41, 51);
            listBoxShowGuests.Name = "listBoxShowGuests";
            listBoxShowGuests.Size = new Size(262, 444);
            listBoxShowGuests.TabIndex = 0;
            listBoxShowGuests.SelectedIndexChanged += listBoxShowGuests_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonRoomInfo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonCancel);
            groupBox1.Controls.Add(buttonRemoveGuest);
            groupBox1.Controls.Add(buttonSaveNewGuest);
            groupBox1.Controls.Add(listBoxShowAvaibleRooms);
            groupBox1.Controls.Add(textBoxLengthOfStay);
            groupBox1.Controls.Add(textBoxArrivalDate);
            groupBox1.Controls.Add(textBoxPassportID);
            groupBox1.Controls.Add(textBoxGender);
            groupBox1.Controls.Add(textBoxFullName);
            groupBox1.Location = new Point(334, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(619, 444);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // buttonRoomInfo
            // 
            buttonRoomInfo.Enabled = false;
            buttonRoomInfo.Location = new Point(342, 408);
            buttonRoomInfo.Name = "buttonRoomInfo";
            buttonRoomInfo.Size = new Size(244, 29);
            buttonRoomInfo.TabIndex = 15;
            buttonRoomInfo.Text = "Информация о комнате";
            buttonRoomInfo.UseVisualStyleBackColor = true;
            buttonRoomInfo.Click += buttonRoomInfo_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(342, 33);
            label6.Name = "label6";
            label6.Size = new Size(150, 20);
            label6.TabIndex = 14;
            label6.Text = "Доступные комнаты";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 285);
            label5.Name = "label5";
            label5.Size = new Size(244, 20);
            label5.TabIndex = 13;
            label5.Text = "Продолжительность пребывания";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 222);
            label4.Name = "label4";
            label4.Size = new Size(115, 20);
            label4.TabIndex = 12;
            label4.Text = "Дата прибытия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 159);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 11;
            label3.Text = "Паспортные данные";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 96);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 10;
            label2.Text = "Пол";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 33);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 9;
            label1.Text = "ФИО";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(29, 408);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(265, 29);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Закрыть";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonRemoveGuest
            // 
            buttonRemoveGuest.Enabled = false;
            buttonRemoveGuest.Location = new Point(29, 348);
            buttonRemoveGuest.Name = "buttonRemoveGuest";
            buttonRemoveGuest.Size = new Size(265, 29);
            buttonRemoveGuest.TabIndex = 7;
            buttonRemoveGuest.Text = "Удалить";
            buttonRemoveGuest.UseVisualStyleBackColor = true;
            buttonRemoveGuest.Click += buttonRemoveGuest_Click;
            // 
            // buttonSaveNewGuest
            // 
            buttonSaveNewGuest.Location = new Point(29, 378);
            buttonSaveNewGuest.Name = "buttonSaveNewGuest";
            buttonSaveNewGuest.Size = new Size(265, 29);
            buttonSaveNewGuest.TabIndex = 6;
            buttonSaveNewGuest.Text = "Сохранить";
            buttonSaveNewGuest.UseVisualStyleBackColor = true;
            buttonSaveNewGuest.Click += buttonSaveNewGuest_Click;
            // 
            // listBoxShowAvaibleRooms
            // 
            listBoxShowAvaibleRooms.FormattingEnabled = true;
            listBoxShowAvaibleRooms.ItemHeight = 20;
            listBoxShowAvaibleRooms.Location = new Point(342, 56);
            listBoxShowAvaibleRooms.Name = "listBoxShowAvaibleRooms";
            listBoxShowAvaibleRooms.Size = new Size(244, 344);
            listBoxShowAvaibleRooms.TabIndex = 5;
            listBoxShowAvaibleRooms.SelectedIndexChanged += listBoxShowAvaibleRooms_SelectedIndexChanged;
            // 
            // textBoxLengthOfStay
            // 
            textBoxLengthOfStay.Location = new Point(29, 308);
            textBoxLengthOfStay.Name = "textBoxLengthOfStay";
            textBoxLengthOfStay.Size = new Size(265, 27);
            textBoxLengthOfStay.TabIndex = 4;
            textBoxLengthOfStay.TextChanged += textBoxLengthOfStay_TextChanged;
            // 
            // textBoxArrivalDate
            // 
            textBoxArrivalDate.Location = new Point(29, 245);
            textBoxArrivalDate.Name = "textBoxArrivalDate";
            textBoxArrivalDate.Size = new Size(265, 27);
            textBoxArrivalDate.TabIndex = 3;
            textBoxArrivalDate.TextChanged += textBoxArrivalDate_TextChanged;
            // 
            // textBoxPassportID
            // 
            textBoxPassportID.Location = new Point(29, 182);
            textBoxPassportID.Name = "textBoxPassportID";
            textBoxPassportID.Size = new Size(265, 27);
            textBoxPassportID.TabIndex = 2;
            textBoxPassportID.TextChanged += textBoxPassportID_TextChanged;
            // 
            // textBoxGender
            // 
            textBoxGender.Location = new Point(29, 119);
            textBoxGender.Name = "textBoxGender";
            textBoxGender.Size = new Size(265, 27);
            textBoxGender.TabIndex = 1;
            textBoxGender.TextChanged += textBoxGender_TextChanged;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(29, 56);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(265, 27);
            textBoxFullName.TabIndex = 0;
            textBoxFullName.TextChanged += textBoxFullName_TextChanged;
            // 
            // EditingGuestsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(groupBox1);
            Controls.Add(listBoxShowGuests);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditingGuestsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Постояльцы";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxShowGuests;
        private GroupBox groupBox1;
        private Button buttonSaveNewGuest;
        private ListBox listBoxShowAvaibleRooms;
        private TextBox textBoxLengthOfStay;
        private TextBox textBoxArrivalDate;
        private TextBox textBoxPassportID;
        private TextBox textBoxGender;
        private TextBox textBoxFullName;
        private Button buttonRemoveGuest;
        private Button buttonCancel;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button buttonRoomInfo;
    }
}