using Microsoft.Win32;
using System;
using System.IO;
using System.IO.Compression;
using System.Windows;

namespace ThirdTask
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

        private void Unzip_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archive files (*.gz*)|*.gz*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    filePath = openFileDialog.FileName;
                    FileInfo fileToDecompress = new FileInfo(filePath);
                    Decompress(fileToDecompress);
                    MessageBox.Show(Properties.Resources.SuccessText, Properties.Resources.SuccessTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show(Properties.Resources.WarningText, Properties.Resources.WarningTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string userName = Environment.UserName;
                string newFileName = "C:\\Users\\" + userName + "\\Desktop\\" + fileToDecompress.Name.Remove(fileToDecompress.Name.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }
    }
}
