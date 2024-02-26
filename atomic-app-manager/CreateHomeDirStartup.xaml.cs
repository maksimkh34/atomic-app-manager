using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace atomic_app_manager
{
    /// <summary>
    /// Логика взаимодействия для CreateHomeDirStartup.xaml
    /// </summary>
    public partial class CreateHomeDirStartup : Window
    {
        public CreateHomeDirStartup()
        {
            InitializeComponent();
        }

        private void SelectPath_b(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog dlg = new()
            {
                Description = "Выберите каталог установки программы",
                Multiselect = false,
                UseDescriptionForTitle = true
        };
            
            if (dlg.ShowDialog() == true)
            {
                HomeDir_tb.Text = dlg.SelectedPath;
            }
        }

        private void Accept_b(object sender, RoutedEventArgs e)
        {
            if(System.IO.Directory.Exists(HomeDir_tb.Text))
            {
                if(MessageBox.Show("Все данные в директории будут удалены! Продолжить?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) { 
                    AAM.InstallToDir(HomeDir_tb.Text);
                    Close();
                }
            } else
            {
                MessageBox.Show("Указана неверная директория для установки! ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
