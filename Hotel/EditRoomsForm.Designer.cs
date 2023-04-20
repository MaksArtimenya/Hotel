namespace Hotel
{
    partial class EditRoomsForm
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
            listBoxShowRooms = new ListBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonGuestInfo = new Button();
            buttonCancel = new Button();
            buttonSaveRoom = new Button();
            buttonRemoveRoom = new Button();
            listBoxShowPlacesOfRoom = new ListBox();
            textBoxPrice = new TextBox();
            textBoxNumberOfPlaces = new TextBox();
            textBoxNumber = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxShowRooms
            // 
            listBoxShowRooms.FormattingEnabled = true;
            listBoxShowRooms.ItemHeight = 20;
            listBoxShowRooms.Location = new Point(63, 78);
            listBoxShowRooms.Name = "listBoxShowRooms";
            listBoxShowRooms.Size = new Size(243, 404);
            listBoxShowRooms.TabIndex = 0;
            listBoxShowRooms.SelectedIndexChanged += listBoxShowRooms_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonGuestInfo);
            groupBox1.Controls.Add(buttonCancel);
            groupBox1.Controls.Add(buttonSaveRoom);
            groupBox1.Controls.Add(buttonRemoveRoom);
            groupBox1.Controls.Add(listBoxShowPlacesOfRoom);
            groupBox1.Controls.Add(textBoxPrice);
            groupBox1.Controls.Add(textBoxNumberOfPlaces);
            groupBox1.Controls.Add(textBoxNumber);
            groupBox1.Location = new Point(339, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(592, 411);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(319, 29);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 13;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 163);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 12;
            label3.Text = "Цена";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 100);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 11;
            label2.Text = "Кол-во мест";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 29);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 10;
            label1.Text = "Номер";
            // 
            // buttonGuestInfo
            // 
            buttonGuestInfo.Enabled = false;
            buttonGuestInfo.Location = new Point(319, 301);
            buttonGuestInfo.Name = "buttonGuestInfo";
            buttonGuestInfo.Size = new Size(231, 29);
            buttonGuestInfo.TabIndex = 9;
            buttonGuestInfo.Text = "Информация о постояльце";
            buttonGuestInfo.UseVisualStyleBackColor = true;
            buttonGuestInfo.Click += buttonGuestInfo_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(41, 371);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(241, 29);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Закрыть";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSaveRoom
            // 
            buttonSaveRoom.Enabled = false;
            buttonSaveRoom.Location = new Point(41, 336);
            buttonSaveRoom.Name = "buttonSaveRoom";
            buttonSaveRoom.Size = new Size(241, 29);
            buttonSaveRoom.TabIndex = 7;
            buttonSaveRoom.Text = "Сохранить";
            buttonSaveRoom.UseVisualStyleBackColor = true;
            buttonSaveRoom.Click += buttonSaveRoom_Click;
            // 
            // buttonRemoveRoom
            // 
            buttonRemoveRoom.Enabled = false;
            buttonRemoveRoom.Location = new Point(41, 301);
            buttonRemoveRoom.Name = "buttonRemoveRoom";
            buttonRemoveRoom.Size = new Size(241, 29);
            buttonRemoveRoom.TabIndex = 6;
            buttonRemoveRoom.Text = "Удалить";
            buttonRemoveRoom.UseVisualStyleBackColor = true;
            buttonRemoveRoom.Click += buttonRemoveRoom_Click;
            // 
            // listBoxShowPlacesOfRoom
            // 
            listBoxShowPlacesOfRoom.FormattingEnabled = true;
            listBoxShowPlacesOfRoom.ItemHeight = 20;
            listBoxShowPlacesOfRoom.Location = new Point(319, 52);
            listBoxShowPlacesOfRoom.Name = "listBoxShowPlacesOfRoom";
            listBoxShowPlacesOfRoom.Size = new Size(231, 224);
            listBoxShowPlacesOfRoom.TabIndex = 5;
            listBoxShowPlacesOfRoom.SelectedIndexChanged += listBoxShowPlacesOfRoom_SelectedIndexChanged;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(41, 186);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(241, 27);
            textBoxPrice.TabIndex = 4;
            textBoxPrice.TextChanged += textBoxPrice_TextChanged;
            // 
            // textBoxNumberOfPlaces
            // 
            textBoxNumberOfPlaces.Location = new Point(41, 123);
            textBoxNumberOfPlaces.Name = "textBoxNumberOfPlaces";
            textBoxNumberOfPlaces.Size = new Size(241, 27);
            textBoxNumberOfPlaces.TabIndex = 1;
            textBoxNumberOfPlaces.TextChanged += textBoxNumberOfPlaces_TextChanged;
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(41, 52);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(241, 27);
            textBoxNumber.TabIndex = 0;
            textBoxNumber.TextChanged += textBoxNumber_TextChanged;
            // 
            // EditRoomsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(groupBox1);
            Controls.Add(listBoxShowRooms);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditRoomsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Комнаты";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxShowRooms;
        private GroupBox groupBox1;
        private TextBox textBoxPrice;
        private TextBox textBoxNumberOfPlaces;
        private TextBox textBoxNumber;
        private Button buttonGuestInfo;
        private Button buttonCancel;
        private Button buttonSaveRoom;
        private Button buttonRemoveRoom;
        private ListBox listBoxShowPlacesOfRoom;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}