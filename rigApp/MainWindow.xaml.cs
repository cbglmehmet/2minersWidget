using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace rigApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        minersApi api = new minersApi();
        Thread binance;
        Thread apiThread;

        private bool applicationStatus = true;

        public MainWindow()
        {
            InitializeComponent();

            


            changeScreenStatus();
            if(settings.getScreenStatus())
            {
                screenStatus.IsChecked = true;
            }
            else
            {
                screenStatus.IsChecked = false;
            }


            apiThread = new Thread(new ThreadStart(apiThread_DoWork));
            apiThread.Start();

            binance = new Thread(new ThreadStart(binance_DoWork)) ;
            binance.Start();

            api.start();
            if(api.walletCount>3)
            {
                MessageBox.Show("This interface cannot display the data of more than 3 accounts.");
            }
            else
            {
                reDesign(api.walletCount);
            }

            page.WindowStartupLocation = WindowStartupLocation.Manual;
            page.Left = System.Windows.SystemParameters.WorkArea.Width - page.Width - 10;
            page.Top = System.Windows.SystemParameters.WorkArea.Height - page.Height - 25;

        }
        private void binance_DoWork()
        {
            do
            {
                this.Dispatcher.Invoke(() =>
                {
                    lblETH.Content = "ETH/USDT : " + api.getETHUSDT().ToString("0.##");
                });
                
                Thread.Sleep(200);
            } while (applicationStatus);
        }
        private void reDesign(int walletCount)
        {
            switch (walletCount)
            {
                case 1:
                    wallet2Detail.Visibility = Visibility.Hidden;
                    wallet3Detail.Visibility = Visibility.Hidden;
                    page.Height = 140;
                    break;
                case 2:
                    wallet2Detail.VerticalAlignment = VerticalAlignment.Bottom;
                    wallet2Detail.Margin = new Thickness(0,0,0,40);
                    page.Height = 210;
                    wallet2Detail.Visibility = Visibility.Visible;
                    wallet3Detail.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    wallet1Detail.Margin=new Thickness(0,20,0,0);
                    wallet2Detail.Visibility = Visibility.Visible;
                    wallet2Detail.Margin = new Thickness(0, 0, 0,15);
                    wallet3Detail.Margin = new Thickness(0,0,0,35);
                    wallet3Detail.Visibility = Visibility.Visible;
                    page.Height = 280;
                    break;
                default:
                    break;
            }
        }

        private void apiThread_DoWork()
        {
            do
            {
                api.update();
                this.Dispatcher.Invoke(() =>
                {
                    switch (api.walletCount)
                    {
                        case 1:
                            if (api.workerName1 == "offline")
                            {
                                wallet1WorkerName.Foreground = Brushes.Red;
                            }
                            else
                            {
                                wallet1WorkerName.Foreground = Brushes.White;
                            }
                            wallet1WorkerName.Content = api.workerName1;
                            wallet1CurrentHash.Content = api.currentHashrate1.ToString("0.##") + " M";
                            wallet1AvarageHash.Content = api.avarageHashrate1.ToString("0.##") + " M";
                            wallet1Unpaid.Content = api.unpaid1.ToString("0.#######");
                            wallet1Unconfirmed.Content = api.unconf1.ToString("0.######");
                            break;
                        case 2:
                            if (api.workerName1 == "offline")
                            {
                                wallet1WorkerName.Foreground = Brushes.Red;
                            }
                            else
                            {
                                wallet1WorkerName.Foreground = Brushes.White;
                            }
                            if (api.workerName2 == "offline")
                            {
                                wallet2WorkerName.Foreground = Brushes.Red;
                            }
                            else
                            {
                                wallet2WorkerName.Foreground = Brushes.White;
                            }

                            wallet1WorkerName.Content = api.workerName1;
                            wallet2WorkerName.Content = api.workerName2;

                            wallet1CurrentHash.Content = api.currentHashrate1.ToString("0.##") + " M";
                            wallet2CurrentHash.Content = api.currentHashrate2.ToString("0.##") + " M";

                            wallet1AvarageHash.Content = api.avarageHashrate1.ToString("0.##") + " M";
                            wallet2AvarageHash.Content = api.avarageHashrate2.ToString("0.##") + " M";

                            wallet1Unpaid.Content = api.unpaid1.ToString("0.#######");
                            wallet2Unpaid.Content = api.unpaid2.ToString("0.#######");

                            wallet1Unconfirmed.Content = api.unconf1.ToString("0.######");
                            wallet2Unconfirmed.Content = api.unconf2.ToString("0.######");
                            break;
                        case 3:
                            if (api.workerName1 == "offline")
                            {
                                wallet1WorkerName.Foreground = Brushes.Red;
                            }
                            else
                            {
                                wallet1WorkerName.Foreground = Brushes.White;
                            }
                            if (api.workerName2 == "offline")
                            {
                                wallet2WorkerName.Foreground = Brushes.Red;
                            }
                            else
                            {
                                wallet2WorkerName.Foreground = Brushes.White;
                            }
                            if (api.workerName3 == "offline")
                            {
                                wallet3WorkerName.Foreground = Brushes.Red;
                            }
                            else
                            {
                                wallet3WorkerName.Foreground = Brushes.White;
                            }

                            wallet1WorkerName.Content = api.workerName1;
                            wallet2WorkerName.Content = api.workerName2;
                            wallet3WorkerName.Content = api.workerName3;

                            wallet1CurrentHash.Content = api.currentHashrate1.ToString("0.##") + " M";
                            wallet2CurrentHash.Content = api.currentHashrate2.ToString("0.##") + " M";
                            wallet3CurrentHash.Content = api.currentHashrate3.ToString("0.##") + " M";

                            wallet1AvarageHash.Content = api.avarageHashrate1.ToString("0.##") + " M";
                            wallet2AvarageHash.Content = api.avarageHashrate2.ToString("0.##") + " M";
                            wallet3AvarageHash.Content = api.avarageHashrate3.ToString("0.##") + " M";

                            wallet1Unpaid.Content = api.unpaid1.ToString("0.#######");
                            wallet2Unpaid.Content = api.unpaid2.ToString("0.#######");
                            wallet3Unpaid.Content = api.unpaid3.ToString("0.#######");

                            wallet1Unconfirmed.Content = api.unconf1.ToString("0.######");
                            wallet2Unconfirmed.Content = api.unconf2.ToString("0.######");
                            wallet3Unconfirmed.Content = api.unconf3.ToString("0.######");

                            break;
                    }
                });
                

                Thread.Sleep(1000);
            } while (applicationStatus);
        }

        public void changeScreenStatus()
        {
            if (settings.getScreenStatus())
            {
                this.Topmost = true;
                this.Activate();
            }
            else
            {
                this.Topmost = false;
                this.Activate();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private void screenStatus_Click(object sender, RoutedEventArgs e)
        {
            if((bool)screenStatus.IsChecked)
            {
                settings.changeScreenStatus(true);
            }
            else
            {
                settings.changeScreenStatus(false);
            }
            changeScreenStatus();
        }

        private void page_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            applicationStatus = false;
        }

        private void btnExit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            applicationStatus = false;
            System.Windows.Application.Current.Shutdown();
        }
    }
}
