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
            this.labelScheduledBrightness = new System.Windows.Forms.Label();
            this.trackBarScheduledBrightness = new System.Windows.Forms.TrackBar();
            this.dateTimePickerScheduledEvent = new System.Windows.Forms.DateTimePicker();
            this.labelScheduledBrightnessValue = new System.Windows.Forms.Label();
            this.buttonApplySchedule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScheduledBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // labelScheduledBrightness
            // 
            this.labelScheduledBrightness.AutoSize = true;
            this.labelScheduledBrightness.Location = new System.Drawing.Point(170, 66);
            this.labelScheduledBrightness.Name = "labelScheduledBrightness";
            this.labelScheduledBrightness.Size = new System.Drawing.Size(35, 13);
            this.labelScheduledBrightness.TabIndex = 2;
            this.labelScheduledBrightness.Text = "label1";
            // 
            // trackBarScheduledBrightness
            // 
            this.trackBarScheduledBrightness.Location = new System.Drawing.Point(323, 33);
            this.trackBarScheduledBrightness.Maximum = 100;
            this.trackBarScheduledBrightness.Name = "trackBarScheduledBrightness";
            this.trackBarScheduledBrightness.Size = new System.Drawing.Size(104, 45);
            this.trackBarScheduledBrightness.TabIndex = 3;
            this.trackBarScheduledBrightness.Value = 100;
            // 
            // dateTimePickerScheduledEvent
            // 
            this.dateTimePickerScheduledEvent.Location = new System.Drawing.Point(492, 60);
            this.dateTimePickerScheduledEvent.Name = "dateTimePickerScheduledEvent";
            this.dateTimePickerScheduledEvent.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerScheduledEvent.TabIndex = 4;
            // 
            // labelScheduledBrightnessValue
            // 
            this.labelScheduledBrightnessValue.AutoSize = true;
            this.labelScheduledBrightnessValue.Location = new System.Drawing.Point(323, 85);
            this.labelScheduledBrightnessValue.Name = "labelScheduledBrightnessValue";
            this.labelScheduledBrightnessValue.Size = new System.Drawing.Size(35, 13);
            this.labelScheduledBrightnessValue.TabIndex = 5;
            this.labelScheduledBrightnessValue.Text = "label1";
            // 
            // buttonApplySchedule
            // 
            this.buttonApplySchedule.Location = new System.Drawing.Point(27, 66);
            this.buttonApplySchedule.Name = "buttonApplySchedule";
            this.buttonApplySchedule.Size = new System.Drawing.Size(75, 23);
            this.buttonApplySchedule.TabIndex = 6;
            this.buttonApplySchedule.Text = "button1";
            this.buttonApplySchedule.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonApplySchedule);
            this.Controls.Add(this.labelScheduledBrightnessValue);
            this.Controls.Add(this.dateTimePickerScheduledEvent);
            this.Controls.Add(this.trackBarScheduledBrightness);
            this.Controls.Add(this.labelScheduledBrightness);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScheduledBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelScheduledBrightness;
        private System.Windows.Forms.TrackBar trackBarScheduledBrightness;
        private System.Windows.Forms.DateTimePicker dateTimePickerScheduledEvent;
        private System.Windows.Forms.Label labelScheduledBrightnessValue;
        private System.Windows.Forms.Button buttonApplySchedule;
    }
}