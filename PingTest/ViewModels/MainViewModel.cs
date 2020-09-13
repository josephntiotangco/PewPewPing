using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PingTest.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _address;
        public string Address
        {
            get { return _address; }
            set { SetValue(ref _address, value); OnPropertyChanged(nameof(Address)); }
        }
        private int _pingCount;
        public int PingCount
        {
            get { return _pingCount; }
            set { SetValue(ref _pingCount, value); OnPropertyChanged(nameof(PingCount)); }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetValue(ref _errorMessage, value); OnPropertyChanged(nameof(ErrorMessage)); }
        }
        public ObservableCollection<ResponseViewModel> Responses { get; private set; } = new ObservableCollection<ResponseViewModel>();
        public ICommand PingCommand { get; private set; }
        public MainViewModel()
        {
            PingCommand = new Command(async () => await PingButton());
        }

        public async Task PingButton()
        {
            ErrorMessage = "";
            Responses.Clear();
            if (string.IsNullOrWhiteSpace(Address)) return;
            Ping pingSender = new Ping();
            int count = PingCount == 0 ? 4 : PingCount;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    PingReply reply = await pingSender.SendPingAsync(Address);
                    pingSender.Dispose();
                    if (reply.Status == IPStatus.TtlExpired || reply.Status == IPStatus.BadRoute || reply.Status == IPStatus.TimedOut || reply.Status == IPStatus.DestinationHostUnreachable || reply.Status == IPStatus.DestinationNetworkUnreachable)
                    {
                        ErrorMessage = "Address is unreachable. Please check internet connection.";
                        break;
                    }
                    else
                    {
                        Responses.Add(new ResponseViewModel
                        {
                            IPAddress = reply.Address.ToString(),
                            ResponseTime = reply.RoundtripTime.ToString() + "ms",
                            ErrorMessage = reply.Status.ToString()
                        });
                    }
                }
                catch(PingException ex)
                {
                    ErrorMessage = ex.Message;
                    break;
                }
                catch(Exception ex)
                {
                    ErrorMessage = ex.Message;
                    break;
                }
            }

        }
    }
}
