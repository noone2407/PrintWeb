namespace PrintWeb
{
    partial class Form2
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
            this.buttonPrintFile = new System.Windows.Forms.Button();
            this.buttonPrintWeb = new System.Windows.Forms.Button();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonPrintFile
            // 
            this.buttonPrintFile.Location = new System.Drawing.Point(257, 100);
            this.buttonPrintFile.Name = "buttonPrintFile";
            this.buttonPrintFile.Size = new System.Drawing.Size(140, 23);
            this.buttonPrintFile.TabIndex = 41;
            this.buttonPrintFile.Text = "Print File";
            this.buttonPrintFile.UseVisualStyleBackColor = true;
            this.buttonPrintFile.Click += new System.EventHandler(this.buttonPrintFile_Click);
            // 
            // buttonPrintWeb
            // 
            this.buttonPrintWeb.Location = new System.Drawing.Point(103, 100);
            this.buttonPrintWeb.Name = "buttonPrintWeb";
            this.buttonPrintWeb.Size = new System.Drawing.Size(140, 23);
            this.buttonPrintWeb.TabIndex = 40;
            this.buttonPrintWeb.Text = "Print Web";
            this.buttonPrintWeb.UseVisualStyleBackColor = true;
            this.buttonPrintWeb.Click += new System.EventHandler(this.buttonPrintWeb_Click);
            // 
            // TxtUrl
            // 
            this.TxtUrl.Location = new System.Drawing.Point(79, 60);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(386, 20);
            this.TxtUrl.TabIndex = 39;
            this.TxtUrl.Text = "https://www.google.com";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 320);
            this.Controls.Add(this.buttonPrintFile);
            this.Controls.Add(this.buttonPrintWeb);
            this.Controls.Add(this.TxtUrl);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrintFile;
        private System.Windows.Forms.Button buttonPrintWeb;
        private System.Windows.Forms.TextBox TxtUrl;
    }
}