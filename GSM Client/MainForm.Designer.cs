
namespace DRRMIS_GSM_Client
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
            this.toolStripIconLoading = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripIconConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripIconDisconnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSerialMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnUser = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuUsername = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.btnSerialMonitor = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnectSerial = new System.Windows.Forms.ToolStripButton();
            this.btnConnectSerial = new System.Windows.Forms.ToolStripButton();
            this.btnSend = new System.Windows.Forms.ToolStripButton();
            this.btnRecipients = new System.Windows.Forms.ToolStripButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpSerialPortDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProvider = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblPortName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatusGSM = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSignalStrength = new System.Windows.Forms.Label();
            this.picSignalStatus = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.selRecipients = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecipientsCount = new System.Windows.Forms.Label();
            this.lblMsgCount = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSerialStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGsmStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConnectSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisonnectSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.timerMonitorPort = new System.Windows.Forms.Timer(this.components);
            this.timerRefreshSignal = new System.Windows.Forms.Timer(this.components);
            this.backgroundSendMsg = new System.ComponentModel.BackgroundWorker();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnMinimize = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.timerSendApi = new System.Windows.Forms.Timer(this.components);
            this.mainStatusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpSerialPortDetails.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignalStatus)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.contextMenuStripTray.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // comPort
            // 
            this.comPort.PortName = " ";
            this.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ComPort_DataReceived);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.AutoSize = false;
            this.mainStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripIconLoading,
            this.toolStripIconConnected,
            this.toolStripIconDisconnected,
            this.toolStripStatusLabel});
            this.mainStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainStatusStrip.Location = new System.Drawing.Point(2, 583);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(996, 28);
            this.mainStatusStrip.SizingGrip = false;
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "mainStatusStrip";
            // 
            // toolStripIconLoading
            // 
            this.toolStripIconLoading.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripIconLoading.BackColor = System.Drawing.Color.Transparent;
            this.toolStripIconLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripIconLoading.Image = global::DRRMIS_GSM_Client.Properties.Resources.loader;
            this.toolStripIconLoading.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripIconLoading.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.toolStripIconLoading.Name = "toolStripIconLoading";
            this.toolStripIconLoading.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripIconLoading.Size = new System.Drawing.Size(26, 23);
            this.toolStripIconLoading.Text = "toolStripStatusConnected";
            this.toolStripIconLoading.Visible = false;
            // 
            // toolStripIconConnected
            // 
            this.toolStripIconConnected.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripIconConnected.BackColor = System.Drawing.Color.Transparent;
            this.toolStripIconConnected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripIconConnected.Image = global::DRRMIS_GSM_Client.Properties.Resources.check_circle_green;
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
            this.toolStripIconDisconnected.Image = global::DRRMIS_GSM_Client.Properties.Resources.times_circle_red;
            this.toolStripIconDisconnected.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.toolStripIconDisconnected.Name = "toolStripIconDisconnected";
            this.toolStripIconDisconnected.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripIconDisconnected.Size = new System.Drawing.Size(26, 23);
            this.toolStripIconDisconnected.Text = "toolStripStatusDisconnected";
            this.toolStripIconDisconnected.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 23);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuConnect,
            this.toolStripMenuDisconnect,
            this.toolStripMenuSettings,
            this.toolStripSeparator1,
            this.toolStripMenuExit});
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
            this.toolStripMenuConnect.Click += new System.EventHandler(this.ToolStripMenuConnect_Click);
            // 
            // toolStripMenuDisconnect
            // 
            this.toolStripMenuDisconnect.Name = "toolStripMenuDisconnect";
            this.toolStripMenuDisconnect.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuDisconnect.Text = "Disconnect...";
            this.toolStripMenuDisconnect.Visible = false;
            this.toolStripMenuDisconnect.Click += new System.EventHandler(this.ToolStripMenuDisconnect_Click);
            // 
            // toolStripMenuSettings
            // 
            this.toolStripMenuSettings.Name = "toolStripMenuSettings";
            this.toolStripMenuSettings.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuSettings.Text = "Settings";
            this.toolStripMenuSettings.Click += new System.EventHandler(this.ToolStripMenuSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // toolStripMenuExit
            // 
            this.toolStripMenuExit.Name = "toolStripMenuExit";
            this.toolStripMenuExit.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuExit.Text = "Exit";
            this.toolStripMenuExit.Click += new System.EventHandler(this.ToolStripMenuExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAbout});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuAbout
            // 
            this.toolStripMenuAbout.Name = "toolStripMenuAbout";
            this.toolStripMenuAbout.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuAbout.Text = "About";
            this.toolStripMenuAbout.Click += new System.EventHandler(this.ToolStripMenuAbout_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(2, 40);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(996, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuSerialMonitor});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolStripMenuSerialMonitor
            // 
            this.toolStripMenuSerialMonitor.Enabled = false;
            this.toolStripMenuSerialMonitor.Name = "toolStripMenuSerialMonitor";
            this.toolStripMenuSerialMonitor.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuSerialMonitor.Text = "Serial Monitor";
            this.toolStripMenuSerialMonitor.Click += new System.EventHandler(this.ToolStripMenuSerialMonitor_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(87)))), ((int)(((byte)(92)))));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUser,
            this.toolStripSeparator2,
            this.btnSettings,
            this.btnSerialMonitor,
            this.btnDisconnectSerial,
            this.btnConnectSerial,
            this.btnSend,
            this.btnRecipients});
            this.toolStrip.Location = new System.Drawing.Point(2, 64);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(10, 4, 10, 5);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(996, 65);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "mainToolStrip";
            // 
            // btnUser
            // 
            this.btnUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnUser.AutoSize = false;
            this.btnUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuUsername,
            this.toolStripSeparator3,
            this.toolStripMenuLogout});
            this.btnUser.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = global::DRRMIS_GSM_Client.Properties.Resources.user_white;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUser.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUser.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnUser.Name = "btnUser";
            this.btnUser.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnUser.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnUser.ShowDropDownArrow = false;
            this.btnUser.Size = new System.Drawing.Size(70, 59);
            this.btnUser.Text = "User";
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUser.ToolTipText = "Settings";
            // 
            // toolStripMenuUsername
            // 
            this.toolStripMenuUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuUsername.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripMenuUsername.Name = "toolStripMenuUsername";
            this.toolStripMenuUsername.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripMenuUsername.Size = new System.Drawing.Size(129, 26);
            this.toolStripMenuUsername.Text = "Username";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(126, 6);
            // 
            // toolStripMenuLogout
            // 
            this.toolStripMenuLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuLogout.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripMenuLogout.Name = "toolStripMenuLogout";
            this.toolStripMenuLogout.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripMenuLogout.Size = new System.Drawing.Size(129, 26);
            this.toolStripMenuLogout.Text = "Logout";
            this.toolStripMenuLogout.Click += new System.EventHandler(this.ToolStripMenuLogout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 56);
            // 
            // btnSettings
            // 
            this.btnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSettings.AutoSize = false;
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::DRRMIS_GSM_Client.Properties.Resources.cog_white;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnSettings.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnSettings.Size = new System.Drawing.Size(70, 59);
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSettings.ToolTipText = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnSerialMonitor
            // 
            this.btnSerialMonitor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSerialMonitor.AutoSize = false;
            this.btnSerialMonitor.BackColor = System.Drawing.Color.Transparent;
            this.btnSerialMonitor.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialMonitor.ForeColor = System.Drawing.Color.White;
            this.btnSerialMonitor.Image = global::DRRMIS_GSM_Client.Properties.Resources.tv_white;
            this.btnSerialMonitor.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialMonitor.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSerialMonitor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnSerialMonitor.Name = "btnSerialMonitor";
            this.btnSerialMonitor.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnSerialMonitor.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnSerialMonitor.Size = new System.Drawing.Size(70, 59);
            this.btnSerialMonitor.Text = "Monitor";
            this.btnSerialMonitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSerialMonitor.Visible = false;
            this.btnSerialMonitor.Click += new System.EventHandler(this.BtnSerialMonitor_Click);
            // 
            // btnDisconnectSerial
            // 
            this.btnDisconnectSerial.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDisconnectSerial.AutoSize = false;
            this.btnDisconnectSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnDisconnectSerial.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnectSerial.ForeColor = System.Drawing.Color.White;
            this.btnDisconnectSerial.Image = global::DRRMIS_GSM_Client.Properties.Resources.unlink_white;
            this.btnDisconnectSerial.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDisconnectSerial.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDisconnectSerial.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnDisconnectSerial.Name = "btnDisconnectSerial";
            this.btnDisconnectSerial.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnDisconnectSerial.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnDisconnectSerial.Size = new System.Drawing.Size(70, 59);
            this.btnDisconnectSerial.Text = "Disconnect";
            this.btnDisconnectSerial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDisconnectSerial.Visible = false;
            this.btnDisconnectSerial.Click += new System.EventHandler(this.BtnDisconnectSerial_Click);
            // 
            // btnConnectSerial
            // 
            this.btnConnectSerial.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConnectSerial.AutoSize = false;
            this.btnConnectSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnConnectSerial.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectSerial.ForeColor = System.Drawing.Color.White;
            this.btnConnectSerial.Image = global::DRRMIS_GSM_Client.Properties.Resources.plug_white;
            this.btnConnectSerial.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnectSerial.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConnectSerial.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnConnectSerial.Name = "btnConnectSerial";
            this.btnConnectSerial.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnConnectSerial.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnConnectSerial.Size = new System.Drawing.Size(70, 59);
            this.btnConnectSerial.Text = "Connect";
            this.btnConnectSerial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConnectSerial.Click += new System.EventHandler(this.BtnConnectSerial_Click);
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = false;
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = global::DRRMIS_GSM_Client.Properties.Resources.paper_plane_white;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSend.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSend.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnSend.Name = "btnSend";
            this.btnSend.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnSend.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnSend.Size = new System.Drawing.Size(70, 59);
            this.btnSend.Text = "Send";
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // btnRecipients
            // 
            this.btnRecipients.AutoSize = false;
            this.btnRecipients.BackColor = System.Drawing.Color.Transparent;
            this.btnRecipients.Enabled = false;
            this.btnRecipients.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecipients.ForeColor = System.Drawing.Color.White;
            this.btnRecipients.Image = global::DRRMIS_GSM_Client.Properties.Resources.address_book_white;
            this.btnRecipients.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecipients.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRecipients.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnRecipients.Name = "btnRecipients";
            this.btnRecipients.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnRecipients.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.btnRecipients.Size = new System.Drawing.Size(70, 59);
            this.btnRecipients.Text = "Recipients";
            this.btnRecipients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecipients.Click += new System.EventHandler(this.BtnRecipients_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(2, 129);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mainPanel.Size = new System.Drawing.Size(996, 454);
            this.mainPanel.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.48325F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.7655503F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.6555F));
            this.tableLayoutPanel1.Controls.Add(this.grpSerialPortDetails, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 454);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grpSerialPortDetails
            // 
            this.grpSerialPortDetails.Controls.Add(this.tableLayoutPanel4);
            this.grpSerialPortDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSerialPortDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpSerialPortDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSerialPortDetails.Location = new System.Drawing.Point(719, 10);
            this.grpSerialPortDetails.Margin = new System.Windows.Forms.Padding(3, 10, 15, 15);
            this.grpSerialPortDetails.Name = "grpSerialPortDetails";
            this.grpSerialPortDetails.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.grpSerialPortDetails.Size = new System.Drawing.Size(258, 429);
            this.grpSerialPortDetails.TabIndex = 0;
            this.grpSerialPortDetails.TabStop = false;
            this.grpSerialPortDetails.Text = "DEVICE DETAILS";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.96386F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.03614F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.lblProvider, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.lblBaudRate, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.lblPortName, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblStatus, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblStatusGSM, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(252, 406);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 343);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 60);
            this.label2.TabIndex = 16;
            this.label2.Text = "Provider:";
            this.label2.Visible = false;
            // 
            // lblProvider
            // 
            this.lblProvider.BackColor = System.Drawing.Color.White;
            this.lblProvider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProvider.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvider.Location = new System.Drawing.Point(106, 343);
            this.lblProvider.Margin = new System.Windows.Forms.Padding(3);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(143, 60);
            this.lblProvider.TabIndex = 15;
            this.lblProvider.Text = "N/A";
            this.lblProvider.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 283);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 54);
            this.label7.TabIndex = 14;
            this.label7.Text = "Signal:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.BackColor = System.Drawing.Color.White;
            this.lblBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBaudRate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaudRate.Location = new System.Drawing.Point(106, 163);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(3);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(143, 54);
            this.lblBaudRate.TabIndex = 9;
            this.lblBaudRate.Text = "N/A";
            // 
            // lblPortName
            // 
            this.lblPortName.BackColor = System.Drawing.Color.White;
            this.lblPortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPortName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPortName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortName.Location = new System.Drawing.Point(106, 103);
            this.lblPortName.Margin = new System.Windows.Forms.Padding(3);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(143, 54);
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
            this.lblStatus.Location = new System.Drawing.Point(106, 43);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(143, 54);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Disconnected";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 54);
            this.label5.TabIndex = 6;
            this.label5.Text = "Baud Rate:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 54);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port Name:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port Status:";
            // 
            // lblStatusGSM
            // 
            this.lblStatusGSM.BackColor = System.Drawing.Color.White;
            this.lblStatusGSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusGSM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatusGSM.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusGSM.ForeColor = System.Drawing.Color.Red;
            this.lblStatusGSM.Location = new System.Drawing.Point(106, 223);
            this.lblStatusGSM.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatusGSM.Name = "lblStatusGSM";
            this.lblStatusGSM.Size = new System.Drawing.Size(143, 54);
            this.lblStatusGSM.TabIndex = 10;
            this.lblStatusGSM.Text = "Disconnected";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 54);
            this.label4.TabIndex = 13;
            this.label4.Text = "GSM Status:";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.32653F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.67347F));
            this.tableLayoutPanel6.Controls.Add(this.lblSignalStrength, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.picSignalStatus, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(103, 280);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(147, 53);
            this.tableLayoutPanel6.TabIndex = 17;
            // 
            // lblSignalStrength
            // 
            this.lblSignalStrength.BackColor = System.Drawing.Color.White;
            this.lblSignalStrength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSignalStrength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSignalStrength.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignalStrength.Location = new System.Drawing.Point(26, 3);
            this.lblSignalStrength.Margin = new System.Windows.Forms.Padding(3);
            this.lblSignalStrength.Name = "lblSignalStrength";
            this.lblSignalStrength.Size = new System.Drawing.Size(118, 47);
            this.lblSignalStrength.TabIndex = 13;
            this.lblSignalStrength.Text = "0% (No Signal)";
            // 
            // picSignalStatus
            // 
            this.picSignalStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSignalStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSignalStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSignalStatus.Image = global::DRRMIS_GSM_Client.Properties.Resources.signal_slash_32px;
            this.picSignalStatus.InitialImage = global::DRRMIS_GSM_Client.Properties.Resources.signal_slash_32px;
            this.picSignalStatus.Location = new System.Drawing.Point(5, 3);
            this.picSignalStatus.Margin = new System.Windows.Forms.Padding(5, 3, 0, 35);
            this.picSignalStatus.Name = "picSignalStatus";
            this.picSignalStatus.Padding = new System.Windows.Forms.Padding(1);
            this.picSignalStatus.Size = new System.Drawing.Size(18, 15);
            this.picSignalStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSignalStatus.TabIndex = 15;
            this.picSignalStatus.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtMessage, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.908046F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.32184F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(703, 448);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(15, 86);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(15, 3, 5, 15);
            this.txtMessage.MaxLength = 9999;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(683, 347);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.TextChanged += new System.EventHandler(this.TxtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_KeyDown);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.36842F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.63158F));
            this.tableLayoutPanel3.Controls.Add(this.selRecipients, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(697, 38);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // selRecipients
            // 
            this.selRecipients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selRecipients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selRecipients.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selRecipients.FormattingEnabled = true;
            this.selRecipients.Location = new System.Drawing.Point(12, 2);
            this.selRecipients.Margin = new System.Windows.Forms.Padding(12, 2, 2, 2);
            this.selRecipients.Name = "selRecipients";
            this.selRecipients.Size = new System.Drawing.Size(683, 28);
            this.selRecipients.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lblRecipientsCount, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblMsgCount, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(13, 47);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(687, 33);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // lblRecipientsCount
            // 
            this.lblRecipientsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecipientsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecipientsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecipientsCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipientsCount.Location = new System.Drawing.Point(2, 2);
            this.lblRecipientsCount.Margin = new System.Windows.Forms.Padding(2);
            this.lblRecipientsCount.Name = "lblRecipientsCount";
            this.lblRecipientsCount.Size = new System.Drawing.Size(339, 29);
            this.lblRecipientsCount.TabIndex = 1;
            this.lblRecipientsCount.Text = "Recipient: 0";
            this.lblRecipientsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecipientsCount.Click += new System.EventHandler(this.LblRecipientsCount_Click);
            // 
            // lblMsgCount
            // 
            this.lblMsgCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsgCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMsgCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMsgCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgCount.Location = new System.Drawing.Point(345, 2);
            this.lblMsgCount.Margin = new System.Windows.Forms.Padding(2);
            this.lblMsgCount.Name = "lblMsgCount";
            this.lblMsgCount.Size = new System.Drawing.Size(340, 29);
            this.lblMsgCount.TabIndex = 0;
            this.lblMsgCount.Text = "Message Charater: 0";
            this.lblMsgCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Application is running in the background.";
            this.notifyIcon.BalloonTipTitle = "Minimize";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "DRRMIS GSM Client";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItemShowForm,
            this.toolStripSeparator4,
            this.toolStripMenuItemSerialStatus,
            this.toolStripMenuItemGsmStatus,
            this.toolStripMenuItemConnectSerial,
            this.toolStripMenuItemDisonnectSerial,
            this.toolStripMenuItemSettings,
            this.toolStripSeparator5,
            this.toolStripMenuItemExitApp});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(187, 212);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem1.Text = "DRRMIS GSM Client";
            // 
            // toolStripMenuItemShowForm
            // 
            this.toolStripMenuItemShowForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemShowForm.Name = "toolStripMenuItemShowForm";
            this.toolStripMenuItemShowForm.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemShowForm.Text = "Show Client";
            this.toolStripMenuItemShowForm.ToolTipText = "Show Client";
            this.toolStripMenuItemShowForm.Click += new System.EventHandler(this.ToolStripMenuItemShowForm_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(183, 6);
            // 
            // toolStripMenuItemSerialStatus
            // 
            this.toolStripMenuItemSerialStatus.Enabled = false;
            this.toolStripMenuItemSerialStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemSerialStatus.Name = "toolStripMenuItemSerialStatus";
            this.toolStripMenuItemSerialStatus.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemSerialStatus.Text = "COM Status:";
            // 
            // toolStripMenuItemGsmStatus
            // 
            this.toolStripMenuItemGsmStatus.Enabled = false;
            this.toolStripMenuItemGsmStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItemGsmStatus.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.toolStripMenuItemGsmStatus.Name = "toolStripMenuItemGsmStatus";
            this.toolStripMenuItemGsmStatus.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemGsmStatus.Text = "GSM Status: ";
            // 
            // toolStripMenuItemConnectSerial
            // 
            this.toolStripMenuItemConnectSerial.Name = "toolStripMenuItemConnectSerial";
            this.toolStripMenuItemConnectSerial.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemConnectSerial.Text = "Connect...";
            this.toolStripMenuItemConnectSerial.ToolTipText = "Connect to Serial Port";
            this.toolStripMenuItemConnectSerial.Click += new System.EventHandler(this.ToolStripMenuItemConnectSerial_Click);
            // 
            // toolStripMenuItemDisonnectSerial
            // 
            this.toolStripMenuItemDisonnectSerial.Name = "toolStripMenuItemDisonnectSerial";
            this.toolStripMenuItemDisonnectSerial.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemDisonnectSerial.Text = "Disconnect...";
            this.toolStripMenuItemDisonnectSerial.ToolTipText = "Disconnect from the Serial Port";
            this.toolStripMenuItemDisonnectSerial.Visible = false;
            this.toolStripMenuItemDisonnectSerial.Click += new System.EventHandler(this.ToolStripMenuItemDisonnectSerial_Click);
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemSettings.Text = "Settings";
            this.toolStripMenuItemSettings.ToolTipText = "Show Settings";
            this.toolStripMenuItemSettings.Click += new System.EventHandler(this.ToolStripMenuItemSettings_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(183, 6);
            // 
            // toolStripMenuItemExitApp
            // 
            this.toolStripMenuItemExitApp.Name = "toolStripMenuItemExitApp";
            this.toolStripMenuItemExitApp.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemExitApp.Text = "Exit";
            this.toolStripMenuItemExitApp.ToolTipText = "Exit Application";
            this.toolStripMenuItemExitApp.Click += new System.EventHandler(this.ToolStripMenuItemExitApp_Click);
            // 
            // timerMonitorPort
            // 
            this.timerMonitorPort.Enabled = true;
            this.timerMonitorPort.Interval = 300;
            this.timerMonitorPort.Tick += new System.EventHandler(this.TimerMonitorPort_Tick);
            // 
            // timerRefreshSignal
            // 
            this.timerRefreshSignal.Enabled = true;
            this.timerRefreshSignal.Interval = 1000;
            this.timerRefreshSignal.Tick += new System.EventHandler(this.TimerRefreshSignal_Tick);
            // 
            // backgroundSendMsg
            // 
            this.backgroundSendMsg.WorkerReportsProgress = true;
            this.backgroundSendMsg.WorkerSupportsCancellation = true;
            // 
            // toolStripMain
            // 
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnMinimize,
            this.toolStripLabel2,
            this.toolStripLabel1});
            this.toolStripMain.Location = new System.Drawing.Point(2, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMain.Size = new System.Drawing.Size(996, 40);
            this.toolStripMain.Stretch = true;
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            this.toolStripMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStripMain_MouseDown);
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
            // btnMinimize
            // 
            this.btnMinimize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Padding = new System.Windows.Forms.Padding(10);
            this.btnMinimize.Size = new System.Drawing.Size(37, 33);
            this.btnMinimize.Text = "_";
            this.btnMinimize.ToolTipText = "Minimize";
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel2.Image = global::DRRMIS_GSM_Client.Properties.Resources.drrmis_ico;
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
            this.toolStripLabel1.Size = new System.Drawing.Size(119, 32);
            this.toolStripLabel1.Text = "DRRMIS GSM Client";
            // 
            // timerSendApi
            // 
            this.timerSendApi.Interval = 1000;
            this.timerSendApi.Tick += new System.EventHandler(this.TimerSendApi_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1000, 611);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.toolStripMain);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 550);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DRRMIS GSM Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
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
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSignalStatus)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.contextMenuStripTray.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAbout;
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
        private System.Windows.Forms.TextBox txtMessage;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSerialMonitor;
        private System.Windows.Forms.Timer timerMonitorPort;
        private System.Windows.Forms.ToolStripButton btnRecipients;
        public System.Windows.Forms.ComboBox selRecipients;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblMsgCount;
        private System.Windows.Forms.Label lblRecipientsCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStatusGSM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripIconLoading;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.Timer timerRefreshSignal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblSignalStrength;
        private System.Windows.Forms.PictureBox picSignalStatus;
        private System.ComponentModel.BackgroundWorker backgroundSendMsg;
        private System.Windows.Forms.ToolStripDropDownButton btnUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUsername;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExitApp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSerialStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGsmStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnectSerial;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisonnectSerial;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnMinimize;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Timer timerSendApi;
    }
}

