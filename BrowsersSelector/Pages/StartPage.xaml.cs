using Microsoft.Win32;
using Newtonsoft.Json;
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

namespace BrowsersSelector.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private Browser browser;
        private List<Browser> browsers = new List<Browser>();
            List<string> browsersList = new List<string>();
        public StartPage()
        {
            InitializeComponent();

            string browsersRegistryKeyPath = @"SOFTWARE\WOW6432Node\Clients\StartMenuInternet";

            string shellCommandKeyPath = @"shell\open\command";

            using (RegistryKey browsersKey = Registry.LocalMachine.OpenSubKey(browsersRegistryKeyPath))
            {
                foreach (string browserKeyName in browsersKey.GetSubKeyNames())
                {
                    using (RegistryKey browserKey = browsersKey.OpenSubKey(browserKeyName))
                    {
                        string browserName = browserKey.GetValue(null).ToString();

                        using (RegistryKey shellCommandKey = browserKey.OpenSubKey(shellCommandKeyPath))
                        {
                            string browserPath = shellCommandKey.GetValue(null).ToString();

                            browsersList.Add(browserPath);

                            if (browserName == "Mozilla Firefox")
                            {
                                browser = new Browser
                                    {
                                        Name = browserName,
                                        Path = browserPath,
                                        Image = "firefox.png"
                                };

                                browsers.Add(browser);

                            }    
                            else if (browserName == "Google Chrome")
                            {
                                browser = new Browser
                                {
                                    Name = browserName,
                                    Path = browserPath,
                                    Image = "chrome.png"
                                };

                                browsers.Add(browser);                               
                            }
                            else if (browserName == "Internet Explorer")
                            {
                                browser = new Browser
                                {
                                    Name = browserName,
                                    Path = "\"" + browserPath + "\"",
                                    Image = "explorer.png"
                                };

                                browsers.Add(browser);
                            }

                            App.Browsers = browsers;
                        }
                    }
                }
            }
            List.ItemsSource = browsersList;


            //if (Properties.Settings.Default.Browser != null)
            //{

            //    string value = Properties.Settings.Default.Browser.ToString();
            //    if (value != null && value != string.Empty)
            //    {
            //        browsers = JsonConvert.DeserializeObject<List<Browser>>(value);
                   
            //        ListBrowsers.ItemsSource = App.Browsers = browsers;

            //    }
            //}

        }
        
        private void SettingsButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindow.SettingsContent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //if (Properties.Settings.Default.Browser != null)
            //{
            //    string value = Properties.Settings.Default.Browser.ToString();
            //    if (value != null)
            //    {
            //        browsers = JsonConvert.DeserializeObject<List<Browser>>(value);
                    ListBrowsers.ItemsSource = browsers;

            //    }
            //}
        }
        //private async void ListBrowsers_ItemClick(object sender, ItemClickEventArgs e)
        //{
           
        //}

        private void ListBrowsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var browser = (Browser)ListBrowsers.SelectedItem;
            if (browser != null) { 
            //LabelBrowser.Text = browser.Name.ToString();

            string link = " \"" + "https://google.com.ua/" + "\" ";

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/test.bat";
            string createText = "";

                    createText = browser.Path + link;
                    File.WriteAllText(path, createText);
                    System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/test.bat");
            }
        }
    }
}
