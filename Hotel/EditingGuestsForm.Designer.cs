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
            listBoxShowGuests.Location = new Point(43, 65);
            listBoxShowGuests.Name = "listBoxShowGuests";
            listBoxShowGuests.Size = new Size(262, 324);
            listBoxShowGuests.TabIndex = 0;
            listBoxShowGuests.SelectedIndexChanged += listBoxShowGuests_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonCancel);
            groupBox1.Controls.Add(buttonRemoveGuest);
            groupBox1.Controls.Add(buttonSaveNewGuest);
            groupBox1.Controls.Add(listBoxShowAvaibleRooms);
            groupBox1.Controls.Add(textBoxLengthOfStay);
            groupBox1.Controls.Add(textBoxArrivalDate);
            groupBox1.Controls.Add(textBoxPassportID);
            groupBox1.Controls.Add(textBoxGender);
            groupBox1.Controls.Add(textBoxFullName);
            groupBox1.Location = new Point(341, 65);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(635, 449);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(39, 408);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(255, 29);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonRemoveGuest
            // 
            buttonRemoveGuest.Enabled = false;
            buttonRemoveGuest.Location = new Point(39, 343);
            buttonRemoveGuest.Name = "buttonRemoveGuest";
            buttonRemoveGuest.Size = new Size(255, 29);
            buttonRemoveGuest.TabIndex = 7;
            buttonRemoveGuest.Text = "Remove";
            buttonRemoveGuest.UseVisualStyleBackColor = true;
            buttonRemoveGuest.Click += buttonRemoveGuest_Click;
            // 
            // buttonSaveNewGuest
            // 
            buttonSaveNewGuest.Location = new Point(39, 373);
            buttonSaveNewGuest.Name = "buttonSaveNewGuest";
            buttonSaveNewGuest.Size = new Size(255, 29);
            buttonSaveNewGuest.TabIndex = 6;
            buttonSaveNewGuest.Text = "Save guest";
            buttonSaveNewGuest.UseVisualStyleBackColor = true;
            buttonSaveNewGuest.Click += buttonSaveNewGuest_Click;
            // 
            // listBoxShowAvaibleRooms
            // 
            listBoxShowAvaibleRooms.FormattingEnabled = true;
            listBoxShowAvaibleRooms.ItemHeight = 20;
            listBoxShowAvaibleRooms.Location = new Point(342, 56);
            listBoxShowAvaibleRooms.Name = "listBoxShowAvaibleRooms";
            listBoxShowAvaibleRooms.Size = new Size(244, 284);
            listBoxShowAvaibleRooms.TabIndex = 5;
            // 
            // textBoxLengthOfStay
            // 
            textBoxLengthOfStay.Location = new Point(29, 310);
            textBoxLengthOfStay.Name = "textBoxLengthOfStay";
            textBoxLengthOfStay.Size = new Size(265, 27);
            textBoxLengthOfStay.TabIndex = 4;
            // 
            // textBoxArrivalDate
            // 
            textBoxArrivalDate.Location = new Point(29, 246);
            textBoxArrivalDate.Name = "textBoxArrivalDate";
            textBoxArrivalDate.Size = new Size(265, 27);
            textBoxArrivalDate.TabIndex = 3;
            // 
            // textBoxPassportID
            // 
            textBoxPassportID.Location = new Point(29, 182);
            textBoxPassportID.Name = "textBoxPassportID";
            textBoxPassportID.Size = new Size(265, 27);
            textBoxPassportID.TabIndex = 2;
            // 
            // textBoxGender
            // 
            textBoxGender.Location = new Point(29, 119);
            textBoxGender.Name = "textBoxGender";
            textBoxGender.Size = new Size(265, 27);
            textBoxGender.TabIndex = 1;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(29, 56);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(265, 27);
            textBoxFullName.TabIndex = 0;
            // 
            // EditingGuestsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 526);
            Controls.Add(groupBox1);
            Controls.Add(listBoxShowGuests);
            Name = "EditingGuestsForm";
            Text = "EditingGuestsForm";
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
    }
}