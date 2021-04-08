
namespace GSM_Client
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpSerialPortDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblPortName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.btnSerialMonitor = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnectSerial = new System.Windows.Forms.ToolStripButton();
            this.btnConnectSerial = new System.Windows.Forms.ToolStripButton();
            this.btnSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripIconConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripIconDisconnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpSerialPortDetails.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comPort
            // 
            this.comPort.PortName = " ";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.AutoSize = false;
            this.mainStatusStrip.BackColor = System.Drawing.SystemColors.Desktop;
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripIconConnected,
            this.toolStripIconDisconnected,
            this.toolStripStatusLabel});
            this.mainStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 433);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(784, 28);
            this.mainStatusStrip.SizingGrip = false;
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "mainStatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 23);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "CSV files (*.csv)|*.csv\"";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuConnect,
            this.toolStripMenuDisconnect,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuConnect
            // 
            this.toolStripMenuConnect.Name = "toolStripMenuConnect";
            this.toolStripMenuConnect.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuConnect.Text = "Connect...";
            this.toolStripMenuConnect.Click += new System.EventHandler(this.toolStripMenuConnect_Click);
            // 
            // toolStripMenuDisconnect
            // 
            this.toolStripMenuDisconnect.Name = "toolStripMenuDisconnect";
            this.toolStripMenuDisconnect.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuDisconnect.Text = "Disconnect...";
            this.toolStripMenuDisconnect.Visible = false;
            this.toolStripMenuDisconnect.Click += new System.EventHandler(this.toolStripMenuDisconnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.Desktop;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.SlateGray;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings,
            this.btnSerialMonitor,
            this.btnDisconnectSerial,
            this.btnConnectSerial,
            this.btnSend});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(10, 2, 10, 4);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(784, 55);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "mainToolStrip";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 79);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(784, 354);
            this.mainPanel.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.grpSerialPortDetails, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 354);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grpSerialPortDetails
            // 
            this.grpSerialPortDetails.Controls.Add(this.tableLayoutPanel4);
            this.grpSerialPortDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSerialPortDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpSerialPortDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSerialPortDetails.Location = new System.Drawing.Point(551, 10);
            this.grpSerialPortDetails.Margin = new System.Windows.Forms.Padding(3, 10, 3, 15);
            this.grpSerialPortDetails.Name = "grpSerialPortDetails";
            this.grpSerialPortDetails.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.grpSerialPortDetails.Size = new System.Drawing.Size(230, 329);
            this.grpSerialPortDetails.TabIndex = 0;
            this.grpSerialPortDetails.TabStop = false;
            this.grpSerialPortDetails.Text = "DEVICE DETAILS";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.64912F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.35088F));
            this.tableLayoutPanel4.Controls.Add(this.lblBaudRate, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.lblPortName, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblStatus, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(224, 274);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.BackColor = System.Drawing.Color.White;
            this.lblBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBaudRate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaudRate.Location = new System.Drawing.Point(80, 150);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(141, 60);
            this.lblBaudRate.TabIndex = 9;
            this.lblBaudRate.Text = "N/A";
            // 
            // lblPortName
            // 
            this.lblPortName.BackColor = System.Drawing.Color.White;
            this.lblPortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPortName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPortName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortName.Location = new System.Drawing.Point(80, 90);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(141, 60);
            this.lblPortName.TabIndex = 8;
            this.lblPortName.Text = "N/A";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(80, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(141, 60);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Disconnected";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 60);
            this.label5.TabIndex = 6;
            this.label5.Text = "Baud Rate:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 60);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port Name:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.21839F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.78161F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(519, 348);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 48);
            this.textBox1.Margin = new System.Windows.Forms.Padding(15, 3, 0, 15);
            this.textBox1.MaxLength = 255;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(504, 285);
            this.textBox1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.6563F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.3437F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(513, 39);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::GSM_Client.Properties.Resources.cog_white;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnSettings.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnSettings.Size = new System.Drawing.Size(67, 47);
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSettings.ToolTipText = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnSerialMonitor
            // 
            this.btnSerialMonitor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSerialMonitor.BackColor = System.Drawing.Color.Transparent;
            this.btnSerialMonitor.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialMonitor.ForeColor = System.Drawing.Color.White;
            this.btnSerialMonitor.Image = global::GSM_Client.Properties.Resources.tv_white;
            this.btnSerialMonitor.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialMonitor.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSerialMonitor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnSerialMonitor.Name = "btnSerialMonitor";
            this.btnSerialMonitor.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnSerialMonitor.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnSerialMonitor.Size = new System.Drawing.Size(68, 47);
            this.btnSerialMonitor.Text = "Monitor";
            this.btnSerialMonitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSerialMonitor.Visible = false;
            this.btnSerialMonitor.Click += new System.EventHandler(this.btnSerialMonitor_Click);
            // 
            // btnDisconnectSerial
            // 
            this.btnDisconnectSerial.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDisconnectSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnDisconnectSerial.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnectSerial.ForeColor = System.Drawing.Color.White;
            this.btnDisconnectSerial.Image = global::GSM_Client.Properties.Resources.unlink_white;
            this.btnDisconnectSerial.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDisconnectSerial.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDisconnectSerial.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnDisconnectSerial.Name = "btnDisconnectSerial";
            this.btnDisconnectSerial.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnDisconnectSerial.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnDisconnectSerial.Size = new System.Drawing.Size(80, 47);
            this.btnDisconnectSerial.Text = "Disconnect";
            this.btnDisconnectSerial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDisconnectSerial.Visible = false;
            this.btnDisconnectSerial.Click += new System.EventHandler(this.btnDisconnectSerial_Click);
            // 
            // btnConnectSerial
            // 
            this.btnConnectSerial.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConnectSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnConnectSerial.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectSerial.ForeColor = System.Drawing.Color.White;
            this.btnConnectSerial.Image = global::GSM_Client.Properties.Resources.plug_white;
            this.btnConnectSerial.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnectSerial.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConnectSerial.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnConnectSerial.Name = "btnConnectSerial";
            this.btnConnectSerial.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnConnectSerial.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnConnectSerial.Size = new System.Drawing.Size(67, 47);
            this.btnConnectSerial.Text = "Connect";
            this.btnConnectSerial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConnectSerial.Click += new System.EventHandler(this.btnConnectSerial_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = global::GSM_Client.Properties.Resources.paper_plane_white;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSend.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSend.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnSend.Name = "btnSend";
            this.btnSend.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnSend.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnSend.Size = new System.Drawing.Size(52, 47);
            this.btnSend.Text = "Send";
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripIconConnected
            // 
            this.toolStripIconConnected.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripIconConnected.BackColor = System.Drawing.Color.Transparent;
            this.toolStripIconConnected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripIconConnected.Image = global::GSM_Client.Properties.Resources.check_circle_green;
            this.toolStripIconConnected.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.toolStripIconConnected.Name = "toolStripIconConnected";
            this.toolStripIconConnected.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripIconConnected.Size = new System.Drawing.Size(26, 23);
            this.toolStripIconConnected.Text = "toolStripStatusConnected";
            this.toolStripIconConnected.Visible = false;
            // 
            // toolStripIconDisconnected
            // 
            this.toolStripIconDisconnected.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripIconDisconnected.BackColor = System.Drawing.Color.Transparent;
            this.toolStripIconDisconnected.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripIconDisconnected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripIconDisconnected.Image = global::GSM_Client.Properties.Resources.times_circle_red;
            this.toolStripIconDisconnected.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.toolStripIconDisconnected.Name = "toolStripIconDisconnected";
            this.toolStripIconDisconnected.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripIconDisconnected.Size = new System.Drawing.Size(26, 23);
            this.toolStripIconDisconnected.Text = "toolStripStatusDisconnected";
            this.toolStripIconDisconnected.Visible = false;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialMonitorToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // serialMonitorToolStripMenuItem
            // 
            this.serialMonitorToolStripMenuItem.Enabled = false;
            this.serialMonitorToolStripMenuItem.Name = "serialMonitorToolStripMenuItem";
            this.serialMonitorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serialMonitorToolStripMenuItem.Text = "Serial Monitor";
            this.serialMonitorToolStripMenuItem.Click += new System.EventHandler(this.serialMonitorToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSM Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpSerialPortDetails.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnConnectSerial;
        private System.Windows.Forms.ToolStripButton btnDisconnectSerial;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDisconnect;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripButton btnSend;
        private System.Windows.Forms.ToolStripStatusLabel toolStripIconConnected;
        private System.Windows.Forms.ToolStripStatusLabel toolStripIconDisconnected;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpSerialPortDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        public System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.ToolStripButton btnSerialMonitor;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialMonitorToolStripMenuItem;
    }
}

