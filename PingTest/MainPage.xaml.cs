using PingTest.Models;
using PingTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PingTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            viewModel = new MainViewModel();
            InitializeComponent();         
        }
        public MainViewModel viewModel
        {
            get { return BindingContext as MainViewModel; }
            set { BindingContext = value; }
        }

        private void OnCompleted(object sender, EventArgs e)
        {
            viewModel.PingCommand.Execute(null);
        }
    }
}
