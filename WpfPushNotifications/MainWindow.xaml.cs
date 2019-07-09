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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Azure.NotificationHubs;
//using System.Runtime.Serialization;

namespace WpfPushNotifications
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static String Header, Body;

        private static async void SendNotificationAsync()
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=YOURENDPOINT;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=//=", "wudcnotificationfinal");
            var toast1 = @"<toast><visual><binding template=""ToastText02""><text id=""1"">" + Header + @"</text><text id=""2"">" + Body + "</text></binding></visual></toast>";
            var a = await hub.SendWindowsNativeNotificationAsync(toast1);
         }
        
        public MainWindow()
        {
            InitializeComponent();

        }

        private void textchangedHeader(object sender, TextChangedEventArgs e)
        {
            Header = TextBoxHeader.Text.ToString();
        }

        //private void textchangedBody(object sender, TextChangedEventArgs e)
        //{
        //    Body = TextBoxBody.Text.ToString();
        //}

        private void clickedSendNotification(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(Header + "\t" + Body);
            SendNotificationAsync();

            TextBoxHeader.Clear();
            //TextBoxBody.Clear();
        }
    }
}
