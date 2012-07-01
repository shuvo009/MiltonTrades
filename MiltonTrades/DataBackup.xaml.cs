using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace MiltonTrades
{
    /// <summary>
    /// Interaction logic for DataBackup.xaml
    /// </summary>
    public partial class DataBackup : Window
    {
        public DataBackup()
        {
            InitializeComponent();
        }
        private string filePath = string.Empty;
        private string selectedDatabase = string.Empty;

        public ICommand FolderBrowseDBCommand
        {
            get { return new ReplayCommand(new Action<object>(this.folderBrowseDBClick)); }
        }

        public ICommand DatabseBackupCommand
        {
            get { return new ReplayCommand(new Action<object>(this.databseBackupClick)); }
        }

        private void folderBrowseDBClick(object obj)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog folderBrowse = new System.Windows.Forms.FolderBrowserDialog();
                if (folderBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = folderBrowse.SelectedPath;
                }
            }
            catch (Exception errorException)
            {
                MessageBox.Show(errorException.Message, MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void databseBackupClick(object obj)
        {
            try
            {
                if (!String.IsNullOrEmpty(filePath))
                {
                    string fromDBName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),  MainWindow.SOFTWARENAME, "DueManagementSystemDatabase.s3db");
                    File.Copy(fromDBName, System.IO.Path.Combine(filePath, DateTime.Now.ToString("ddMMyyyyHHmmssfftt") + ".s3db"));
                    MessageBox.Show("Database Backup Complete.", MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please Select a folder.", MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            catch (Exception errorException)
            {
                MessageBox.Show(errorException.Message, MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public ICommand FileBrowseDRCommand
        {
            get { return new ReplayCommand(new Action<object>(this.fileBrowseDRClick)); }
        }

        public ICommand DatabseRestoreCommand
        {
            get { return new ReplayCommand(new Action<object>(this.databaseRestoreClick)); }
        }

        private void fileBrowseDRClick(object obj)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog openDatabseFile = new System.Windows.Forms.OpenFileDialog();
                openDatabseFile.Filter = "Database (*.s3db)|*.s3db";
                openDatabseFile.FilterIndex = 2;
                openDatabseFile.RestoreDirectory = true;
                if (openDatabseFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectedDatabase = openDatabseFile.FileName;
                }
            }
            catch (Exception errorException)
            {
                MessageBox.Show(errorException.Message, MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void databaseRestoreClick(object obj)
        {
            try
            {
                if (!String.IsNullOrEmpty(selectedDatabase))
                {
                    string toDBName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), MainWindow.SOFTWARENAME, "DueManagementSystemDatabase.s3db");
                    File.Copy(selectedDatabase, toDBName, true);
                    MessageBox.Show("Database Restore Complete.", MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please Select a database.", MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            catch (Exception errorException)
            {
                MessageBox.Show(errorException.Message, MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
