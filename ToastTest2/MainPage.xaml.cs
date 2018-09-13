using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToastTest2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter is string && e.Parameter.Equals("123"))
                test1();
        }

        private async void test1()
        {
            TextBlock_Label.Text = $"Button 1 Clicked! {DateTime.Now.ToString()}";
        }

        private async void test2()
        {
            TextBlock_Label.Text = $"Button 2 Clicked! {DateTime.Now.ToString()}";
        }

        private async void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_Label.Text = $"Button Clicked! {DateTime.Now.ToString()}";

            ToastContent content = new ToastContent()
            {
                DisplayTimestamp = DateTime.Now,

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "testing"
                            },
                        }
                    }
                },

                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("Button 1", "action=test1&Id=123")
                        {
                            
                            ActivationType = ToastActivationType.Foreground
                        },
                        new ToastButton("Button 2", "action=test2&Id=1234")
                        {
                            ActivationType = ToastActivationType.Background
                        }
                    }
                }

            };

            var toast = new ToastNotification(content.GetXml());

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        
    }
}
