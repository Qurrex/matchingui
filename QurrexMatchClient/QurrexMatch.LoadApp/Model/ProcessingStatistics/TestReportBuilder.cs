using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// class is used in GUI code to store the statistics 
    /// gathered within the dest
    /// </summary>
    public static class TestReportBuilder
    {
        /// <summary>
        /// relative statistics folder path
        /// </summary>
        public const string RootFolder = "reports";

        /// <summary>
        /// ensure the target folder and save the report's time
        /// </summary>
        public static void BuildReport(TraderPool pool)
        {
            var folder = $"{DateTime.Now:yyyy-MM-dd HHmmss}";
            EnsureFolder(folder);
            folder = ExecutablePath.Combine(RootFolder, folder);

            SaveStatisticsReport(pool, folder);
            SaveServerReport(pool, folder);
        }
        
        /// <summary>
        /// open the report pointed by its time in a browser
        /// </summary>
        public static void OpenReport(DateTime reportTime)
        {
            var path = ExecutablePath.Combine(RootFolder, $"{reportTime:yyyy-MM-dd HHmmss}", "report.html");
            System.Diagnostics.Process.Start(path);
        }

        /// <summary>
        /// get the reports' times from the "reports" folder
        /// report's time is a part of its filename
        /// </summary>
        public static List<DateTime> ReadReportsTimes()
        {
            var dates = new List<DateTime>();
            var root = ExecutablePath.Combine(RootFolder);
            if (!Directory.Exists(root)) return dates;

            foreach (var dir in Directory.GetDirectories(root))
            {
                var name = Path.GetFileName(dir);
                if (DateTime.TryParseExact(name, "yyyy-MM-dd HHmmss", CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out var date))
                    dates.Add(date);
            }

            return dates.OrderByDescending(d => d).ToList();
        }

        /// <summary>
        /// save the report (included in the pool parameter) in a file
        /// </summary>
        private static void SaveStatisticsReport(TraderPool pool, string folder)
        {
            var stat = pool.statistics;
            var jsonPath = Path.Combine(folder, "rawdata.js");
            var json = stat.Stringify(false);
            using (var sw = new StreamWriter(jsonPath, false, Encoding.UTF8))
                sw.Write("window.rawdata = " + json);

            // copy report file
            var newPath = ExecutablePath.Combine(folder, "report.html");
            var srcPath = ExecutablePath.Combine("report.html");
            if (File.Exists(newPath))
                File.Delete(newPath);
            File.Copy(srcPath, newPath);
        }

        /// <summary>
        /// move the report file from the tempory path to the destination path ("report" folder)
        /// </summary>
        private static void SaveServerReport(TraderPool pool, string folder)
        {
            pool.serverStatPicker.CopyReportToTargetDir(folder);
        }

        /// <summary>
        /// create the folder passed if it not exists
        /// </summary>
        private static void EnsureFolder(string subFolder)
        {
            var folder = ExecutablePath.Combine(RootFolder);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            folder = ExecutablePath.Combine(RootFolder, subFolder);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
        }
    }
}
