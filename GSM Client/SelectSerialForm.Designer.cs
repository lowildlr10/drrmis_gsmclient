
namespace GSM_Client
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
            this.btnConSelSerial = new System.Windows.Forms.Button();
            this.grpSerialPort = new System.Windows.Forms.GroupBox();
            this.selSerialPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.grpSerialPort.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConSelSerial
            // 
            this.btnConSelSerial.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConSelSerial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConSelSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConSelSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConSelSerial.ForeColor = System.Drawing.Color.White;
            this.btnConSelSerial.Location = new System.Drawing.Point(25, 196);
            this.btnConSelSerial.Name = "btnConSelSerial";
            this.btnConSelSerial.Size = new System.Drawing.Size(290, 33);
            this.btnConSelSerial.TabIndex = 1;
            this.btnConSelSerial.Text = "Apply";
            this.btnConSelSerial.UseVisualStyleBackColor = false;
            this.btnConSelSerial.Click += new System.EventHandler(this.btnConSelSerial_Click);
            // 
            // grpSerialPort
            // 
            this.grpSerialPort.Controls.Add(this.selSerialPort);
            this.grpSerialPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpSerialPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSerialPort.ForeColor = System.Drawing.Color.White;
            this.grpSerialPort.Location = new System.Drawing.Point(25, 23);
            this.grpSerialPort.Name = "grpSerialPort";
            this.grpSerialPort.Size = new System.Drawing.Size(290, 68);
            this.grpSerialPort.TabIndex = 3;
            this.grpSerialPort.TabStop = false;
            this.grpSerialPort.Text = "Serial Port";
            // 
            // selSerialPort
            // 
            this.selSerialPort.BackColor = System.Drawing.Color.White;
            this.selSerialPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selSerialPort.DropDownHeight = 150;
            this.selSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selSerialPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selSerialPort.ForeColor = System.Drawing.Color.Black;
            this.selSerialPort.FormattingEnabled = true;
            this.selSerialPort.IntegralHeight = false;
            this.selSerialPort.Location = new System.Drawing.Point(12, 27);
            this.selSerialPort.Name = "selSerialPort";
            this.selSerialPort.Size = new System.Drawing.Size(265, 23);
            this.selSerialPort.Sorted = true;
            this.selSerialPort.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBaudRate);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(25, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Baud Rate";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaudRate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaudRate.Location = new System.Drawing.Point(12, 27);
            this.txtBaudRate.MaxLength = 10;
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(265, 23);
            this.txtBaudRate.TabIndex = 2;
            this.txtBaudRate.Text = "9600";
            this.txtBaudRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaudRate_KeyPress);
            // 
            // SelectSerialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(338, 257);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSerialPort);
            this.Controls.Add(this.btnConSelSerial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectSerialForm";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SelectSerialForm_Load);
            this.grpSerialPort.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConSelSerial;
        private System.Windows.Forms.GroupBox grpSerialPort;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox selSerialPort;
        public System.Windows.Forms.TextBox txtBaudRate;
    }
}