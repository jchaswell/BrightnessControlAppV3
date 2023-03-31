namespace BrightnessControlAppV2.Views
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
            this.labelMon1 = new System.Windows.Forms.Label();
            this.labelMon2 = new System.Windows.Forms.Label();
            this.trackBarMon2 = new System.Windows.Forms.TrackBar();
            this.trackBarMon1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMon1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMon1
            // 
            this.labelMon1.AutoSize = true;
            this.labelMon1.Location = new System.Drawing.Point(276, 126);
            this.labelMon1.Name = "labelMon1";
            this.labelMon1.Size = new System.Drawing.Size(35, 13);
            this.labelMon1.TabIndex = 2;
            this.labelMon1.Text = "label1";
            // 
            // labelMon2
            // 
            this.labelMon2.AutoSize = true;
            this.labelMon2.Location = new System.Drawing.Point(279, 218);
            this.labelMon2.Name = "labelMon2";
            this.labelMon2.Size = new System.Drawing.Size(35, 13);
            this.labelMon2.TabIndex = 3;
            this.labelMon2.Text = "label2";
            // 
            // trackBarMon2
            // 
            this.trackBarMon2.Location = new System.Drawing.Point(410, 218);
            this.trackBarMon2.Maximum = 100;
            this.trackBarMon2.Name = "trackBarMon2";
            this.trackBarMon2.Size = new System.Drawing.Size(104, 45);
            this.trackBarMon2.TabIndex = 1;
            // 
            // trackBarMon1
            // 
            this.trackBarMon1.Location = new System.Drawing.Point(410, 126);
            this.trackBarMon1.Maximum = 100;
            this.trackBarMon1.Name = "trackBarMon1";
            this.trackBarMon1.Size = new System.Drawing.Size(104, 45);
            this.trackBarMon1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelMon2);
            this.Controls.Add(this.labelMon1);
            this.Controls.Add(this.trackBarMon2);
            this.Controls.Add(this.trackBarMon1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMon1;
        private System.Windows.Forms.Label labelMon2;
        private System.Windows.Forms.TrackBar trackBarMon2;
        private System.Windows.Forms.TrackBar trackBarMon1;
    }
}