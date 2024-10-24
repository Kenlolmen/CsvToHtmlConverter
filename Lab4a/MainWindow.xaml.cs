using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace Lab4a
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileContentCsv = "";
        private string fileContentHtml = "";

        private string filePathCsv = "";
        private string filePathHtml = "";
        
        

        public MainWindow()
        {
            InitializeComponent();

            string gifPath = "C:\\Users\\Lenovo\\source\\repos\\Lab4a\\Lab4a\\gif\\NWSJ.gif";
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(gifPath);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(GifImage, image);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Convert conv = new Convert();
 //           obsluga.Konwert(filePathCsv, filePathHtml);

            bool isDone = conv.convert(filePathCsv,filePathHtml);
            if (isDone)
            {
                MessageBox.Show("Plik został pomyślnie skonwertowany");
            }
            else
            {
                MessageBox.Show("Konwersja nie powiodła się.");
            }

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e) { }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e) // okno wejsciowe plik csv
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                filePathCsv = openFileDialog.FileName;

                try
                {
                    fileContentHtml = File.ReadAllText(filePathCsv);
                    textBoxCSV.Text = filePathCsv;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("blad" + ex.Message);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // okno wejsciowe plik html
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                filePathHtml = saveFileDialog.FileName;

                try
                {
                    fileContentHtml = File.ReadAllText(filePathHtml);
                    textBoxHTML.Text = filePathHtml;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("blad" + ex.Message);
                }
            }
        }

    }
}
