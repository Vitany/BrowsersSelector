using BrowsersSelector.Pages;
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

namespace BrowsersSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SettingsPage settingsPage;
        private StartPage startPage;
        public MainWindow()
        {
            InitializeComponent();
            InitializeForms();
            App.MainWindow = (MainWindow)App.Current.MainWindow;
        }

        public void StartContent()
        {
            this.Content = this.startPage;
        }

        public void SettingsContent()
        {
            this.Content = this.settingsPage;
        }

        private void InitializeForms()
        {
            this.settingsPage = new SettingsPage();
            this.startPage = new StartPage();

            this.StartContent();
        }
    }
}
