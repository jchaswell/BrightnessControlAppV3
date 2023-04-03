using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightnessControlAppV2.Controllers;
using BrightnessControlAppV2.Helpers;
using BrightnessControlAppV2.Models;
using BrightnessControlAppV2.Views.UserControls;

namespace BrightnessControlAppV2.Views
{
 

    public partial class MainForm : Form
    {
        private ManualBrightnessControl manualBrightnessControl; 
        private List<PInvokeHelper.PHYSICAL_MONITOR> activePhysicalMonitors = new List<PInvokeHelper.PHYSICAL_MONITOR>();
        private int monitorIndex = 0;
        private List<MonitorInfo> monitorInfos = new List<MonitorInfo>();
        private Timer scheduleTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            manualBrightnessControl = new ManualBrightnessControl
            {
                Location = new Point(10, 50), // Adjust the X and Y coordinates as needed
                Size = new Size(300, 50), // Adjust the width and height as needed
                Visible = true
            };
            this.Controls.Add(manualBrightnessControl);

            trackBarAllMonitors.ValueChanged += TrackBarAllMonitors_ValueChanged;
            this.Load += MainForm_Load;
            scheduleTimer.Tick += ScheduleTimer_Tick;
            scheduleTimer.Interval = 1000; // 1 second interval
            scheduleTimer.Start();
            // Initialize UI elements for scheduled brightness
            labelScheduledBrightness.Text = "Scheduled Brightness:";
            dateTimePickerScheduledEvent.Format = DateTimePickerFormat.Time;
            dateTimePickerScheduledEvent.ShowUpDown = true;
            trackBarScheduledBrightness.ValueChanged += TrackBarScheduledBrightness_ValueChanged;
            buttonApplySchedule.Text = "Apply Schedule";
            buttonApplySchedule.Click += ButtonApplySchedule_Click; // Add this line
        }
        private void TrackBarScheduledBrightness_ValueChanged(object sender, EventArgs e)
        {
            //Console.WriteLine($"Scheduled brightness trackbar updated: {trackBarScheduledBrightness.Value}%");
            labelScheduledBrightnessValue.Text = $"Brightness: {trackBarScheduledBrightness.Value}%";
        }
        
        private void ButtonApplySchedule_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Apply Schedule button clicked");
            DateTime scheduledTime = dateTimePickerScheduledEvent.Value;
            int brightnessValue = trackBarScheduledBrightness.Value;

            // Save the scheduled event to MonitorInfo.Schedule
            monitorInfos[0].Schedule.Add(new BrightnessEvent
            {
                Time = scheduledTime,
                Brightness = brightnessValue
            });

            // Save the updated schedule to the file
            ScheduleController.SaveScheduleData(monitorInfos);

            // Show a confirmation message
            MessageBox.Show("Scheduled brightness event added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TrackBarAllMonitors_ValueChanged(object sender, EventArgs e)
        {
            foreach (PInvokeHelper.PHYSICAL_MONITOR monitor in activePhysicalMonitors)
            {
                MonitorController.SetMonitorBrightness(monitor, (uint)trackBarAllMonitors.Value);
            }
            labelAllMonitors.Text = $"Brightness: {trackBarAllMonitors.Value}%";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load schedules from the file
            monitorInfos = ScheduleController.LoadScheduleData(); 
            
            activePhysicalMonitors = MonitorController.EnumerateMonitorsAndFetchBrightness((monitorIndex, currentBrightness, maxBrightness) =>
            {
                if (monitorIndex == 0)
                {
                    trackBarAllMonitors.Minimum = 0;
                    trackBarAllMonitors.Maximum = (int)maxBrightness;
                    trackBarAllMonitors.Value = (int)currentBrightness;
                    labelAllMonitors.Text = $"Brightness: {currentBrightness}%";
                }
            });
            // Initialize monitorInfos with a default MonitorInfo object for each active monitor
            if (monitorInfos.Count <= monitorIndex)
            {
                monitorInfos.Add(new MonitorInfo());
            }

            List<MonitorInfo> loadedMonitorInfos = ScheduleController.LoadScheduleData();

            // Synchronize monitorInfos with the loaded schedules and active monitors
            for (int i = 0; i < monitorInfos.Count; i++)
            {
                if (i < loadedMonitorInfos.Count)
                {
                    monitorInfos[i].Schedule = loadedMonitorInfos[i].Schedule;
                }
            }

        }
        private void ScheduleTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            foreach (MonitorInfo monitorInfo in monitorInfos)
            {
                BrightnessEvent currentEvent = monitorInfo.Schedule
                    .Where(x => x.Time.TimeOfDay <= currentTime)
                    .OrderByDescending(x => x.Time.TimeOfDay)
                    .FirstOrDefault();

                if (currentEvent != null)
                {
                    int monitorIndex = monitorInfos.IndexOf(monitorInfo);
                    PInvokeHelper.PHYSICAL_MONITOR monitor = activePhysicalMonitors[monitorIndex];
                    MonitorController.SetMonitorBrightness(monitor, (uint)currentEvent.Brightness);
                }
            }
        }
    }
}