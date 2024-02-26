using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace atomic_app_manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
         {
            if(!File.Exists("init"))
            {
                AAM.InitRelease();
                Environment.Exit(0);
            }

            if (File.ReadLines("init").Any())
            {
                try
                {
                    File.Delete(File.ReadLines("init").ElementAt(0));
                    File.Delete("init");
                    File.Create("init").Close();
                }
                catch (FileNotFoundException) { }
            }
        }
    }

}
