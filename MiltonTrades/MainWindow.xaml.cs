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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Printing;
using System.Collections.ObjectModel;
using System.Collections;
//using DevExpress.Xpf.Printing;
namespace MiltonTrades
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MiltonTrades.MiltonTradesEntities miltonTradesEntities;
        public const string SOFTWARENAME="Milton Trades";
        public MainWindow()
        {
            InitializeComponent();
        }

        private System.Data.Objects.ObjectQuery<Account> GetAccountsQuery(MiltonTradesEntities miltonTradesEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<MiltonTrades.Account> accountsQuery = miltonTradesEntities.Accounts;
            // Update the query to include TransictionTables data in Accounts. You can modify this code as needed.
            accountsQuery = accountsQuery.Include("TransictionTables");
            // Returns an ObjectQuery.
            return accountsQuery;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SOFTWARENAME);
                AppDomain.CurrentDomain.SetData("DataDirectory", fileName);
                miltonTradesEntities = new MiltonTrades.MiltonTradesEntities();
                // Load data into Accounts. You can modify this code as needed.
                System.Windows.Data.CollectionViewSource accountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("accountsViewSource")));
                System.Data.Objects.ObjectQuery<MiltonTrades.Account> accountsQuery = this.GetAccountsQuery(miltonTradesEntities);
                accountsViewSource.Source = accountsQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
                this.calculateAmounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            miltonTradesEntities.SaveChanges();
        }

        public ICommand UpdateCommand
        {
            get { return new ReplayCommand(new Action<object>(this.updateClick)); }
        }

        public ICommand PrintCommand
        {
            get { return new ReplayCommand(new Action<object>(this.printClick)); }
        }

        public ICommand DatabaseCommand
        {
            get { return new ReplayCommand(new Action<object>(this.databaseClick)); }
        }

        public ICommand DeletePartyCommand
        {
            get { return new ReplayCommand(new Action<object>(this.deletePartyClick)); }
        }

        public ICommand DeleteTranscationCommand
        {
            get { return new ReplayCommand(new Action<object>(this.deleteTranscationClick)); }
        }

        private void updateClick(object obj)
        {
            try
            {
                miltonTradesEntities.SaveChanges();
                MessageBox.Show("Update Successfully", SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception errorException)
            {
                MessageBox.Show(errorException.Message, SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void printClick(object obj)
        {
            try
            {
                CutomerlegerReport1 transitionReport = new CutomerlegerReport1();
                Account accountInfo = obj as Account;
                transitionReport.AccountInfoSource.DataSource = accountInfo;
                transitionReport.TranstionSource.DataSource = accountInfo.TransictionTables;
                transitionReport.WithDrawAmount.Value = this.WithDrawAmount.Text;
                transitionReport.WithDrawAmount.Visible = false;
                transitionReport.DepositAmount.Value = this.DepositAmount.Text;
                transitionReport.DepositAmount.Visible = false;
                transitionReport.Balance.Value = this.TransBlance.Text;
                transitionReport.Balance.Visible = false;
                PrintHelper.ShowPrintPreview(this, transitionReport);
            }
            catch (Exception errorException)
            {
                MessageBox.Show(errorException.Message, SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void databaseClick(object obj)
        {
            try
            {
                DataBackup dbBackup = new DataBackup();
                dbBackup.Show();
            }
            catch (Exception errorException)
            {
                MessageBox.Show(errorException.Message, SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deletePartyClick(object obj)
        {
            try
            {
                    ObservableCollection<Account> accountInfos = new ObservableCollection<Account>();
                    foreach (var singleItem in obj as IEnumerable)
                    {
                        Account singleHistory = singleItem as Account;
                        accountInfos.Add(singleHistory);
                    }
                    foreach (Account singleHistory in accountInfos)
                    {
                        miltonTradesEntities.Accounts.DeleteObject(singleHistory);
                    }
                    miltonTradesEntities.SaveChanges();
                    this.calculateAmounts();
                    Mouse.OverrideCursor = null;
                    MessageBox.Show("Deleted successfully.", SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception errorException)
            {
                MessageBox.Show(errorException.Message, SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteTranscationClick(object obj)
        {
            ObservableCollection<TransictionTable> accountInfos = new ObservableCollection<TransictionTable>();
            foreach (var singleItem in obj as IEnumerable)
            {
                TransictionTable singleHistory = singleItem as TransictionTable;
                accountInfos.Add(singleHistory);
            }
            foreach (TransictionTable singleHistory in accountInfos)
            {
                miltonTradesEntities.TransictionTables.DeleteObject(singleHistory);
            }
            miltonTradesEntities.SaveChanges();
            this.calculateAmounts();
            Mouse.OverrideCursor = null;
            MessageBox.Show("Deleted successfully.", SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void calculateAmounts()
        {
            var transictions=miltonTradesEntities.TransictionTables.FirstOrDefault();
            if(transictions!=null)
            {
                this.TotalSales.Text = miltonTradesEntities.TransictionTables.Sum(x => x.WithdrawAmount).ToString();
                this.TotalReceive.Text = miltonTradesEntities.TransictionTables.Sum(x => x.DepositAmount).ToString();
            }
            else
            {
                this.TotalSales.Text = "0";
                this.TotalReceive.Text = "0";
            }  
        }
    }


       #region ICommand Class
    class ReplayCommand : ICommand
    {
        private Action<object> _action;

        public ReplayCommand(Action<object> action)
        {
            this._action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public void Execute(object parameter)
        {
            try
            {
                if (parameter != null)
                {
                    this._action(parameter);
                }
                else
                {
                    MessageBox.Show("Invalid Command", MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MainWindow.SOFTWARENAME, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
#endregion
}
