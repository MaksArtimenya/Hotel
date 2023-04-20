namespace Hotel
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewShowRooms = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            buttonToEditingGuests = new Button();
            buttonToEditingRooms = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            buttonSearch = new Button();
            buttonClearSearch = new Button();
            textBoxDesiredObject = new TextBox();
            comboBoxSearchBy = new ComboBox();
            radioButtonGuest = new RadioButton();
            radioButtonRoom = new RadioButton();
            dataGridViewShowGuests = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowRooms).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowGuests).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewShowRooms
            // 
            dataGridViewShowRooms.AllowUserToAddRows = false;
            dataGridViewShowRooms.AllowUserToDeleteRows = false;
            dataGridViewShowRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewShowRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShowRooms.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column5, Column4 });
            dataGridViewShowRooms.Location = new Point(336, 45);
            dataGridViewShowRooms.Name = "dataGridViewShowRooms";
            dataGridViewShowRooms.ReadOnly = true;
            dataGridViewShowRooms.RowHeadersWidth = 51;
            dataGridViewShowRooms.RowTemplate.Height = 29;
            dataGridViewShowRooms.Size = new Size(607, 355);
            dataGridViewShowRooms.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Number";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Number of places";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Occupied places";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Free places";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Price";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // buttonToEditingGuests
            // 
            buttonToEditingGuests.Location = new Point(678, 470);
            buttonToEditingGuests.Name = "buttonToEditingGuests";
            buttonToEditingGuests.Size = new Size(265, 52);
            buttonToEditingGuests.TabIndex = 1;
            buttonToEditingGuests.Text = "Edit guests";
            buttonToEditingGuests.UseVisualStyleBackColor = true;
            buttonToEditingGuests.Click += buttonToEditingGuests_Click;
            // 
            // buttonToEditingRooms
            // 
            buttonToEditingRooms.Location = new Point(336, 470);
            buttonToEditingRooms.Name = "buttonToEditingRooms";
            buttonToEditingRooms.Size = new Size(265, 52);
            buttonToEditingRooms.TabIndex = 2;
            buttonToEditingRooms.Text = "Edit rooms";
            buttonToEditingRooms.UseVisualStyleBackColor = true;
            buttonToEditingRooms.Click += buttonToEditingRooms_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonSearch);
            groupBox1.Controls.Add(buttonClearSearch);
            groupBox1.Controls.Add(textBoxDesiredObject);
            groupBox1.Controls.Add(comboBoxSearchBy);
            groupBox1.Controls.Add(radioButtonGuest);
            groupBox1.Controls.Add(radioButtonRoom);
            groupBox1.Location = new Point(25, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 355);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 139);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 6;
            label1.Text = "Search by";
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(143, 284);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(102, 29);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonClearSearch
            // 
            buttonClearSearch.Location = new Point(26, 284);
            buttonClearSearch.Name = "buttonClearSearch";
            buttonClearSearch.Size = new Size(102, 29);
            buttonClearSearch.TabIndex = 4;
            buttonClearSearch.Text = "Clear";
            buttonClearSearch.UseVisualStyleBackColor = true;
            // 
            // textBoxDesiredObject
            // 
            textBoxDesiredObject.Location = new Point(26, 227);
            textBoxDesiredObject.Name = "textBoxDesiredObject";
            textBoxDesiredObject.Size = new Size(219, 27);
            textBoxDesiredObject.TabIndex = 3;
            // 
            // comboBoxSearchBy
            // 
            comboBoxSearchBy.FormattingEnabled = true;
            comboBoxSearchBy.Location = new Point(26, 162);
            comboBoxSearchBy.Name = "comboBoxSearchBy";
            comboBoxSearchBy.Size = new Size(219, 28);
            comboBoxSearchBy.TabIndex = 2;
            // 
            // radioButtonGuest
            // 
            radioButtonGuest.AutoSize = true;
            radioButtonGuest.Location = new Point(26, 85);
            radioButtonGuest.Name = "radioButtonGuest";
            radioButtonGuest.Size = new Size(67, 24);
            radioButtonGuest.TabIndex = 1;
            radioButtonGuest.TabStop = true;
            radioButtonGuest.Text = "Guest";
            radioButtonGuest.UseVisualStyleBackColor = true;
            radioButtonGuest.CheckedChanged += radioButtonGuest_CheckedChanged;
            // 
            // radioButtonRoom
            // 
            radioButtonRoom.AutoSize = true;
            radioButtonRoom.Checked = true;
            radioButtonRoom.Location = new Point(26, 55);
            radioButtonRoom.Name = "radioButtonRoom";
            radioButtonRoom.Size = new Size(70, 24);
            radioButtonRoom.TabIndex = 0;
            radioButtonRoom.TabStop = true;
            radioButtonRoom.Text = "Room";
            radioButtonRoom.UseVisualStyleBackColor = true;
            radioButtonRoom.CheckedChanged += radioButtonRoom_CheckedChanged;
            // 
            // dataGridViewShowGuests
            // 
            dataGridViewShowGuests.AllowUserToAddRows = false;
            dataGridViewShowGuests.AllowUserToDeleteRows = false;
            dataGridViewShowGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewShowGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShowGuests.Columns.AddRange(new DataGridViewColumn[] { Column6, Column7, Column8, Column9, Column10 });
            dataGridViewShowGuests.Enabled = false;
            dataGridViewShowGuests.Location = new Point(336, 45);
            dataGridViewShowGuests.Name = "dataGridViewShowGuests";
            dataGridViewShowGuests.ReadOnly = true;
            dataGridViewShowGuests.RowHeadersWidth = 51;
            dataGridViewShowGuests.RowTemplate.Height = 29;
            dataGridViewShowGuests.Size = new Size(607, 355);
            dataGridViewShowGuests.TabIndex = 4;
            dataGridViewShowGuests.Visible = false;
            // 
            // Column6
            // 
            Column6.HeaderText = "Full name";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Gender";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.HeaderText = "Passport ID";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.HeaderText = "Arrival date";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.HeaderText = "Length of stay";
            Column10.MinimumWidth = 6;
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(dataGridViewShowGuests);
            Controls.Add(groupBox1);
            Controls.Add(buttonToEditingRooms);
            Controls.Add(buttonToEditingGuests);
            Controls.Add(dataGridViewShowRooms);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowRooms).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowGuests).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewShowRooms;
        private Button buttonToEditingGuests;
        private Button buttonToEditingRooms;
        private GroupBox groupBox1;
        private RadioButton radioButtonGuest;
        private RadioButton radioButtonRoom;
        private Button buttonSearch;
        private Button buttonClearSearch;
        private TextBox textBoxDesiredObject;
        private ComboBox comboBoxSearchBy;
        private Label label1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private DataGridView dataGridViewShowGuests;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
    }
}