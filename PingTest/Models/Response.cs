using System;
using System.Collections.Generic;
using System.Text;

namespace PingTest.Models
{
    public class Response
    {
        public int Id { get; set; }
        public string IPaddress { get; set; }
        public string ResponseTime { get; set; }
        public string ErrorMessage { get; set; }
        public Response() { }

        public Response(int id, string address, string response, string error)
        {
            this.Id = id;
            this.IPaddress = address;
            this.ResponseTime = response;
            this.ErrorMessage = error;
        }
    }
}
