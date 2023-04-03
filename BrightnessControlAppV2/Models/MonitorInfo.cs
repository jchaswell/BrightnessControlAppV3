using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightnessControlAppV2.Models
{
    public class MonitorInfo
    {
        public List<BrightnessEvent> Schedule { get; set; } = new List<BrightnessEvent>();
    }
}
