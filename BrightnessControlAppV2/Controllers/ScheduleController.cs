using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using BrightnessControlAppV2.Models;

namespace BrightnessControlAppV2.Controllers
{
    public class ScheduleController
    {
        private static string scheduleFilePath = "scheduleData.json";

        public static void SaveScheduleData(List<MonitorInfo> monitorInfos)
        {
            string jsonData = JsonConvert.SerializeObject(monitorInfos);
            File.WriteAllText(scheduleFilePath, jsonData);
        }

        public static List<MonitorInfo> LoadScheduleData()
        {
            if (File.Exists(scheduleFilePath))
            {
                string jsonData = File.ReadAllText(scheduleFilePath);
                return JsonConvert.DeserializeObject<List<MonitorInfo>>(jsonData);
            }

            return new List<MonitorInfo>();
        }
    }
    public partial class ScheduleForm : Form
    {
        // Placeholder for schedule editing UI
    }
}


