
namespace DRRMIS_GSM_Client
{
    partial class SelectSerialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSerialForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConSelSerial = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.grpSerialPort = new System.Windows.Forms.GroupBox();
            this.selSerialPort = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.selMessageMode = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSerialPort.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 41);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panel1.Size = new System.Drawing.Size(336, 362);
            this.panel1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnConSelSerial, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpSerialPort, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 361);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnConSelSerial
            // 
            this.btnConSelSerial.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConSelSerial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConSelSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConSelSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConSelSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConSelSerial.ForeColor = System.Drawing.Color.White;
            this.btnConSelSerial.Location = new System.Drawing.Point(15, 298);
            this.btnConSelSerial.Margin = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.btnConSelSerial.Name = "btnConSelSerial";
            this.btnConSelSerial.Size = new System.Drawing.Size(304, 39);
            this.btnConSelSerial.TabIndex = 9;
            this.btnConSelSerial.Text = "Apply";
            this.btnConSelSerial.UseVisualStyleBackColor = false;
            this.btnConSelSerial.Click += new System.EventHandler(this.BtnConSelSerial_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBaudRate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 118);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20, 12, 20, 3);
            this.groupBox1.Size = new System.Drawing.Size(304, 75);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Baud Rate";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBaudRate.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaudRate.Location = new System.Drawing.Point(20, 27);
            this.txtBaudRate.MaxLength = 10;
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(264, 27);
            this.txtBaudRate.TabIndex = 2;
            this.txtBaudRate.Text = "9600";
            this.txtBaudRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBaudRate_KeyPress);
            // 
            // grpSerialPort
            // 
            this.grpSerialPort.Controls.Add(this.selSerialPort);
            this.grpSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSerialPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpSerialPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSerialPort.ForeColor = System.Drawing.Color.White;
            this.grpSerialPort.Location = new System.Drawing.Point(15, 28);
            this.grpSerialPort.Margin = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.grpSerialPort.Name = "grpSerialPort";
            this.grpSerialPort.Padding = new System.Windows.Forms.Padding(20, 12, 20, 3);
            this.grpSerialPort.Size = new System.Drawing.Size(304, 75);
            this.grpSerialPort.TabIndex = 11;
            this.grpSerialPort.TabStop = false;
            this.grpSerialPort.Text = "Serial Port";
            // 
            // selSerialPort
            // 
            this.selSerialPort.BackColor = System.Drawing.Color.White;
            this.selSerialPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selSerialPort.DropDownHeight = 125;
            this.selSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selSerialPort.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selSerialPort.ForeColor = System.Drawing.Color.Black;
            this.selSerialPort.FormattingEnabled = true;
            this.selSerialPort.IntegralHeight = false;
            this.selSerialPort.Location = new System.Drawing.Point(20, 27);
            this.selSerialPort.Name = "selSerialPort";
            this.selSerialPort.Size = new System.Drawing.Size(264, 28);
            this.selSerialPort.Sorted = true;
            this.selSerialPort.TabIndex = 1;
            this.selSerialPort.Click += new System.EventHandler(this.SelSerialPort_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.selMessageMode);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(15, 208);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(20, 12, 20, 3);
            this.groupBox3.Size = new System.Drawing.Size(304, 75);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Message Mode";
            // 
            // selMessageMode
            // 
            this.selMessageMode.BackColor = System.Drawing.Color.White;
            this.selMessageMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selMessageMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selMessageMode.DropDownHeight = 125;
            this.selMessageMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selMessageMode.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selMessageMode.ForeColor = System.Drawing.Color.Black;
            this.selMessageMode.FormattingEnabled = true;
            this.selMessageMode.IntegralHeight = false;
            this.selMessageMode.Items.AddRange(new object[] {
            "PDU",
            "Text"});
            this.selMessageMode.Location = new System.Drawing.Point(20, 27);
            this.selMessageMode.Name = "selMessageMode";
            this.selMessageMode.Size = new System.Drawing.Size(264, 28);
            this.selMessageMode.Sorted = true;
            this.selMessageMode.TabIndex = 2;
            this.selMessageMode.Click += new System.EventHandler(this.SelMessageMode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10);
            this.btnClose.Size = new System.Drawing.Size(38, 33);
            this.btnClose.Text = "x";
            this.btnClose.ToolTipText = "Close";
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel2.Image = global::DRRMIS_GSM_Client.Properties.Resources.cog_white_128px;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripLabel2.Size = new System.Drawing.Size(26, 32);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 32);
            this.toolStripLabel1.Text = "Settings";
            // 
            // toolStripMain
            // 
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripLabel2,
            this.toolStripLabel1});
            this.toolStripMain.Location = new System.Drawing.Point(1, 1);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMain.Size = new System.Drawing.Size(336, 40);
            this.toolStripMain.Stretch = true;
            this.toolStripMain.TabIndex = 7;
            this.toolStripMain.Text = "toolStrip1";
            this.toolStripMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStripMain_MouseDown);
            // 
            // SelectSerialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(338, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectSerialForm";
            this.Opacity = 0.98D;
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SelectSerialForm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSerialPort.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnConSelSerial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpSerialPort;
        public System.Windows.Forms.ComboBox selSerialPort;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStripMain;
        public System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ComboBox selMessageMode;
    }
}