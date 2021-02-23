using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RoomsTask
{
    class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitilizeClient() { 
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            
        }
    }
}
