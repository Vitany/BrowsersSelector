using Newtonsoft.Json;
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

namespace BrowsersSelector.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        private Browser browser;

        private List<Browser> browsers = new List<Browser>();

        public SettingsPage()
        {
            InitializeComponent();

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
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxBrowsers.SelectedIndex >= 0)
            {


                if (Properties.Settings.Default.Browser != null)
                {
                    string value = Properties.Settings.Default.Browser.ToString();
                    if (value != null && value != string.Empty)
                    {
                        browsers = JsonConvert.DeserializeObject<List<Browser>>(value);
                        ListBrowsers.ItemsSource = App.Browsers = browsers;

                    }
                }


                if (ComboBoxBrowsers.SelectedIndex == 0)
                {
                    browser = new Browser
                    {
                        Name = "Firefox",
                        Image = "ms-appx:///Assets/Browsers/firefox.png"
                    };
                }
                else if (ComboBoxBrowsers.SelectedIndex == 1)
                {
                    browser = new Browser
                    {
                        Name = "Chrome",
                        Image = "ms-appx:///Assets/Browsers/chrome.png"
                    };
                }
                else if (ComboBoxBrowsers.SelectedIndex == 2)
                {
                    browser = new Browser
                    {
                        Name = "Microsoft Edge",
                        Image = "ms-appx:///Assets/Browsers/explorer.png"
                    };
                }
                else if (ComboBoxBrowsers.SelectedIndex == 3)
                {
                    browser = new Browser
                    {
                        Name = "Opera",
                        Image = "ms-appx:///Assets/Browsers/opera.png"
                    };
                }
                browsers.Add(browser);

                App.Browsers = browsers;
                ListBrowsers.ItemsSource = App.Browsers = JsonConvert.DeserializeObject<List<Browser>>(JsonConvert.SerializeObject(App.Browsers));

                string json = JsonConvert.SerializeObject(browsers);

               Properties.Settings.Default.Browser = json;

                Properties.Settings.Default.Save();

                ComboBoxBrowsers.SelectedItem = null;
            }
        }

        private void CleanAllButton_Click(object sender, RoutedEventArgs e)
        {

            browsers.Clear();
            App.Browsers = browsers;

            Properties.Settings.Default.Browser = "";
            Properties.Settings.Default.Save();
            ListBrowsers.ItemsSource = App.Browsers = JsonConvert.DeserializeObject<List<Browser>>(JsonConvert.SerializeObject(App.Browsers));

            ComboBoxBrowsers.SelectedItem = null;
            ListBrowsers.ItemsSource = browsers;
        }

        private async void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            //string link = " \"" + "http://qaru.site/" + "\" ";
            //StorageFolder storageFolder = KnownFolders.PicturesLibrary;
            //Windows.Storage.StorageFile file = await storageFolder.CreateFileAsync("test.bat",
            //Windows.Storage.CreationCollisionOption.OpenIfExists);

            //await Windows.Storage.FileIO.WriteTextAsync(file, "START chrome" + link + "--profile-directory=\"Profile 2\"");

            //await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }

        private void ListBrowsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBrowsers.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить браузер?", "Подтверждение действия",
       MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ListBrowsers.SelectedIndex >= 0)
                    {
                        int number = ListBrowsers.SelectedIndex;
                        browsers.RemoveAt(number);

                        App.Browsers = browsers;
                        ListBrowsers.ItemsSource = App.Browsers = JsonConvert.DeserializeObject<List<Browser>>(JsonConvert.SerializeObject(App.Browsers));


                        string json = JsonConvert.SerializeObject(browsers);

                        Properties.Settings.Default.Browser = json;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                }
            }
        }

        private void BackButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.MainWindow.StartContent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            if (Properties.Settings.Default.Browser != null)
            {
                string value = Properties.Settings.Default.Browser.ToString();
                if (value != null && value != string.Empty)
                {
                    browsers = JsonConvert.DeserializeObject<List<Browser>>(value);
                    ListBrowsers.ItemsSource = App.Browsers = browsers;

                }
            }
        }
    }
}
