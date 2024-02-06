
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;

namespace BinaryCodeToImageConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string PathToFile;
        private int Resolution;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void SourceFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if(result.Value == true)
            {
                PathToFile = dialog.FileName;
            }
        }

        private void GenerateFileButton_Click(object sender, RoutedEventArgs e)
        {
            PixelFormat format = PixelFormat.Format32bppRgb;
            if(IsTransparentCheckBox.IsChecked.Value)
            {
                format = PixelFormat.Format32bppArgb;
            }
            Bitmap image = new Bitmap(Resolution, Resolution, format);
            Drawer drawer = new Drawer(image);
            
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "png file |*.png";
            var result = dialog.ShowDialog();
            drawer.DrawToBitmap(PathToFile);
            if(result.Value)
            {
                image.Save(dialog.FileName, ImageFormat.Png);
            }
        }
    

        private void ResolutionTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                Resolution = int.Parse(ResolutionTextBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ow, there is an error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}