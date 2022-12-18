using System;

namespace BusinessLayer.Token
{
    public class AccessToken
    {
         public string Token { get; set; } 
        public DateTime ExpireDate { get; set; } 
    }
}
