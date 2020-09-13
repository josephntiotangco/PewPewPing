using PingTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingTest.ViewModels
{
    public class ResponseViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public ResponseViewModel() { }

        public ResponseViewModel(Response response)
        {
            Id = response.Id;
            IPAddress = response.IPaddress;
            ResponseTime = response.ResponseTime;
            ErrorMessage = response.ErrorMessage;
        }

        private string _ipaddress;
        public string IPAddress
        {
            get { return _ipaddress; }
            set { SetValue(ref _ipaddress, value); OnPropertyChanged(nameof(IPAddress)); }
        }
        private string _responseTime;
        public string ResponseTime
        {
            get { return _responseTime; }
            set { SetValue(ref _responseTime, value); OnPropertyChanged(nameof(ResponseTime)); }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetValue(ref _errorMessage, value); OnPropertyChanged(nameof(ErrorMessage)); }
        }
    }
}
