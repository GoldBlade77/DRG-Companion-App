using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerInteractivity.Settings
{
    public class AppUserSettings
    {
        public string AuthToken { get; set; } = "";
        public string ModsDirectory { get; set; } = @"C:\Program Files(x86)\Steam\steamapps\common\Deep Rock Galactic\FSD\Mods\";
    }
}