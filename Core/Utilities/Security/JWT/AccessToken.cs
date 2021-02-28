using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        // Burada istersek refresh token oluşturabiliriz. Bu sayede kullanıcının token süresi dolunca yeniden login olmasına
        // gerek olmadan süreci yönetebiliriz.
    }
}
