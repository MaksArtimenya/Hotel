namespace Hotel.Forms
{
    partial class ReportForm
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
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            labelReport = new Label();
            buttonSaveReport = new Button();
            saveFileDialog1 = new SaveFileDialog();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(588, 557);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(labelReport);
            panel1.Location = new Point(6, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(576, 525);
            panel1.TabIndex = 1;
            // 
            // labelReport
            // 
            labelReport.AutoSize = true;
            labelReport.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelReport.Location = new Point(3, 0);
            labelReport.Name = "labelReport";
            labelReport.Size = new Size(0, 23);
            labelReport.TabIndex = 0;
            // 
            // buttonSaveReport
            // 
            buttonSaveReport.Location = new Point(12, 575);
            buttonSaveReport.Name = "buttonSaveReport";
            buttonSaveReport.Size = new Size(588, 56);
            buttonSaveReport.TabIndex = 1;
            buttonSaveReport.Text = "Сохранить отчет";
            buttonSaveReport.UseVisualStyleBackColor = true;
            buttonSaveReport.Click += buttonSaveReport_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "Текстовый файл|*.txt";
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 643);
            Controls.Add(buttonSaveReport);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отчет";
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button buttonSaveReport;
        private Label labelReport;
        private Panel panel1;
        private SaveFileDialog saveFileDialog1;
    }
}