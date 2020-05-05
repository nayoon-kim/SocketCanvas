namespace WindowsFormsApp2
{
    partial class Modal_Server
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
            this.server_ip = new System.Windows.Forms.TextBox();
            this.server_port = new System.Windows.Forms.TextBox();
            this.btn_server = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // server_ip
            // 
            this.server_ip.Location = new System.Drawing.Point(12, 12);
            this.server_ip.Name = "server_ip";
            this.server_ip.Size = new System.Drawing.Size(203, 25);
            this.server_ip.TabIndex = 0;
            // 
            // server_port
            // 
            this.server_port.Location = new System.Drawing.Point(233, 12);
            this.server_port.Name = "server_port";
            this.server_port.Size = new System.Drawing.Size(100, 25);
            this.server_port.TabIndex = 1;
            // 
            // btn_server
            // 
            this.btn_server.Location = new System.Drawing.Point(12, 56);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(321, 35);
            this.btn_server.TabIndex = 2;
            this.btn_server.Text = "서버열기";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.Btn_server_Click);
            // 
            // Modal_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 103);
            this.Controls.Add(this.btn_server);
            this.Controls.Add(this.server_port);
            this.Controls.Add(this.server_ip);
            this.Name = "Modal_Server";
            this.Text = "세계그림판서버";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox server_ip;
        private System.Windows.Forms.TextBox server_port;
        private System.Windows.Forms.Button btn_server;
    }
}