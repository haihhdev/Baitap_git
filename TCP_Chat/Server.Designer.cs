namespace MultichatApplication
{
    partial class frmServer
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
            this.txtUserNumber = new System.Windows.Forms.TextBox();
            this.lblUserNumber = new System.Windows.Forms.Label();
            this.btnListen = new System.Windows.Forms.Button();
            this.lstChatBox = new System.Windows.Forms.ListBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserNumber
            // 
            this.txtUserNumber.Location = new System.Drawing.Point(369, 27);
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Size = new System.Drawing.Size(100, 22);
            this.txtUserNumber.TabIndex = 11;
            // 
            // lblUserNumber
            // 
            this.lblUserNumber.AutoSize = true;
            this.lblUserNumber.Location = new System.Drawing.Point(254, 27);
            this.lblUserNumber.Name = "lblUserNumber";
            this.lblUserNumber.Size = new System.Drawing.Size(92, 16);
            this.lblUserNumber.TabIndex = 10;
            this.lblUserNumber.Text = "Số lượng User";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(547, 27);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(89, 29);
            this.btnListen.TabIndex = 9;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // lstChatBox
            // 
            this.lstChatBox.FormattingEnabled = true;
            this.lstChatBox.ItemHeight = 16;
            this.lstChatBox.Location = new System.Drawing.Point(15, 79);
            this.lstChatBox.Name = "lstChatBox";
            this.lstChatBox.Size = new System.Drawing.Size(713, 356);
            this.lstChatBox.TabIndex = 8;
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(115, 27);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 22);
            this.txtServerPort.TabIndex = 7;
            this.txtServerPort.TextChanged += new System.EventHandler(this.txtServerPort_TextChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 30);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(97, 16);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port của server";
            this.lblPort.Click += new System.EventHandler(this.lblPort_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 440);
            this.Controls.Add(this.txtUserNumber);
            this.Controls.Add(this.lblUserNumber);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.lstChatBox);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.lblPort);
            this.Name = "frmServer";
            this.Text = "TCP Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Label lblUserNumber;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListBox lstChatBox;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label lblPort;
    }
}