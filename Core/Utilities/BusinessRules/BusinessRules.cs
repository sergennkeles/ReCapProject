using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.BusinessRules
{
   public class BusinessRules
    {
        // params keyword'ü ile IResult türünde olan Run methodumuza istediğimiz kadar parametre göndermemizi sağlıyor.
        // IResult[] logics(iş kuralları) ise verilen parametreleri array olarak tutmamızı sağlıyor.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) // parametre olarak gönderilen iş kuralları başarılı değilse tanımlı olan iş kuralını 
                                    // (ProductManager içinde tanımlı) return et 
                {
                    return logic; // yani burada tanımlı olan iş kuralında hata kodunu göster demek
                }
            }
            return null; // eğer iş kuralı başarılı ise bir şey döndürmene gerek yok.
        }
    }
}
