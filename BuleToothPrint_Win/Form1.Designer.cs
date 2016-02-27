namespace BuleToothPrint_Win
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQueryBluetooth = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintTestPage = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOneDimensionalCode = new System.Windows.Forms.Button();
            this.btnPrintQRCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQueryBluetooth
            // 
            this.btnQueryBluetooth.Location = new System.Drawing.Point(12, 12);
            this.btnQueryBluetooth.Name = "btnQueryBluetooth";
            this.btnQueryBluetooth.Size = new System.Drawing.Size(285, 23);
            this.btnQueryBluetooth.TabIndex = 0;
            this.btnQueryBluetooth.Text = "Search for Bluetooth devices";
            this.btnQueryBluetooth.UseVisualStyleBackColor = true;
            this.btnQueryBluetooth.Click += new System.EventHandler(this.btnQueryBluetooth_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.AcceptsReturn = true;
            this.txtMsg.Location = new System.Drawing.Point(12, 41);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(285, 71);
            this.txtMsg.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(12, 118);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(285, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintTestPage
            // 
            this.btnPrintTestPage.Enabled = false;
            this.btnPrintTestPage.Location = new System.Drawing.Point(12, 141);
            this.btnPrintTestPage.Name = "btnPrintTestPage";
            this.btnPrintTestPage.Size = new System.Drawing.Size(285, 23);
            this.btnPrintTestPage.TabIndex = 3;
            this.btnPrintTestPage.Text = "Print the test Page";
            this.btnPrintTestPage.UseVisualStyleBackColor = true;
            this.btnPrintTestPage.Click += new System.EventHandler(this.btnPrintTestPage_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(12, 270);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(285, 23);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Exit";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnOneDimensionalCode
            // 
            this.btnOneDimensionalCode.Enabled = false;
            this.btnOneDimensionalCode.Location = new System.Drawing.Point(12, 170);
            this.btnOneDimensionalCode.Name = "btnOneDimensionalCode";
            this.btnOneDimensionalCode.Size = new System.Drawing.Size(285, 23);
            this.btnOneDimensionalCode.TabIndex = 5;
            this.btnOneDimensionalCode.Text = "Print";
            this.btnOneDimensionalCode.UseVisualStyleBackColor = true;
            this.btnOneDimensionalCode.Click += new System.EventHandler(this.btnOneDimensionalCode_Click);
            // 
            // btnPrintQRCode
            // 
            this.btnPrintQRCode.Enabled = false;
            this.btnPrintQRCode.Location = new System.Drawing.Point(12, 199);
            this.btnPrintQRCode.Name = "btnPrintQRCode";
            this.btnPrintQRCode.Size = new System.Drawing.Size(285, 23);
            this.btnPrintQRCode.TabIndex = 6;
            this.btnPrintQRCode.Text = "Print QRCode";
            this.btnPrintQRCode.UseVisualStyleBackColor = true;
            this.btnPrintQRCode.Click += new System.EventHandler(this.btnPrintQRCode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 305);
            this.Controls.Add(this.btnPrintQRCode);
            this.Controls.Add(this.btnOneDimensionalCode);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnPrintTestPage);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnQueryBluetooth);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQueryBluetooth;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintTestPage;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOneDimensionalCode;
        private System.Windows.Forms.Button btnPrintQRCode;
    }
}

