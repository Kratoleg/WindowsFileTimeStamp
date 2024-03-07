using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Configuration;


namespace ReklamationBilderUpload
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void quellePfadUpdate_click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            sourceDir.Text = folderBrowserDialog.SelectedPath;
            SaveDirectory( "sourceDir" ,sourceDir.Text);
        }

        private void zielPfadUpdate_click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            destinationDir.Text = folderBrowserDialog.SelectedPath;
            SaveDirectory("destinationDir", destinationDir.Text);
        }

        private void uploadPicture_click(object sender, RoutedEventArgs e)
        {
            PictureMover move = new PictureMover(sourceDir.Text, destinationDir.Text);
            move.MoveEverything();
        }

        private void SaveDirectory(string key, string value)
        { 
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            
        }
    }
}