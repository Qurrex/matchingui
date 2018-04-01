using System;
using System.IO;
using System.Windows.Forms;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.LoadApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var localPath = ExecutablePath.Combine("instance.temp");
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(localPath, false);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoadTestForm());
            }
            catch
            {
                MessageBox.Show("Instance is already running or the folder is read-only");
                return;
            }
            finally
            {
                sw?.Close();
            }            
        }
    }
}