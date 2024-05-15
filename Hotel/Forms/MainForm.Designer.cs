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
            components = new System.ComponentModel.Container();
            dataGridViewShowRooms = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            buttonToEditingGuests = new Button();
            buttonToEditingRooms = new Button();
            groupBox1 = new GroupBox();
            buttonSearch = new Button();
            buttonClearSearch = new Button();
            textBoxDesiredObject = new TextBox();
            radioButtonGuest = new RadioButton();
            radioButtonRoom = new RadioButton();
            dataGridViewShowGuests = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            labelWelcome = new Label();
            labelError = new Label();
            progressBarReconnect = new ProgressBar();
            timerForErrorLabel = new System.Windows.Forms.Timer(components);
            buttonToHistory = new Button();
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
            dataGridViewShowRooms.Location = new Point(336, 91);
            dataGridViewShowRooms.Name = "dataGridViewShowRooms";
            dataGridViewShowRooms.ReadOnly = true;
            dataGridViewShowRooms.RowHeadersWidth = 51;
            dataGridViewShowRooms.RowTemplate.Height = 29;
            dataGridViewShowRooms.Size = new Size(607, 309);
            dataGridViewShowRooms.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Номер";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Кол-во мест";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Занятые места";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Свободные места";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Цена";
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
            buttonToEditingGuests.Text = "Список постояльцев";
            buttonToEditingGuests.UseVisualStyleBackColor = true;
            buttonToEditingGuests.Click += buttonToEditingGuests_Click;
            // 
            // buttonToEditingRooms
            // 
            buttonToEditingRooms.Location = new Point(336, 470);
            buttonToEditingRooms.Name = "buttonToEditingRooms";
            buttonToEditingRooms.Size = new Size(265, 52);
            buttonToEditingRooms.TabIndex = 2;
            buttonToEditingRooms.Text = "Список комнат";
            buttonToEditingRooms.UseVisualStyleBackColor = true;
            buttonToEditingRooms.Click += buttonToEditingRooms_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSearch);
            groupBox1.Controls.Add(buttonClearSearch);
            groupBox1.Controls.Add(textBoxDesiredObject);
            groupBox1.Controls.Add(radioButtonGuest);
            groupBox1.Controls.Add(radioButtonRoom);
            groupBox1.Location = new Point(25, 91);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 263);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Поиск";
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(143, 206);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(102, 29);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonClearSearch
            // 
            buttonClearSearch.Location = new Point(26, 206);
            buttonClearSearch.Name = "buttonClearSearch";
            buttonClearSearch.Size = new Size(102, 29);
            buttonClearSearch.TabIndex = 4;
            buttonClearSearch.Text = "Очистить";
            buttonClearSearch.UseVisualStyleBackColor = true;
            buttonClearSearch.Click += buttonClearSearch_Click;
            // 
            // textBoxDesiredObject
            // 
            textBoxDesiredObject.Location = new Point(26, 148);
            textBoxDesiredObject.Name = "textBoxDesiredObject";
            textBoxDesiredObject.Size = new Size(219, 27);
            textBoxDesiredObject.TabIndex = 3;
            // 
            // radioButtonGuest
            // 
            radioButtonGuest.AutoSize = true;
            radioButtonGuest.Location = new Point(26, 85);
            radioButtonGuest.Name = "radioButtonGuest";
            radioButtonGuest.Size = new Size(116, 24);
            radioButtonGuest.TabIndex = 1;
            radioButtonGuest.TabStop = true;
            radioButtonGuest.Text = "Постояльцы";
            radioButtonGuest.UseVisualStyleBackColor = true;
            radioButtonGuest.CheckedChanged += radioButtonGuest_CheckedChanged;
            // 
            // radioButtonRoom
            // 
            radioButtonRoom.AutoSize = true;
            radioButtonRoom.Checked = true;
            radioButtonRoom.Location = new Point(26, 55);
            radioButtonRoom.Name = "radioButtonRoom";
            radioButtonRoom.Size = new Size(93, 24);
            radioButtonRoom.TabIndex = 0;
            radioButtonRoom.TabStop = true;
            radioButtonRoom.Text = "Комнаты";
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
            dataGridViewShowGuests.Location = new Point(336, 91);
            dataGridViewShowGuests.Name = "dataGridViewShowGuests";
            dataGridViewShowGuests.ReadOnly = true;
            dataGridViewShowGuests.RowHeadersWidth = 51;
            dataGridViewShowGuests.RowTemplate.Height = 29;
            dataGridViewShowGuests.Size = new Size(607, 309);
            dataGridViewShowGuests.TabIndex = 4;
            dataGridViewShowGuests.Visible = false;
            // 
            // Column6
            // 
            Column6.HeaderText = "ФИО";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Пол";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.HeaderText = "Паспортные данные";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.HeaderText = "Дата прибытия";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.FillWeight = 160F;
            Column10.HeaderText = "Продолжительность пребывания";
            Column10.MinimumWidth = 6;
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelWelcome.Location = new Point(274, 28);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(194, 32);
            labelWelcome.TabIndex = 5;
            labelWelcome.Text = "Вы вошли как: ()";
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelError.Location = new Point(48, 384);
            labelError.Name = "labelError";
            labelError.Size = new Size(235, 56);
            labelError.TabIndex = 6;
            labelError.Text = "Подключение к серверу\r\n             прервано";
            labelError.Visible = false;
            // 
            // progressBarReconnect
            // 
            progressBarReconnect.Location = new Point(48, 452);
            progressBarReconnect.Name = "progressBarReconnect";
            progressBarReconnect.Size = new Size(235, 29);
            progressBarReconnect.Style = ProgressBarStyle.Marquee;
            progressBarReconnect.TabIndex = 7;
            progressBarReconnect.Visible = false;
            // 
            // timerForErrorLabel
            // 
            timerForErrorLabel.Enabled = true;
            timerForErrorLabel.Tick += timerForErrorLabel_Tick;
            // 
            // buttonToHistory
            // 
            buttonToHistory.Location = new Point(508, 412);
            buttonToHistory.Name = "buttonToHistory";
            buttonToHistory.Size = new Size(265, 52);
            buttonToHistory.TabIndex = 8;
            buttonToHistory.Text = "История платежей";
            buttonToHistory.UseVisualStyleBackColor = true;
            buttonToHistory.Click += buttonToHistory_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(buttonToHistory);
            Controls.Add(progressBarReconnect);
            Controls.Add(labelError);
            Controls.Add(labelWelcome);
            Controls.Add(dataGridViewShowGuests);
            Controls.Add(groupBox1);
            Controls.Add(buttonToEditingRooms);
            Controls.Add(buttonToEditingGuests);
            Controls.Add(dataGridViewShowRooms);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Гостиница";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowRooms).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowGuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridView dataGridViewShowGuests;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private Label labelWelcome;
        private Label labelError;
        private ProgressBar progressBarReconnect;
        private System.Windows.Forms.Timer timerForErrorLabel;
        private Button buttonToHistory;
    }
}