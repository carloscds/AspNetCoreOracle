using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoAPI
{
    class Token
    {
        public bool authenticated { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
        public string accessToken { get; set; }
        public string message { get; set; }
    }
}
