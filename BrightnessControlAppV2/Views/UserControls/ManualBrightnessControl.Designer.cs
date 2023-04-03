namespace BrightnessControlAppV2.Views.UserControls
{
    partial class ManualBrightnessControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelAllMonitors = new System.Windows.Forms.Label();
            this.trackBarAllMonitors = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAllMonitors)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAllMonitors
            // 
            this.labelAllMonitors.AutoSize = true;
            this.labelAllMonitors.Location = new System.Drawing.Point(24, 19);
            this.labelAllMonitors.Name = "labelAllMonitors";
            this.labelAllMonitors.Size = new System.Drawing.Size(78, 13);
            this.labelAllMonitors.TabIndex = 3;
            this.labelAllMonitors.Text = "Manual Control";
            // 
            // trackBarAllMonitors
            // 
            this.trackBarAllMonitors.Location = new System.Drawing.Point(121, 10);
            this.trackBarAllMonitors.Name = "trackBarAllMonitors";
            this.trackBarAllMonitors.Size = new System.Drawing.Size(104, 45);
            this.trackBarAllMonitors.TabIndex = 2;
            // 
            // ManualBrightnessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelAllMonitors);
            this.Controls.Add(this.trackBarAllMonitors);
            this.Name = "ManualBrightnessControl";
            this.Size = new System.Drawing.Size(244, 54);
            this.Load += new System.EventHandler(this.ManualBrightnessControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAllMonitors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAllMonitors;
        private System.Windows.Forms.TrackBar trackBarAllMonitors;
    }
}
