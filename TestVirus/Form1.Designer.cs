namespace TestVirus;

partial class VirusGeneratorForm
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
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.btnClearResult = new System.Windows.Forms.Button();
        this.btnAddToDatabase = new System.Windows.Forms.Button();
        this.btnGenerateVirus = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.txtResult = new System.Windows.Forms.TextBox();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.SuspendLayout();
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.btnClearResult);
        this.groupBox1.Controls.Add(this.btnAddToDatabase);
        this.groupBox1.Controls.Add(this.btnGenerateVirus);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBox1.Location = new System.Drawing.Point(0, 0);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(700, 180);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Test Virüsü Oluşturucu";
        // 
        // btnClearResult
        // 
        this.btnClearResult.Location = new System.Drawing.Point(540, 130);
        this.btnClearResult.Name = "btnClearResult";
        this.btnClearResult.Size = new System.Drawing.Size(140, 35);
        this.btnClearResult.TabIndex = 3;
        this.btnClearResult.Text = "Sonuçları Temizle";
        this.btnClearResult.UseVisualStyleBackColor = true;
        this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
        // 
        // btnAddToDatabase
        // 
        this.btnAddToDatabase.Location = new System.Drawing.Point(280, 130);
        this.btnAddToDatabase.Name = "btnAddToDatabase";
        this.btnAddToDatabase.Size = new System.Drawing.Size(240, 35);
        this.btnAddToDatabase.TabIndex = 2;
        this.btnAddToDatabase.Text = "Veritabanına Nasıl Eklenir?";
        this.btnAddToDatabase.UseVisualStyleBackColor = true;
        this.btnAddToDatabase.Click += new System.EventHandler(this.btnAddToDatabase_Click);
        // 
        // btnGenerateVirus
        // 
        this.btnGenerateVirus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnGenerateVirus.Location = new System.Drawing.Point(20, 130);
        this.btnGenerateVirus.Name = "btnGenerateVirus";
        this.btnGenerateVirus.Size = new System.Drawing.Size(240, 35);
        this.btnGenerateVirus.TabIndex = 1;
        this.btnGenerateVirus.Text = "Test Virüsü Oluştur";
        this.btnGenerateVirus.UseVisualStyleBackColor = true;
        this.btnGenerateVirus.Click += new System.EventHandler(this.btnGenerateVirus_Click);
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(20, 30);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(660, 90);
        this.label1.TabIndex = 0;
        this.label1.Text = @"Bu uygulama, antivirüs yazılımınızı test etmek için ZARARSIZ test dosyaları oluşturur.

Oluşturulan dosyalar gerçek virüs değildir ve sisteminize zarar vermez.
Hash değerleri otomatik olarak hesaplanır ve panoya kopyalanır.

Test virüsünü oluşturduktan sonra, hash değerini antivirüs veritabanına ekleyerek
tespit edilip edilmediğini kontrol edebilirsiniz.";
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.txtResult);
        this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBox2.Location = new System.Drawing.Point(0, 180);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(700, 320);
        this.groupBox2.TabIndex = 1;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Sonuçlar";
        // 
        // txtResult
        // 
        this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
        this.txtResult.Font = new System.Drawing.Font("Consolas", 9F);
        this.txtResult.Location = new System.Drawing.Point(3, 23);
        this.txtResult.Multiline = true;
        this.txtResult.Name = "txtResult";
        this.txtResult.ReadOnly = true;
        this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtResult.Size = new System.Drawing.Size(694, 294);
        this.txtResult.TabIndex = 0;
        // 
        // VirusGeneratorForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(700, 500);
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.groupBox1);
        this.Name = "VirusGeneratorForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Test Virüsü Oluşturucu";
        this.groupBox1.ResumeLayout(false);
        this.groupBox2.ResumeLayout(false);
        this.groupBox2.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnGenerateVirus;
    private System.Windows.Forms.Button btnAddToDatabase;
    private System.Windows.Forms.Button btnClearResult;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox txtResult;
}

