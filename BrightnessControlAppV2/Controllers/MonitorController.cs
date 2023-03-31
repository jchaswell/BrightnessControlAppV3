using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BrightnessControlAppV2.Helpers;

namespace BrightnessControlAppV2.Controllers
{
    public class MonitorController
    {
        public static void SetMonitorBrightness(PInvokeHelper.PHYSICAL_MONITOR physicalMonitor, uint newValue)
        {
            if (!PInvokeHelper.SetVCPFeature(physicalMonitor.hPhysicalMonitor, PInvokeHelper.VCP_CODE_BRIGHTNESS, newValue))
            {
                int errorCode = Marshal.GetLastWin32Error();
                MessageBox.Show($"Failed to set brightness. Error code: {errorCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<PInvokeHelper.PHYSICAL_MONITOR> EnumerateMonitorsAndFetchBrightness(Action<int, uint, uint> onMonitorBrightnessFetched)
        {
            List<PInvokeHelper.PHYSICAL_MONITOR> activePhysicalMonitors = new List<PInvokeHelper.PHYSICAL_MONITOR>();
            int monitorIndex = 0;

            PInvokeHelper.MonitorEnumDelegate monitorEnumProc = (IntPtr hMonitor, IntPtr hdcMonitor, ref PInvokeHelper.RECT lprcMonitor, IntPtr dwData) =>
            {
                if (!PInvokeHelper.GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, out uint monitorCount))
                {
                    return true;
                }

                PInvokeHelper.PHYSICAL_MONITOR[] physicalMonitors = new PInvokeHelper.PHYSICAL_MONITOR[monitorCount];
                if (!PInvokeHelper.GetPhysicalMonitorsFromHMONITOR(hMonitor, monitorCount, physicalMonitors))
                {
                    return true;
                }

                foreach (PInvokeHelper.PHYSICAL_MONITOR physicalMonitor in physicalMonitors)
                {
                    IntPtr currentValue = Marshal.AllocCoTaskMem(sizeof(uint));
                    IntPtr maxValue = Marshal.AllocCoTaskMem(sizeof(uint));

                    if (!PInvokeHelper.GetVCPFeatureAndVCPFeatureReply(physicalMonitor.hPhysicalMonitor, PInvokeHelper.VCP_CODE_BRIGHTNESS, IntPtr.Zero, currentValue, maxValue))
                    {
                        Marshal.FreeCoTaskMem(currentValue);
                        Marshal.FreeCoTaskMem(maxValue);
                        continue;
                    }

                    uint currentBrightness = (uint)Marshal.ReadInt32(currentValue);
                    uint maxBrightness = (uint)Marshal.ReadInt32(maxValue);

                    onMonitorBrightnessFetched(monitorIndex, currentBrightness, maxBrightness);

                    monitorIndex++;
                    activePhysicalMonitors.Add(physicalMonitor);

                    Marshal.FreeCoTaskMem(currentValue);
                    Marshal.FreeCoTaskMem(maxValue);
                }

                return true;
            };

            PInvokeHelper.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, monitorEnumProc, IntPtr.Zero);

            return activePhysicalMonitors;
        }
    }
}