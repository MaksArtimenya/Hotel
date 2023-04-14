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
            Column4 = new DataGridViewTextBoxColumn();
            buttonToEditingGuests = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowRooms).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewShowRooms
            // 
            dataGridViewShowRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewShowRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShowRooms.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewShowRooms.Location = new Point(81, 81);
            dataGridViewShowRooms.Name = "dataGridViewShowRooms";
            dataGridViewShowRooms.RowHeadersWidth = 51;
            dataGridViewShowRooms.RowTemplate.Height = 29;
            dataGridViewShowRooms.Size = new Size(805, 347);
            dataGridViewShowRooms.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Number";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Number of places";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Occupied places";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Price";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // buttonToEditingGuests
            // 
            buttonToEditingGuests.Location = new Point(621, 470);
            buttonToEditingGuests.Name = "buttonToEditingGuests";
            buttonToEditingGuests.Size = new Size(265, 52);
            buttonToEditingGuests.TabIndex = 1;
            buttonToEditingGuests.Text = "Edit guests";
            buttonToEditingGuests.UseVisualStyleBackColor = true;
            buttonToEditingGuests.Click += buttonToEditingGuests_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(buttonToEditingGuests);
            Controls.Add(dataGridViewShowRooms);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewShowRooms;
        private Button buttonToEditingGuests;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}