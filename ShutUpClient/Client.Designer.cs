
namespace ShutUpClient
{
    partial class Client
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
            this.bConnect = new System.Windows.Forms.Button();
            this.bACK = new System.Windows.Forms.Button();
            this.lShutUp = new System.Windows.Forms.Label();
            this.lbAllIPs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(12, 100);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(173, 25);
            this.bConnect.TabIndex = 3;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bACK
            // 
            this.bACK.Location = new System.Drawing.Point(191, 102);
            this.bACK.Name = "bACK";
            this.bACK.Size = new System.Drawing.Size(574, 23);
            this.bACK.TabIndex = 4;
            this.bACK.Text = "Bestätigen";
            this.bACK.UseVisualStyleBackColor = true;
            this.bACK.Visible = false;
            this.bACK.Click += new System.EventHandler(this.bACK_Click);
            // 
            // lShutUp
            // 
            this.lShutUp.AutoSize = true;
            this.lShutUp.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lShutUp.ForeColor = System.Drawing.Color.Red;
            this.lShutUp.Location = new System.Drawing.Point(191, 12);
            this.lShutUp.Name = "lShutUp";
            this.lShutUp.Size = new System.Drawing.Size(378, 65);
            this.lShutUp.TabIndex = 5;
            this.lShutUp.Text = "Stummschalten!";
            this.lShutUp.Visible = false;
            // 
            // lbAllIPs
            // 
            this.lbAllIPs.FormattingEnabled = true;
            this.lbAllIPs.ItemHeight = 15;
            this.lbAllIPs.Location = new System.Drawing.Point(13, 12);
            this.lbAllIPs.Name = "lbAllIPs";
            this.lbAllIPs.Size = new System.Drawing.Size(172, 79);
            this.lbAllIPs.TabIndex = 6;
            this.lbAllIPs.SelectedIndexChanged += new System.EventHandler(this.lbAllIPs_SelectedIndexChanged);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 136);
            this.Controls.Add(this.lbAllIPs);
            this.Controls.Add(this.lShutUp);
            this.Controls.Add(this.bACK);
            this.Controls.Add(this.bConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Client";
            this.Text = "ShutUp! Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button bACK;
        private System.Windows.Forms.Label lShutUp;
        private System.Windows.Forms.ListBox lbAllIPs;
    }
}

