using System.IO;
using System.Text;
using Newtonsoft.Json;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model
{
    /// <summary>
    /// demo application's settings, stored in settings.txt
    /// </summary>
    public class AppSets
    {
        public string uri { get; set; }

        public static AppSets ReadSettingsFromFile()
        {
            var path = ExecutablePath.Combine("settings.txt");
            if (!File.Exists(path)) return null;

            string json;
            using (var sr = new StreamReader(ExecutablePath.Combine("settings.txt"), Encoding.UTF8))
                json = sr.ReadToEnd();
            return JsonConvert.DeserializeObject<AppSets>(json);
        }
    }
}
