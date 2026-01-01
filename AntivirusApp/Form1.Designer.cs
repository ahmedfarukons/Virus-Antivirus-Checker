namespace AntivirusApp;

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
        this.tabControl = new System.Windows.Forms.TabControl();
        this.tabScan = new System.Windows.Forms.TabPage();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.chkRecursive = new System.Windows.Forms.CheckBox();
        this.btnSelectFolder = new System.Windows.Forms.Button();
        this.txtScanPath = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.btnStopScan = new System.Windows.Forms.Button();
        this.btnStartScan = new System.Windows.Forms.Button();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.lblThreatsFound = new System.Windows.Forms.Label();
        this.lblProgress = new System.Windows.Forms.Label();
        this.progressBar = new System.Windows.Forms.ProgressBar();
        this.groupBox3 = new System.Windows.Forms.GroupBox();
        this.dgvThreats = new System.Windows.Forms.DataGridView();
        this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colThreat = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.panel1 = new System.Windows.Forms.Panel();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnQuarantine = new System.Windows.Forms.Button();
        this.tabQuarantine = new System.Windows.Forms.TabPage();
        this.dgvQuarantine = new System.Windows.Forms.DataGridView();
        this.colQFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colQThreat = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colQDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colQSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.panel2 = new System.Windows.Forms.Panel();
        this.btnDeleteFromQuarantine = new System.Windows.Forms.Button();
        this.btnRestoreFromQuarantine = new System.Windows.Forms.Button();
        this.tabProtection = new System.Windows.Forms.TabPage();
        this.groupBox4 = new System.Windows.Forms.GroupBox();
        this.lblRealtimeStatus = new System.Windows.Forms.Label();
        this.chkRealtimeProtection = new System.Windows.Forms.CheckBox();
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
        this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblDatabaseCount = new System.Windows.Forms.ToolStripStatusLabel();
        this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblQuarantineCount = new System.Windows.Forms.ToolStripStatusLabel();
        this.tabControl.SuspendLayout();
        this.tabScan.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.groupBox3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvThreats)).BeginInit();
        this.panel1.SuspendLayout();
        this.tabQuarantine.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvQuarantine)).BeginInit();
        this.panel2.SuspendLayout();
        this.tabProtection.SuspendLayout();
        this.groupBox4.SuspendLayout();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();
        // 
        // tabControl
        // 
        this.tabControl.Controls.Add(this.tabScan);
        this.tabControl.Controls.Add(this.tabQuarantine);
        this.tabControl.Controls.Add(this.tabProtection);
        this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControl.Location = new System.Drawing.Point(0, 0);
        this.tabControl.Name = "tabControl";
        this.tabControl.SelectedIndex = 0;
        this.tabControl.Size = new System.Drawing.Size(1000, 600);
        this.tabControl.TabIndex = 0;
        // 
        // tabScan
        // 
        this.tabScan.Controls.Add(this.groupBox3);
        this.tabScan.Controls.Add(this.groupBox2);
        this.tabScan.Controls.Add(this.groupBox1);
        this.tabScan.Location = new System.Drawing.Point(4, 29);
        this.tabScan.Name = "tabScan";
        this.tabScan.Padding = new System.Windows.Forms.Padding(3);
        this.tabScan.Size = new System.Drawing.Size(992, 567);
        this.tabScan.TabIndex = 0;
        this.tabScan.Text = "Tarama";
        this.tabScan.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.chkRecursive);
        this.groupBox1.Controls.Add(this.btnSelectFolder);
        this.groupBox1.Controls.Add(this.txtScanPath);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Controls.Add(this.btnStopScan);
        this.groupBox1.Controls.Add(this.btnStartScan);
        this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBox1.Location = new System.Drawing.Point(3, 3);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(986, 120);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Tarama Ayarları";
        // 
        // chkRecursive
        // 
        this.chkRecursive.AutoSize = true;
        this.chkRecursive.Checked = true;
        this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkRecursive.Location = new System.Drawing.Point(15, 85);
        this.chkRecursive.Name = "chkRecursive";
        this.chkRecursive.Size = new System.Drawing.Size(198, 24);
        this.chkRecursive.TabIndex = 5;
        this.chkRecursive.Text = "Alt klasörleri de tara";
        this.chkRecursive.UseVisualStyleBackColor = true;
        // 
        // btnSelectFolder
        // 
        this.btnSelectFolder.Location = new System.Drawing.Point(850, 35);
        this.btnSelectFolder.Name = "btnSelectFolder";
        this.btnSelectFolder.Size = new System.Drawing.Size(120, 35);
        this.btnSelectFolder.TabIndex = 4;
        this.btnSelectFolder.Text = "Gözat...";
        this.btnSelectFolder.UseVisualStyleBackColor = true;
        this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
        // 
        // txtScanPath
        // 
        this.txtScanPath.Location = new System.Drawing.Point(120, 38);
        this.txtScanPath.Name = "txtScanPath";
        this.txtScanPath.Size = new System.Drawing.Size(720, 27);
        this.txtScanPath.TabIndex = 3;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(15, 41);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(99, 20);
        this.label1.TabIndex = 2;
        this.label1.Text = "Tarama Yolu:";
        // 
        // btnStopScan
        // 
        this.btnStopScan.Enabled = false;
        this.btnStopScan.Location = new System.Drawing.Point(720, 78);
        this.btnStopScan.Name = "btnStopScan";
        this.btnStopScan.Size = new System.Drawing.Size(120, 35);
        this.btnStopScan.TabIndex = 1;
        this.btnStopScan.Text = "Durdur";
        this.btnStopScan.UseVisualStyleBackColor = true;
        this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
        // 
        // btnStartScan
        // 
        this.btnStartScan.Location = new System.Drawing.Point(850, 78);
        this.btnStartScan.Name = "btnStartScan";
        this.btnStartScan.Size = new System.Drawing.Size(120, 35);
        this.btnStartScan.TabIndex = 0;
        this.btnStartScan.Text = "Taramayı Başlat";
        this.btnStartScan.UseVisualStyleBackColor = true;
        this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.lblThreatsFound);
        this.groupBox2.Controls.Add(this.lblProgress);
        this.groupBox2.Controls.Add(this.progressBar);
        this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBox2.Location = new System.Drawing.Point(3, 123);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(986, 100);
        this.groupBox2.TabIndex = 1;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "İlerleme";
        // 
        // lblThreatsFound
        // 
        this.lblThreatsFound.AutoSize = true;
        this.lblThreatsFound.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblThreatsFound.ForeColor = System.Drawing.Color.Red;
        this.lblThreatsFound.Location = new System.Drawing.Point(15, 70);
        this.lblThreatsFound.Name = "lblThreatsFound";
        this.lblThreatsFound.Size = new System.Drawing.Size(134, 20);
        this.lblThreatsFound.TabIndex = 2;
        this.lblThreatsFound.Text = "Tehdit bulundu: 0";
        // 
        // lblProgress
        // 
        this.lblProgress.AutoSize = true;
        this.lblProgress.Location = new System.Drawing.Point(15, 30);
        this.lblProgress.Name = "lblProgress";
        this.lblProgress.Size = new System.Drawing.Size(129, 20);
        this.lblProgress.TabIndex = 1;
        this.lblProgress.Text = "0 / 0 dosya tarandı";
        // 
        // progressBar
        // 
        this.progressBar.Location = new System.Drawing.Point(15, 53);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(955, 10);
        this.progressBar.TabIndex = 0;
        // 
        // groupBox3
        // 
        this.groupBox3.Controls.Add(this.panel1);
        this.groupBox3.Controls.Add(this.dgvThreats);
        this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBox3.Location = new System.Drawing.Point(3, 223);
        this.groupBox3.Name = "groupBox3";
        this.groupBox3.Size = new System.Drawing.Size(986, 341);
        this.groupBox3.TabIndex = 2;
        this.groupBox3.TabStop = false;
        this.groupBox3.Text = "Tespit Edilen Tehditler";
        // 
        // dgvThreats
        // 
        this.dgvThreats.AllowUserToAddRows = false;
        this.dgvThreats.AllowUserToDeleteRows = false;
        this.dgvThreats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvThreats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        this.colFileName,
        this.colPath,
        this.colThreat,
        this.colHash,
        this.colStatus});
        this.dgvThreats.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvThreats.Location = new System.Drawing.Point(3, 23);
        this.dgvThreats.MultiSelect = false;
        this.dgvThreats.Name = "dgvThreats";
        this.dgvThreats.ReadOnly = true;
        this.dgvThreats.RowHeadersWidth = 51;
        this.dgvThreats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvThreats.Size = new System.Drawing.Size(980, 265);
        this.dgvThreats.TabIndex = 0;
        // 
        // colFileName
        // 
        this.colFileName.HeaderText = "Dosya Adı";
        this.colFileName.MinimumWidth = 6;
        this.colFileName.Name = "colFileName";
        this.colFileName.ReadOnly = true;
        this.colFileName.Width = 200;
        // 
        // colPath
        // 
        this.colPath.HeaderText = "Yol";
        this.colPath.MinimumWidth = 6;
        this.colPath.Name = "colPath";
        this.colPath.ReadOnly = true;
        this.colPath.Width = 300;
        // 
        // colThreat
        // 
        this.colThreat.HeaderText = "Tehdit";
        this.colThreat.MinimumWidth = 6;
        this.colThreat.Name = "colThreat";
        this.colThreat.ReadOnly = true;
        this.colThreat.Width = 150;
        // 
        // colHash
        // 
        this.colHash.HeaderText = "MD5 Hash";
        this.colHash.MinimumWidth = 6;
        this.colHash.Name = "colHash";
        this.colHash.ReadOnly = true;
        this.colHash.Width = 200;
        // 
        // colStatus
        // 
        this.colStatus.HeaderText = "Durum";
        this.colStatus.MinimumWidth = 6;
        this.colStatus.Name = "colStatus";
        this.colStatus.ReadOnly = true;
        this.colStatus.Width = 125;
        // 
        // panel1
        // 
        this.panel1.Controls.Add(this.btnDelete);
        this.panel1.Controls.Add(this.btnQuarantine);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panel1.Location = new System.Drawing.Point(3, 288);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(980, 50);
        this.panel1.TabIndex = 1;
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(150, 8);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(130, 35);
        this.btnDelete.TabIndex = 1;
        this.btnDelete.Text = "Sil";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnQuarantine
        // 
        this.btnQuarantine.Location = new System.Drawing.Point(10, 8);
        this.btnQuarantine.Name = "btnQuarantine";
        this.btnQuarantine.Size = new System.Drawing.Size(130, 35);
        this.btnQuarantine.TabIndex = 0;
        this.btnQuarantine.Text = "Karantinaya Al";
        this.btnQuarantine.UseVisualStyleBackColor = true;
        this.btnQuarantine.Click += new System.EventHandler(this.btnQuarantine_Click);
        // 
        // tabQuarantine
        // 
        this.tabQuarantine.Controls.Add(this.dgvQuarantine);
        this.tabQuarantine.Controls.Add(this.panel2);
        this.tabQuarantine.Location = new System.Drawing.Point(4, 29);
        this.tabQuarantine.Name = "tabQuarantine";
        this.tabQuarantine.Padding = new System.Windows.Forms.Padding(3);
        this.tabQuarantine.Size = new System.Drawing.Size(992, 567);
        this.tabQuarantine.TabIndex = 1;
        this.tabQuarantine.Text = "Karantina";
        this.tabQuarantine.UseVisualStyleBackColor = true;
        // 
        // dgvQuarantine
        // 
        this.dgvQuarantine.AllowUserToAddRows = false;
        this.dgvQuarantine.AllowUserToDeleteRows = false;
        this.dgvQuarantine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvQuarantine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        this.colQFileName,
        this.colQThreat,
        this.colQDate,
        this.colQSize});
        this.dgvQuarantine.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvQuarantine.Location = new System.Drawing.Point(3, 3);
        this.dgvQuarantine.MultiSelect = false;
        this.dgvQuarantine.Name = "dgvQuarantine";
        this.dgvQuarantine.ReadOnly = true;
        this.dgvQuarantine.RowHeadersWidth = 51;
        this.dgvQuarantine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvQuarantine.Size = new System.Drawing.Size(986, 511);
        this.dgvQuarantine.TabIndex = 0;
        // 
        // colQFileName
        // 
        this.colQFileName.HeaderText = "Dosya Adı";
        this.colQFileName.MinimumWidth = 6;
        this.colQFileName.Name = "colQFileName";
        this.colQFileName.ReadOnly = true;
        this.colQFileName.Width = 300;
        // 
        // colQThreat
        // 
        this.colQThreat.HeaderText = "Tehdit";
        this.colQThreat.MinimumWidth = 6;
        this.colQThreat.Name = "colQThreat";
        this.colQThreat.ReadOnly = true;
        this.colQThreat.Width = 200;
        // 
        // colQDate
        // 
        this.colQDate.HeaderText = "Karantina Tarihi";
        this.colQDate.MinimumWidth = 6;
        this.colQDate.Name = "colQDate";
        this.colQDate.ReadOnly = true;
        this.colQDate.Width = 200;
        // 
        // colQSize
        // 
        this.colQSize.HeaderText = "Boyut";
        this.colQSize.MinimumWidth = 6;
        this.colQSize.Name = "colQSize";
        this.colQSize.ReadOnly = true;
        this.colQSize.Width = 125;
        // 
        // panel2
        // 
        this.panel2.Controls.Add(this.btnDeleteFromQuarantine);
        this.panel2.Controls.Add(this.btnRestoreFromQuarantine);
        this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panel2.Location = new System.Drawing.Point(3, 514);
        this.panel2.Name = "panel2";
        this.panel2.Size = new System.Drawing.Size(986, 50);
        this.panel2.TabIndex = 1;
        // 
        // btnDeleteFromQuarantine
        // 
        this.btnDeleteFromQuarantine.Location = new System.Drawing.Point(150, 8);
        this.btnDeleteFromQuarantine.Name = "btnDeleteFromQuarantine";
        this.btnDeleteFromQuarantine.Size = new System.Drawing.Size(130, 35);
        this.btnDeleteFromQuarantine.TabIndex = 1;
        this.btnDeleteFromQuarantine.Text = "Kalıcı Sil";
        this.btnDeleteFromQuarantine.UseVisualStyleBackColor = true;
        this.btnDeleteFromQuarantine.Click += new System.EventHandler(this.btnDeleteFromQuarantine_Click);
        // 
        // btnRestoreFromQuarantine
        // 
        this.btnRestoreFromQuarantine.Location = new System.Drawing.Point(10, 8);
        this.btnRestoreFromQuarantine.Name = "btnRestoreFromQuarantine";
        this.btnRestoreFromQuarantine.Size = new System.Drawing.Size(130, 35);
        this.btnRestoreFromQuarantine.TabIndex = 0;
        this.btnRestoreFromQuarantine.Text = "Geri Yükle";
        this.btnRestoreFromQuarantine.UseVisualStyleBackColor = true;
        this.btnRestoreFromQuarantine.Click += new System.EventHandler(this.btnRestoreFromQuarantine_Click);
        // 
        // tabProtection
        // 
        this.tabProtection.Controls.Add(this.groupBox4);
        this.tabProtection.Location = new System.Drawing.Point(4, 29);
        this.tabProtection.Name = "tabProtection";
        this.tabProtection.Size = new System.Drawing.Size(992, 567);
        this.tabProtection.TabIndex = 2;
        this.tabProtection.Text = "Gerçek Zamanlı Koruma";
        this.tabProtection.UseVisualStyleBackColor = true;
        // 
        // groupBox4
        // 
        this.groupBox4.Controls.Add(this.lblRealtimeStatus);
        this.groupBox4.Controls.Add(this.chkRealtimeProtection);
        this.groupBox4.Location = new System.Drawing.Point(15, 15);
        this.groupBox4.Name = "groupBox4";
        this.groupBox4.Size = new System.Drawing.Size(960, 150);
        this.groupBox4.TabIndex = 0;
        this.groupBox4.TabStop = false;
        this.groupBox4.Text = "Gerçek Zamanlı Koruma Ayarları";
        // 
        // lblRealtimeStatus
        // 
        this.lblRealtimeStatus.AutoSize = true;
        this.lblRealtimeStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblRealtimeStatus.ForeColor = System.Drawing.Color.Red;
        this.lblRealtimeStatus.Location = new System.Drawing.Point(20, 90);
        this.lblRealtimeStatus.Name = "lblRealtimeStatus";
        this.lblRealtimeStatus.Size = new System.Drawing.Size(281, 23);
        this.lblRealtimeStatus.TabIndex = 1;
        this.lblRealtimeStatus.Text = "Gerçek zamanlı koruma: KAPALI";
        // 
        // chkRealtimeProtection
        // 
        this.chkRealtimeProtection.AutoSize = true;
        this.chkRealtimeProtection.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.chkRealtimeProtection.Location = new System.Drawing.Point(20, 40);
        this.chkRealtimeProtection.Name = "chkRealtimeProtection";
        this.chkRealtimeProtection.Size = new System.Drawing.Size(287, 27);
        this.chkRealtimeProtection.TabIndex = 0;
        this.chkRealtimeProtection.Text = "Gerçek zamanlı korumayı etkinleştir";
        this.chkRealtimeProtection.UseVisualStyleBackColor = true;
        this.chkRealtimeProtection.CheckedChanged += new System.EventHandler(this.chkRealtimeProtection_CheckedChanged);
        // 
        // statusStrip
        // 
        this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.lblStatus,
        this.toolStripStatusLabel1,
        this.lblDatabaseCount,
        this.toolStripStatusLabel2,
        this.lblQuarantineCount});
        this.statusStrip.Location = new System.Drawing.Point(0, 600);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(1000, 26);
        this.statusStrip.TabIndex = 1;
        this.statusStrip.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(49, 20);
        this.lblStatus.Text = "Hazır";
        // 
        // toolStripStatusLabel1
        // 
        this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 20);
        this.toolStripStatusLabel1.Text = "|";
        // 
        // lblDatabaseCount
        // 
        this.lblDatabaseCount.Name = "lblDatabaseCount";
        this.lblDatabaseCount.Size = new System.Drawing.Size(118, 20);
        this.lblDatabaseCount.Text = "Veritabanı: 0 imza";
        // 
        // toolStripStatusLabel2
        // 
        this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
        this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
        this.toolStripStatusLabel2.Text = "|";
        // 
        // lblQuarantineCount
        // 
        this.lblQuarantineCount.Name = "lblQuarantineCount";
        this.lblQuarantineCount.Size = new System.Drawing.Size(123, 20);
        this.lblQuarantineCount.Text = "Karantina: 0 dosya";
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1000, 626);
        this.Controls.Add(this.tabControl);
        this.Controls.Add(this.statusStrip);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Antivirüs Uygulaması - İmza Tabanlı Tespit";
        this.tabControl.ResumeLayout(false);
        this.tabScan.ResumeLayout(false);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.groupBox2.PerformLayout();
        this.groupBox3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvThreats)).EndInit();
        this.panel1.ResumeLayout(false);
        this.tabQuarantine.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvQuarantine)).EndInit();
        this.panel2.ResumeLayout(false);
        this.tabProtection.ResumeLayout(false);
        this.groupBox4.ResumeLayout(false);
        this.groupBox4.PerformLayout();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabScan;
    private System.Windows.Forms.TabPage tabQuarantine;
    private System.Windows.Forms.TabPage tabProtection;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnStartScan;
    private System.Windows.Forms.Button btnStopScan;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtScanPath;
    private System.Windows.Forms.Button btnSelectFolder;
    private System.Windows.Forms.CheckBox chkRecursive;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label lblProgress;
    private System.Windows.Forms.Label lblThreatsFound;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.DataGridView dgvThreats;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
    private System.Windows.Forms.DataGridViewTextBoxColumn colThreat;
    private System.Windows.Forms.DataGridViewTextBoxColumn colHash;
    private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnQuarantine;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.DataGridView dgvQuarantine;
    private System.Windows.Forms.DataGridViewTextBoxColumn colQFileName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colQThreat;
    private System.Windows.Forms.DataGridViewTextBoxColumn colQDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colQSize;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnRestoreFromQuarantine;
    private System.Windows.Forms.Button btnDeleteFromQuarantine;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.CheckBox chkRealtimeProtection;
    private System.Windows.Forms.Label lblRealtimeStatus;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel lblDatabaseCount;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    private System.Windows.Forms.ToolStripStatusLabel lblQuarantineCount;
}

