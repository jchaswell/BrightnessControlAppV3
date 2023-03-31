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

namespace BrightnessControlAppV2.Views
{
    public partial class MainForm : Form
    {
        private List<PInvokeHelper.PHYSICAL_MONITOR> activePhysicalMonitors = new List<PInvokeHelper.PHYSICAL_MONITOR>();
        private int monitorIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            trackBarMon1.ValueChanged += TrackBarMon1_ValueChanged;
            trackBarMon2.ValueChanged += TrackBarMon2_ValueChanged;
            this.Load += MainForm_Load;
        }

        private void TrackBarMon1_ValueChanged(object sender, EventArgs e)
        {
            if (activePhysicalMonitors.Count >= 1)
            {
                MonitorController.SetMonitorBrightness(activePhysicalMonitors[0], (uint)trackBarMon1.Value);
                labelMon1.Text = $"Monitor 1: {trackBarMon1.Value}";
            }
        }

        private void TrackBarMon2_ValueChanged(object sender, EventArgs e)
        {
            if (activePhysicalMonitors.Count >= 2)
            {
                MonitorController.SetMonitorBrightness(activePhysicalMonitors[1], (uint)trackBarMon2.Value);
                labelMon2.Text = $"Monitor 2: {trackBarMon2.Value}";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            activePhysicalMonitors = MonitorController.EnumerateMonitorsAndFetchBrightness((monitorIndex, currentBrightness, maxBrightness) =>
            {
                if (monitorIndex == 0)
                {
                    trackBarMon1.Minimum = 0;
                    trackBarMon1.Maximum = (int)maxBrightness;
                    trackBarMon1.Value = (int)currentBrightness;
                    labelMon1.Text = $"Monitor 1: {currentBrightness}";
                }
                else if (monitorIndex == 1)
                {
                    trackBarMon2.Minimum = 0;
                    trackBarMon2.Maximum = (int)maxBrightness;
                    trackBarMon2.Value = (int)currentBrightness;
                    labelMon2.Text = $"Monitor 2: {currentBrightness}";
                }
            });
        }
    }
}