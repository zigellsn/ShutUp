
namespace ShutUpServer
{
    partial class ShutUpServer
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
            this.bShutUp = new System.Windows.Forms.Button();
            this.tUrl = new System.Windows.Forms.TextBox();
            this.bPictureMute = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bShutUp
            // 
            this.bShutUp.Location = new System.Drawing.Point(12, 43);
            this.bShutUp.Name = "bShutUp";
            this.bShutUp.Size = new System.Drawing.Size(173, 23);
            this.bShutUp.TabIndex = 2;
            this.bShutUp.Text = "Shut Up!";
            this.bShutUp.UseVisualStyleBackColor = true;
            this.bShutUp.Click += new System.EventHandler(this.bShutUp_Click);
            // 
            // tUrl
            // 
            this.tUrl.Location = new System.Drawing.Point(12, 12);
            this.tUrl.Name = "tUrl";
            this.tUrl.Size = new System.Drawing.Size(173, 23);
            this.tUrl.TabIndex = 3;
            this.tUrl.Text = "192.168.178.60";
            this.tUrl.TextChanged += new System.EventHandler(this.tUrl_TextChanged);
            // 
            // bPictureMute
            // 
            this.bPictureMute.Location = new System.Drawing.Point(12, 101);
            this.bPictureMute.Name = "bPictureMute";
            this.bPictureMute.Size = new System.Drawing.Size(173, 23);
            this.bPictureMute.TabIndex = 2;
            this.bPictureMute.Text = "Kamera aus!";
            this.bPictureMute.UseVisualStyleBackColor = true;
            this.bPictureMute.Click += new System.EventHandler(this.bShutUp_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Laut!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bShutUp_Click);
            // 
            // ShutUpServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 134);
            this.Controls.Add(this.tUrl);
            this.Controls.Add(this.bPictureMute);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bShutUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShutUpServer";
            this.Text = "ShutUp! Server";
            this.Load += new System.EventHandler(this.ShutUpServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bShutUp;
        private System.Windows.Forms.TextBox tUrl;
        private System.Windows.Forms.Button bPictureMute;
        private System.Windows.Forms.Button button1;
    }
}

