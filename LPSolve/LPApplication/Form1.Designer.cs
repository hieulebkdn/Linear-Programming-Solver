namespace LPApplication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.radioButtonOpen = new System.Windows.Forms.RadioButton();
            this.radioButtonGetInput = new System.Windows.Forms.RadioButton();
            this.numericUpDownConstraints = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVars = new System.Windows.Forms.NumericUpDown();
            this.labelRangBuoc = new System.Windows.Forms.Label();
            this.labelBien = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConstraints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(290, 15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(582, 179);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.comboBoxType);
            this.groupBoxInput.Controls.Add(this.label1);
            this.groupBoxInput.Controls.Add(this.buttonGenerate);
            this.groupBoxInput.Controls.Add(this.buttonOK);
            this.groupBoxInput.Controls.Add(this.buttonOpen);
            this.groupBoxInput.Controls.Add(this.radioButtonOpen);
            this.groupBoxInput.Controls.Add(this.radioButtonGetInput);
            this.groupBoxInput.Controls.Add(this.numericUpDownConstraints);
            this.groupBoxInput.Controls.Add(this.numericUpDownVars);
            this.groupBoxInput.Controls.Add(this.labelRangBuoc);
            this.groupBoxInput.Controls.Add(this.labelBien);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(272, 182);
            this.groupBoxInput.TabIndex = 1;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Input";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Maximize",
            "Minimize"});
            this.comboBoxType.Location = new System.Drawing.Point(9, 77);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Loại bài toán";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(174, 139);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(92, 29);
            this.buttonGenerate.TabIndex = 14;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(174, 104);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(92, 29);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(174, 46);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(92, 29);
            this.buttonOpen.TabIndex = 6;
            this.buttonOpen.Text = "Browse..";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // radioButtonOpen
            // 
            this.radioButtonOpen.AutoSize = true;
            this.radioButtonOpen.Location = new System.Drawing.Point(174, 20);
            this.radioButtonOpen.Name = "radioButtonOpen";
            this.radioButtonOpen.Size = new System.Drawing.Size(56, 17);
            this.radioButtonOpen.TabIndex = 5;
            this.radioButtonOpen.TabStop = true;
            this.radioButtonOpen.Text = "Mở file";
            this.radioButtonOpen.UseVisualStyleBackColor = true;
            this.radioButtonOpen.CheckedChanged += new System.EventHandler(this.radioButtonOpen_CheckedChanged);
            // 
            // radioButtonGetInput
            // 
            this.radioButtonGetInput.AutoSize = true;
            this.radioButtonGetInput.Location = new System.Drawing.Point(9, 20);
            this.radioButtonGetInput.Name = "radioButtonGetInput";
            this.radioButtonGetInput.Size = new System.Drawing.Size(85, 17);
            this.radioButtonGetInput.TabIndex = 4;
            this.radioButtonGetInput.TabStop = true;
            this.radioButtonGetInput.Text = "Nhập dữ liệu";
            this.radioButtonGetInput.UseVisualStyleBackColor = true;
            this.radioButtonGetInput.CheckedChanged += new System.EventHandler(this.radioButtonGetInput_CheckedChanged);
            // 
            // numericUpDownConstraints
            // 
            this.numericUpDownConstraints.Location = new System.Drawing.Point(87, 145);
            this.numericUpDownConstraints.Name = "numericUpDownConstraints";
            this.numericUpDownConstraints.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownConstraints.TabIndex = 3;
            // 
            // numericUpDownVars
            // 
            this.numericUpDownVars.Location = new System.Drawing.Point(87, 110);
            this.numericUpDownVars.Name = "numericUpDownVars";
            this.numericUpDownVars.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownVars.TabIndex = 2;
            // 
            // labelRangBuoc
            // 
            this.labelRangBuoc.AutoSize = true;
            this.labelRangBuoc.Location = new System.Drawing.Point(6, 147);
            this.labelRangBuoc.Name = "labelRangBuoc";
            this.labelRangBuoc.Size = new System.Drawing.Size(71, 13);
            this.labelRangBuoc.TabIndex = 1;
            this.labelRangBuoc.Text = "Số ràng buộc";
            // 
            // labelBien
            // 
            this.labelBien.AutoSize = true;
            this.labelBien.Location = new System.Drawing.Point(6, 112);
            this.labelBien.Name = "labelBien";
            this.labelBien.Size = new System.Drawing.Size(43, 13);
            this.labelBien.TabIndex = 0;
            this.labelBien.Text = "Số biến";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(765, 202);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(107, 32);
            this.buttonSolve.TabIndex = 8;
            this.buttonSolve.Text = "Solve";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(765, 244);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(107, 32);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(765, 290);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(107, 32);
            this.buttonAbout.TabIndex = 10;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::LPApplication.Properties.Resources.logo1;
            this.pictureBox2.Location = new System.Drawing.Point(822, 333);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 52);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::LPApplication.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(765, 333);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 52);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 200);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(725, 183);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 395);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Giải quy hoạch tuyến tính";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConstraints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.NumericUpDown numericUpDownConstraints;
        private System.Windows.Forms.NumericUpDown numericUpDownVars;
        private System.Windows.Forms.Label labelRangBuoc;
        private System.Windows.Forms.Label labelBien;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.RadioButton radioButtonOpen;
        private System.Windows.Forms.RadioButton radioButtonGetInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label1;
    }
}

