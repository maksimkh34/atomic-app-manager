using Microsoft.Win32;
using System.IO;
using System.Net;

namespace atomic_app_manager
{
    internal class AAM
    {
        public static void EmptyDir(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static void InitRelease()
        {
            var Window = new CreateHomeDirStartup();
            Window.ShowDialog();
        }

        public static void InstallToDir(string dir)
        {
            EmptyDir(dir);
            // D:\Work\Testing
            dir += '\\';
            string AppUrl = "https://github.com/maksimkh34/aam-repo/raw/main/app.exe";

            WebClient webClient = new();
            webClient.DownloadFile(AppUrl, dir + "App.exe");

            File.Create(dir + "init").Close();
            using StreamWriter outputFile = new StreamWriter(dir + "init");
            outputFile.WriteLine(AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName + ".exe");

            Directory.CreateDirectory(dir + "Downloads");
            Directory.CreateDirectory(dir + "conf");

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Atomic");
            key = key.OpenSubKey("Atomic", true);

            key.CreateSubKey("AAM");
            key = key.OpenSubKey("AAM", true);

            key.SetValue("HomeDir", dir);
        }
    }
}
