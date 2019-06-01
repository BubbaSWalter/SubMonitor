namespace ProtonSubMonitorProgram
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSub = new System.Windows.Forms.DataGridView();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubAlert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubMonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainList = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbSubList = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.OutPut = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalSubCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NewSubCount = new System.Windows.Forms.NumericUpDown();
            this.NewSubsLIst = new System.Windows.Forms.RichTextBox();
            this.NewSubs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GiftSubCount = new System.Windows.Forms.NumericUpDown();
            this.ResetNumbers = new System.Windows.Forms.Button();
            this.GiftSubsList = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).BeginInit();
            this.MainList.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSubCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewSubCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GiftSubCount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSub
            // 
            this.dgvSub.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSub.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateTime,
            this.SubAlert,
            this.SubName,
            this.SubMonths,
            this.SubMessage});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSub.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSub.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvSub.Location = new System.Drawing.Point(3, 3);
            this.dgvSub.Name = "dgvSub";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSub.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSub.Size = new System.Drawing.Size(926, 490);
            this.dgvSub.TabIndex = 1;
            this.dgvSub.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSub_CellContentClick);
            // 
            // DateTime
            // 
            this.DateTime.FillWeight = 150F;
            this.DateTime.HeaderText = "Date Time Stamp";
            this.DateTime.Name = "DateTime";
            this.DateTime.Width = 150;
            // 
            // SubAlert
            // 
            this.SubAlert.HeaderText = "Sub Type";
            this.SubAlert.Name = "SubAlert";
            // 
            // SubName
            // 
            this.SubName.FillWeight = 270F;
            this.SubName.HeaderText = "Sub Name";
            this.SubName.Name = "SubName";
            this.SubName.Width = 270;
            // 
            // SubMonths
            // 
            this.SubMonths.HeaderText = "Sub Months";
            this.SubMonths.Name = "SubMonths";
            // 
            // SubMessage
            // 
            this.SubMessage.FillWeight = 300F;
            this.SubMessage.HeaderText = "Sub Message";
            this.SubMessage.Name = "SubMessage";
            this.SubMessage.Width = 300;
            // 
            // MainList
            // 
            this.MainList.Controls.Add(this.tabPage1);
            this.MainList.Controls.Add(this.tabPage2);
            this.MainList.Controls.Add(this.tabPage3);
            this.MainList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainList.Location = new System.Drawing.Point(0, 0);
            this.MainList.Name = "MainList";
            this.MainList.SelectedIndex = 0;
            this.MainList.Size = new System.Drawing.Size(940, 522);
            this.MainList.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSub);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(932, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Grid View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbSubList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(932, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Main List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbSubList
            // 
            this.tbSubList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSubList.Location = new System.Drawing.Point(3, 3);
            this.tbSubList.Name = "tbSubList";
            this.tbSubList.Size = new System.Drawing.Size(926, 490);
            this.tbSubList.TabIndex = 0;
            this.tbSubList.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.OutPut);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.TotalSubCount);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.NewSubCount);
            this.tabPage3.Controls.Add(this.NewSubsLIst);
            this.tabPage3.Controls.Add(this.NewSubs);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.GiftSubCount);
            this.tabPage3.Controls.Add(this.ResetNumbers);
            this.tabPage3.Controls.Add(this.GiftSubsList);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(932, 496);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "New & Gits list with options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // OutPut
            // 
            this.OutPut.Location = new System.Drawing.Point(844, 12);
            this.OutPut.Name = "OutPut";
            this.OutPut.Size = new System.Drawing.Size(75, 23);
            this.OutPut.TabIndex = 11;
            this.OutPut.Text = "OutPut";
            this.OutPut.UseVisualStyleBackColor = true;
            this.OutPut.Click += new System.EventHandler(this.OutPut_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "GiftSubs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "NewSubs";
            // 
            // TotalSubCount
            // 
            this.TotalSubCount.Location = new System.Drawing.Point(516, 10);
            this.TotalSubCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TotalSubCount.Name = "TotalSubCount";
            this.TotalSubCount.Size = new System.Drawing.Size(120, 20);
            this.TotalSubCount.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Subs";
            // 
            // NewSubCount
            // 
            this.NewSubCount.Location = new System.Drawing.Point(326, 10);
            this.NewSubCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NewSubCount.Name = "NewSubCount";
            this.NewSubCount.Size = new System.Drawing.Size(120, 20);
            this.NewSubCount.TabIndex = 6;
            // 
            // NewSubsLIst
            // 
            this.NewSubsLIst.Location = new System.Drawing.Point(11, 328);
            this.NewSubsLIst.Name = "NewSubsLIst";
            this.NewSubsLIst.Size = new System.Drawing.Size(908, 160);
            this.NewSubsLIst.TabIndex = 5;
            this.NewSubsLIst.Text = "";
            // 
            // NewSubs
            // 
            this.NewSubs.AutoSize = true;
            this.NewSubs.Location = new System.Drawing.Point(8, 312);
            this.NewSubs.Name = "NewSubs";
            this.NewSubs.Size = new System.Drawing.Size(53, 13);
            this.NewSubs.TabIndex = 4;
            this.NewSubs.Text = "NewSubs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "GiftSubs";
            // 
            // GiftSubCount
            // 
            this.GiftSubCount.Location = new System.Drawing.Point(141, 10);
            this.GiftSubCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.GiftSubCount.Name = "GiftSubCount";
            this.GiftSubCount.Size = new System.Drawing.Size(120, 20);
            this.GiftSubCount.TabIndex = 2;
            // 
            // ResetNumbers
            // 
            this.ResetNumbers.Location = new System.Drawing.Point(7, 7);
            this.ResetNumbers.Name = "ResetNumbers";
            this.ResetNumbers.Size = new System.Drawing.Size(75, 23);
            this.ResetNumbers.TabIndex = 1;
            this.ResetNumbers.Text = "Clear";
            this.ResetNumbers.UseVisualStyleBackColor = true;
            this.ResetNumbers.Click += new System.EventHandler(this.ResetNumbers_Click);
            // 
            // GiftSubsList
            // 
            this.GiftSubsList.Location = new System.Drawing.Point(10, 49);
            this.GiftSubsList.Name = "GiftSubsList";
            this.GiftSubsList.Size = new System.Drawing.Size(909, 260);
            this.GiftSubsList.TabIndex = 0;
            this.GiftSubsList.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 522);
            this.Controls.Add(this.MainList);
            this.Name = "Form1";
            this.Text = "Beta";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).EndInit();
            this.MainList.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSubCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewSubCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GiftSubCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSub;
        private System.Windows.Forms.TabControl MainList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox tbSubList;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubAlert;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubMonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubMessage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox NewSubsLIst;
        private System.Windows.Forms.Label NewSubs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown GiftSubCount;
        private System.Windows.Forms.Button ResetNumbers;
        private System.Windows.Forms.RichTextBox GiftSubsList;
        private System.Windows.Forms.NumericUpDown TotalSubCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NewSubCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OutPut;
    }
}

