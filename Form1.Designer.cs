namespace WindowsFormsApp1
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
            this.btnback = new System.Windows.Forms.Button();
            this.btnforward = new System.Windows.Forms.Button();
            this.btnopen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(0, 12);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(37, 23);
            this.btnback.TabIndex = 0;
            this.btnback.Text = "<<<";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnforward
            // 
            this.btnforward.Location = new System.Drawing.Point(43, 12);
            this.btnforward.Name = "btnforward";
            this.btnforward.Size = new System.Drawing.Size(37, 23);
            this.btnforward.TabIndex = 0;
            this.btnforward.Text = ">>>";
            this.btnforward.UseVisualStyleBackColor = true;
            this.btnforward.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnopen
            // 
            this.btnopen.Location = new System.Drawing.Point(1033, 12);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(87, 23);
            this.btnopen.TabIndex = 0;
            this.btnopen.Text = "Mở";
            this.btnopen.UseVisualStyleBackColor = true;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đường dẫn:";
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(185, 14);
            this.txtpath.Name = "txtpath";
            this.txtpath.ReadOnly = true;
            this.txtpath.Size = new System.Drawing.Size(842, 20);
            this.txtpath.TabIndex = 2;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(184, 40);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(842, 512);
            this.webBrowser1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 629);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnopen);
            this.Controls.Add(this.btnforward);
            this.Controls.Add(this.btnback);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnforward;
        private System.Windows.Forms.Button btnopen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}